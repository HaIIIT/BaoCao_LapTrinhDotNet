using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_htchamcong : Form
    {
        VideoCapture capture;
        Mat frame;
        Timer timer;
        public Frm_htchamcong()
        {
            InitializeComponent();
        }
        private void LuuChamCong()
        {
            string maNS = cls_chcecklogin.MaNhanVien;
            DateTime now = DateTime.Now;
            string ngayCham = now.ToString("yyyy-MM-dd");
            string gioHienTaiSql = now.ToString("HH:mm:ss");
            TimeSpan gioHienTai = now.TimeOfDay;
            TimeSpan gioChuanVao = new TimeSpan(8, 0, 0);
            TimeSpan gioChuanRa = new TimeSpan(17, 0, 0);
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string checkSql = "SELECT MaChamCong, GioVao, GioRa " +
                                      "FROM ChamCong " +
                                      "WHERE MaNhanSu = N'" + maNS + "' " +
                                      "AND NgayCham = '" + ngayCham + "'";
                    SqlDataReader rdr = ketnoi.truyvan(checkSql);
                    if (!rdr.Read())
                    {
                        rdr.Close();
                        string trangThai = gioHienTai > gioChuanVao ? "Đi trễ" : "Đúng giờ";
                        string ghiChu = gioHienTai > gioChuanVao ? "Vào trễ" : "Tốt";
                        string insertSql = "INSERT INTO ChamCong (MaNhanSu, NgayCham, GioVao, GioRa, TrangThai, SoGioLam, GhiChu) " +
                                           "VALUES (N'" + maNS + "', '" + ngayCham + "', '" + gioHienTaiSql + "', NULL, " +
                                           "N'" + trangThai + "', 0, N'" + ghiChu + "')";
                        ketnoi.capnhat(insertSql);
                        MessageBox.Show("Đã ghi nhận giờ vào: " + gioHienTaiSql,
                            "Hệ thống chấm công - Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        string maChamCong = rdr["MaChamCong"].ToString();
                        string gioVaoStr = rdr["GioVao"].ToString();
                        object gioRaObj = rdr["GioRa"];
                        if (gioRaObj != DBNull.Value && !string.IsNullOrWhiteSpace(gioRaObj.ToString()))
                        {
                            rdr.Close();
                            MessageBox.Show("Hôm nay đã chấm công đủ 2 lần rồi!",
                                "Hệ thống chấm công - Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        TimeSpan gioVao = TimeSpan.Parse(gioVaoStr);
                        rdr.Close();
                        double soGioLam = (gioHienTai - gioVao).TotalHours;
                        if (soGioLam < 0)
                            soGioLam = 0;
                        string trangThai = "";
                        string ghiChu = "";
                        bool diTre = gioVao > gioChuanVao;
                        bool tanCaSom = gioHienTai < gioChuanRa;
                        if (diTre && tanCaSom)
                        {
                            trangThai = "Đi trễ - Tan ca sớm";
                            ghiChu = "Vào trễ, ra sớm";
                        }
                        else if (diTre)
                        {
                            trangThai = "Đi trễ";
                            ghiChu = "Vào trễ";
                        }
                        else if (tanCaSom)
                        {
                            trangThai = "Tan ca sớm";
                            ghiChu = "Ra sớm";
                        }
                        else
                        {
                            trangThai = "Đúng giờ";
                            ghiChu = "Tốt";
                        }
                        string updateSql = "UPDATE ChamCong SET " +
                                           "GioRa = '" + gioHienTaiSql + "', " +
                                           "TrangThai = N'" + trangThai + "', " +
                                           "SoGioLam = " + soGioLam.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", " +
                                           "GhiChu = N'" + ghiChu + "' " +
                                           "WHERE MaChamCong = " + maChamCong;
                        ketnoi.capnhat(updateSql);
                        MessageBox.Show("Đã ghi nhận giờ ra: " + gioHienTaiSql +
                                        "\nSố giờ làm: " + soGioLam.ToString("0.00"),
                            "Hệ thống chấm công - Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu chấm công: " + ex.Message,
                    "Hệ thống chấm công - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void Frm_htchamcong_Load(object sender, EventArgs e)
        {
            frame = new Mat();
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;

            //bật camera
            lbl_trangthai.Text = "Camera Đang Khởi Động....";
            capture = new VideoCapture(0);
            if (!capture.IsOpened())
            {
                MessageBox.Show("Camera không được mở");
                return;
            }
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            capture.Read(frame);
            if (!frame.Empty())
            {
                pic_camera.Image = BitmapConverter.ToBitmap(frame);
            }
        }

        private async void btnchamcong_Click(object sender, EventArgs e)
        {
            if (frame == null || frame.Empty())
            {
                MessageBox.Show("Không nhận thấy hình ảnh");
                return;
            }

            DateTime now = DateTime.Now;
            lbl_trangthai.Text = "Đã chấm công lúc: " + now.ToString("HH:mm:ss dd/MM/yyyy");
            LuuChamCong();
            timer.Stop();
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
                capture = null;
            }
            MessageBox.Show("Chấm công thành công!" +
                            "\nThời Gian: " + now.ToString("HH:mm:ss dd/MM/yyyy"),
                            "Hệ thống chấm công - Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            string email = "";
            string hoten = "";
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT Email, HoTen FROM NhanSu WHERE MaNhanSu = '" + cls_chcecklogin.MaNhanVien + "'";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                if (rdr.Read())
                {
                    email = rdr["Email"].ToString();
                    hoten = rdr["HoTen"].ToString();
                }
                rdr.Close();
                ketnoi.dongketnoi();
            }
            try
            {
                var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Chấm Công Nhân Sự");
                var toAddress = new MailAddress(email);

                const string frompass = "hgsi mdwb lbng qywi";
                const string subject = "Ghi Nhận Chấm Công";

                string body = "Xin chào, "+hoten+"" +
                            "\nBạn vừa chấm công vào lúc: " + now.ToString("HH:mm:ss dd/MM/yyyy") +
                            "\n------------------------" +
                            "\nHệ Thống Quản Lý Chung Cư" +
                            "\nHệ Thống Chấm Công Nhân Sự" +
                            "\nEmail hỗ trợ: support@hethong.com" +
                            "\nĐây là email tự động, vui lòng không phản hồi mail này!";

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromAddress.Address, frompass);
                    smtp.Timeout = 20000;

                    using (var message = new MailMessage(fromAddress, toAddress))
                    {
                        message.Subject = subject;
                        message.Body = body;

                        // Chuyển frame OpenCV thành Bitmap
                        using (Bitmap bmp = BitmapConverter.ToBitmap(frame))
                        {
                            MemoryStream ms = new MemoryStream();
                            bmp.Save(ms, ImageFormat.Jpeg);
                            ms.Position = 0;
                            Attachment attachment = new Attachment(ms, "ChamCong_" + now.ToString("yyyyMMdd_HHmmss") + ".jpg", MediaTypeNames.Image.Jpeg);
                            message.Attachments.Add(attachment);
                            smtp.Send(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
            }
            await Task.Delay(3000);
            lbl_trangthai.Text = "Camera đang hoạt động lại...";
            capture = new VideoCapture(0);
            if (!capture.IsOpened())
            {
                MessageBox.Show("Không mở lại được camera");
                return;
            }
            timer.Start();
        }

        private void llbl_exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_ChamCong frmCha = this.MdiParent as Frm_ChamCong;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
    }
}
