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
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            btn_dangnhap.Visible = true;//hiện button đăng nhập
            btn_thoat.Visible = true;//hiện button thoát
            cb_user.Visible = false;//tắt ComboBox
            cb_user.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)//button đăng nhập
        {
            Frm_Login frm = new Frm_Login();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                string ten = frm.TenDangNhap;
                btn_dangnhap.Visible = false;
                btn_thoat.Visible = false;
                cb_user.Visible = true;
                cb_user.Items.Clear();
                cb_user.Items.Add("Xin Chào " + ten);
                cb_user.Items.Add("Đăng Xuất");
                cb_user.Items.Add("Đổi Mật Khẩu");
                cb_user.SelectedIndex = 0;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)//button thoát
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cb_user_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cb_user.SelectedItem.ToString() == "Đăng Xuất")
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát hệ thống không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn_dangnhap.Visible = true;
                    btn_thoat.Visible = true;
                    cb_user.Visible = false;
                    cb_user.Items.Clear();
                }
            }
        }
    }
}
