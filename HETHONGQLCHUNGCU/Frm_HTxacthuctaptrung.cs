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

namespace HETHONGQLCHUNGCU
{    
    public partial class Frm_HTxacthuctaptrung : Form
    {
        public event Action DangXuatSauDoiMK;
        Random rd = new Random();
        int otp;
        DateTime TgianOTP;
        bool daxacminh = false;
        Timer timer = new Timer();
        int countdown = 30;
        public Frm_HTxacthuctaptrung()
        {
            InitializeComponent();
        }

        private void Frm_HTxacthuctaptrung_Load(object sender, EventArgs e)
        {
            grb_changePwd.Visible = false;
            btn_xacnhanotp.Enabled = false;
            txt_otp.Enabled = false;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void btn_otp_Click(object sender, EventArgs e)
        {
            if (txt_email.Text.Trim() == "" || txt_tk.Text.Trim() == "" || txt_mkcu.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!(txt_email.Text.Trim() == "24004190@st.vlute.edu.vn" && txt_tk.Text.Trim() == "Admin" && txt_mkcu.Text.Trim() == "12345"))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin, Thông tin vừa nhập không đúng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tk.Focus();
            }
            else
            {
                try
                {
                    otp = rd.Next(100000, 999999);
                    TgianOTP = DateTime.Now;
                    var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Xác Thực Tập Trung");
                    var toAddress = new MailAddress(txt_email.ToString());
                    const string frompass = "hgsi mdwb lbng qywi";
                    const string subjet = "Mã Xác Thực - OTP Code";
                    string body = otp.ToString() +
                                "\n------------------------" +
                                "\nHệ Thống Quản Lý Chung Cư" +
                                "\nHệ Thống Xác Thực Tập Trung" +
                                "\nĐây là email tự động, vui lòng không trả lời về mail này!";
                    var smtp = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(fromAddress.Address, frompass),
                        Timeout = 200000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subjet,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    btn_otp.Enabled = false;
                    countdown = 30;
                    btn_otp.Text = "Gửi Lại OTP (" + countdown + "s)";
                    timer.Start();
                    DialogResult rs= MessageBox.Show("OTP đã được gửi qua email: " + txt_email.Text, "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(rs == DialogResult.OK)
                    {
                        txt_otp.Enabled = true;
                        txt_otp.Focus();
                        btn_xacnhanotp.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            countdown--;
            btn_otp.Text = "Gửi lại (" + countdown + "s)";
            if (countdown <= 0)
            {
                timer.Stop();
                btn_otp.Enabled = true;
                btn_otp.Text = "Gửi OTP";
            }
        }

        private void btn_xacnhanotp_Click(object sender, EventArgs e)
        {
            if (txt_otp.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã OTP!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((DateTime.Now - TgianOTP).TotalSeconds > 60)
            {
                MessageBox.Show("OTP đã hết hạn!",
                    "Hệ Thống Khôi Phục Tài Khoản - Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_otp.Clear();
                return;
            }
            if (txt_otp.Text.Trim() == otp.ToString())
            {
                daxacminh = true;
                MessageBox.Show("Xác minh thành công!",
                    "Hệ Thống Khôi Phục Tài Khoản - Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_otp.Visible = false;
                btn_xacnhanotp.Visible = false;
                txt_otp.Enabled = false;
                txt_email.Enabled = false;
                txt_mkcu.Enabled = false;
                txt_tk.Enabled = false;
                grb_changePwd.Visible = true;             
            }
            else
            {
                MessageBox.Show("Xác minh thất bại!",
                    "Hệ Thống Khôi Phục Tài Khoản - Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_otp.Clear();
                txt_otp.Focus();
            }
        }

        private void txt_otp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }else if(txt_otp.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                
            }
            txt_otp.MaxLength = 6;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_newmk.Text == String.Empty || txt_comform.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_newmk.Text != txt_comform.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_comform.Clear();
            }
            else
            {
                DialogResult rs = MessageBox.Show("Mật khẩu đã được đặt lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Trung Tâm Xác Thực Tập Trung");
                    var toAddress = new MailAddress(txt_email.ToString());
                    const string frompass = "hgsi mdwb lbng qywi";
                    const string subjet = "Cảnh Báo Thay Đổi Mật Khẩu";
                    string body = "Tài khoản bạn vừa được đặt lại mật khẩu! Nếu không phải bạn thực hiện hãy liên hệ bộ phận chăm sóc khách hàng để được hộ trợ sớm nhất!" +
                                "\nTrân Trọng!" +
                                "\n------------------------" +
                                "\nHệ Thống Quản Lý Chung Cư" +
                                "\nHệ Thống Xác Thực Tập Trung" +
                                "\nemail hỗ trợ: suport@hethong.com" +
                                "\nĐây là email tự động, vui lòng không phản hồi về mail này!";
                    var smtp = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(fromAddress.Address, frompass),
                        Timeout = 200000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subjet,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    grb_xacthuc.Enabled = false;
                    grb_changePwd.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (rs == DialogResult.OK)
                {
                    cls_chcecklogin.DaDangNhap = false;
                    DangXuatSauDoiMK?.Invoke(); // báo ra ngoài
                    this.Close();
                }
            }
        }
        private void lbl_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        
    }
}
