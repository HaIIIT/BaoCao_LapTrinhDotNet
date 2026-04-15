using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mime;
using System.Drawing.Imaging;

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
        private void Frm_htchamcong_Load(object sender, EventArgs e)
        {
            frame = new Mat();
            timer = new Timer();
            timer.Interval = 30;
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

            try
            {
                var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Chấm Công Nhân Sự");
                var toAddress = new MailAddress("24004190@st.vlute.edu.vn");

                const string frompass = "hgsi mdwb lbng qywi";
                const string subject = "Ghi Nhận Chấm Công";

                string body = "Xin chào, Lê Chí Hải!" +
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
            this.Close();
            timer.Stop();
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
                capture = null;
            }
        }
    }
}
