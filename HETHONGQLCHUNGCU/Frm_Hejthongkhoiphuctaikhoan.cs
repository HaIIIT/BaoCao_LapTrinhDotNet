using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Hejthongkhoiphuctaikhoan : Form
    {
        Random rd = new Random();
        string otp = "";
        DateTime TgianOTP;
        bool daXacThucOTP = false;
        public Frm_Hejthongkhoiphuctaikhoan()
        {
            InitializeComponent();
        }
        string LayTenThatTheoTaiKhoan()
        {
            string hoten = "";
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT cd.HoTen AS HoTenCuDan, ns.HoTen AS HoTenNhanSu " +
                                 "FROM TaiKhoanNguoiDung tk " +
                                 "LEFT JOIN CuDan cd ON tk.MaCuDan = cd.MaCuDan " +
                                 "LEFT JOIN NhanSu ns ON tk.MaNhanVien = ns.MaNhanSu " +
                                 "WHERE tk.TenDangNhap = N'" + txt_tk.Text.Trim() + "' " +
                                 "AND tk.Email = N'" + txt_email.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        if (rdr["HoTenCuDan"] != DBNull.Value)
                            hoten = rdr["HoTenCuDan"].ToString();
                        else if (rdr["HoTenNhanSu"] != DBNull.Value)
                            hoten = rdr["HoTenNhanSu"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy họ tên: " + ex.Message);
            }
            if (hoten.Trim() == "")
                hoten = "Người dùng";
            return hoten;
        }
        private void Frm_Hejthongkhoiphuctaikhoan_Load(object sender, EventArgs e)
        {
            grb_changePwd.Visible = false;
            txt_newmk.Enabled = false;
            txt_comform.Enabled = false;
            txt_otp.Enabled = false;
        }
        private void btn_xacthuc_Click(object sender, EventArgs e)
        {
            if (txt_tk.Text.Trim() == "" || txt_email.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và email!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT TenDangNhap, Email FROM TaiKhoanNguoiDung " +
                                 "WHERE TenDangNhap = N'" + txt_tk.Text.Trim() + "' " +
                                 "AND Email = N'" + txt_email.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Xác thực thành công! Vui lòng lấy mã OTP.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_otp.Enabled = true;
                        grb_changePwd.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Xác thực thất bại! Vui lòng kiểm tra lại tên tài khoản hoặc email.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message,
                    "Hệ Thống Khôi Phục Tài Khoản - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_otp_Click(object sender, EventArgs e)
        {
            if (txt_tk.Text.Trim() == "" || txt_email.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng xác thực tài khoản trước!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT TenDangNhap, Email FROM TaiKhoanNguoiDung " +
                                 "WHERE TenDangNhap = N'" + txt_tk.Text.Trim() + "' " +
                                 "AND Email = N'" + txt_email.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (!rdr.Read())
                    {
                        MessageBox.Show("Thông tin tài khoản không hợp lệ!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rdr.Close();
                        return;
                    }
                    rdr.Close();
                    otp = rd.Next(100000, 999999).ToString();
                    TgianOTP = DateTime.Now;
                    var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Khôi Phục Tài Khoản");
                    var toAddress = new MailAddress(txt_email.Text.Trim());
                    const string frompass = "hgsi mdwb lbng qywi";
                    const string subject = "Mã OTP Khôi Phục Tài Khoản";
                    string body = "Mã OTP của bạn là: " + otp +
                                  "\n\nMã có hiệu lực trong 120 giây." +
                                  "\nVui lòng không chia sẻ mã này cho bất kỳ ai." +
                                  "\n\n------------------------" +
                                  "\nHệ Thống Quản Lý Chung Cư" +
                                  "\nEmail hỗ trợ: support@hethong.com" +
                                  "\nĐây là email tự động, vui lòng không trả lời về mail này!";
                    var smtp = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, frompass),
                        Timeout = 30000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress))
                    {
                        message.Subject = subject;
                        message.Body = body;
                        smtp.Send(message);
                    }
                    MessageBox.Show("OTP đã được gửi về email của bạn!",
                        "Hệ Thống Khôi Phục Tài Khoản",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_otp.Enabled = true;
                    txt_otp.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi OTP: " + ex.Message,
                    "Hệ Thống Khôi Phục Tài Khoản - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketnoi.dongketnoi();
            }
        }
        private void txt_otp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            txt_otp.MaxLength = 6;
        }
        private void txt_otp_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_otp.Text.Length == 6)
            {
                if (txt_otp.Text != otp)
                {
                    MessageBox.Show("OTP không đúng! Vui lòng nhập lại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_otp.Clear();
                    txt_otp.Focus();
                }
                else if ((DateTime.Now - TgianOTP).TotalSeconds > 120)
                {
                    MessageBox.Show("Mã OTP đã hết hạn! Vui lòng lấy mã mới.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_otp.Clear();
                    txt_otp.Focus();
                }
                else
                {
                    daXacThucOTP = true;
                    MessageBox.Show("OTP xác thực thành công! Bạn có thể đặt lại mật khẩu.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grb_changePwd.Visible = true;
                    txt_newmk.Enabled = true;
                    txt_comform.Enabled = true;
                    txt_newmk.Focus();
                }
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!daXacThucOTP)
            {
                MessageBox.Show("Vui lòng xác thực OTP trước khi đổi mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_newmk.Text.Trim() == "" || txt_comform.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_newmk.Text.Trim() != txt_comform.Text.Trim())
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp! Vui lòng kiểm tra lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_comform.Clear();
                txt_comform.Focus();
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string up = "UPDATE TaiKhoanNguoiDung SET " +
                                "MatKhau = N'" + txt_newmk.Text.Trim() + "' " +
                                "WHERE TenDangNhap = N'" + txt_tk.Text.Trim() + "' " +
                                "AND Email = N'" + txt_email.Text.Trim() + "'";
                    int kq = ketnoi.capnhat(up);
                    if (kq > 0)
                    {
                        string hoten = LayTenThatTheoTaiKhoan();
                        try
                        {
                            var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Khôi Phục Tài Khoản");
                            var toAddress = new MailAddress(txt_email.Text.Trim());
                            const string frompass = "hgsi mdwb lbng qywi";
                            const string subject = "Mật Khẩu Đã Được Đặt Lại";
                            string body = "Xin chào, " + hoten  +
                                          "\n\nMật khẩu tài khoản của bạn đã được đặt lại thành công." +
                                          "\nNếu không phải bạn thực hiện, vui lòng liên hệ quản trị viên hoặc bộ phận hỗ trợ ngay." +
                                          "\n\n------------------------" +
                                          "\nHệ Thống Quản Lý Chung Cư" +
                                          "\nĐây là email tự động, vui lòng không phản hồi.";
                            var smtp = new SmtpClient()
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, frompass),
                                Timeout = 30000
                            };
                            using (var message = new MailMessage(fromAddress, toAddress))
                            {
                                message.Subject = subject;
                                message.Body = body;
                                smtp.Send(message);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công nhưng gửi mail cảnh báo thất bại: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        MessageBox.Show("Mật khẩu đã được đặt lại thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grb_xacthuc.Visible = false;
                        grb_changePwd.Visible = false;
                        linkLabel1.ForeColor = Color.Red;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật mật khẩu: " + ex.Message,
                    "Hệ Thống Khôi Phục Tài Khoản - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketnoi.dongketnoi();
            }
        }
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Login login = new Frm_Login();
            login.ShowDialog();
        }

        
    }
}