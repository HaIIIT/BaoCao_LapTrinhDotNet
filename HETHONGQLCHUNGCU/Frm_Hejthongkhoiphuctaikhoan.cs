using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Hejthongkhoiphuctaikhoan : Form
    {
        public Frm_Hejthongkhoiphuctaikhoan()
        {
            InitializeComponent();
        }
        Random rd = new Random();
        String otp;
        DateTime TgianOTP;

        private void Frm_Hejthongkhoiphuctaikhoan_Load(object sender, EventArgs e)
        {
            grb_changePwd.Visible = false;
            txt_newmk.Enabled = false;
            txt_comform.Enabled = false;
        }

        private void btn_xacthuc_Click(object sender, EventArgs e)
        {
            if (txt_tk.Text == "admin" && txt_email.Text == "Admin@gmail.com")
            {
                MessageBox.Show("Xác thực thành công! >> Đặt lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grb_changePwd.Visible = true;
            }
            else
            {
                MessageBox.Show("Xác thực thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_otp_Click(object sender, EventArgs e)
        {
            otp = rd.Next(100000, 999999).ToString();
            MessageBox.Show($"Mã OTP của bạn là: {otp}", "Hệ Thống Khôi Phục Tài Khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TgianOTP = DateTime.Now;
        }

        private void txt_otp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_otp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_otp.Text.Length == 6)
            {
                if (txt_otp.Text != otp)
                {
                    MessageBox.Show("OTP không đúng! Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_otp.Clear();
                }
                else if ((DateTime.Now - TgianOTP).TotalSeconds > 120)
                {
                    MessageBox.Show("Mã Hết Hạn! Vui Lòng Lấy Mã Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_otp.Clear();
                    txt_otp.Focus();
                }
                else
                {
                    MessageBox.Show("OTP xác thực thành công! Bạn có thể đặt lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_newmk.Enabled = true;
                    txt_comform.Enabled = true;
                }
            }
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
                MessageBox.Show("Mật khẩu đã được đặt lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grb_xacthuc.Visible = false;
                grb_changePwd.Visible = false;
                linkLabel1.ForeColor = Color.Red;
            }  
        }
    }
}
