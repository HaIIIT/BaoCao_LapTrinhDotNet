using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Login : Form
    {
        public string TenDangNhap { get; set; }
        public Frm_Login()
        {
            InitializeComponent();
        }
        GraphicsPath BoGocPanel(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            panel1.Region = new Region(BoGocPanel(panel1.ClientRectangle, 30));
            txt_tk.Region = new Region(BoGocPanel(txt_tk.ClientRectangle, 8));
            txt_mk.Region = new Region(BoGocPanel(txt_mk.ClientRectangle, 8));
            btn_cancel.BackColor = Color.Transparent;
            this.AcceptButton = btn_dn;
            this.CancelButton = btn_cancel;
            txt_mk.PasswordChar = '*';
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát đăng nhập không?", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
        }

        private void btn_dn_Click(object sender, EventArgs e)
        {
            if (txt_tk.Text == "Admin" && txt_mk.Text == "123")
            {
                cls_chcecklogin.DaDangNhap = true;
                DialogResult  = MessageBox.Show("Đăng Nhập Thành công!!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenDangNhap = txt_tk.Text;          
                this.Close();
            }else{
                MessageBox.Show("Tài Khoản hoặc Mật Khẩu Không Đúng!!!"+"\n Nếu bạn chưa có tài khoản vui lòng liên hệ Ban Quản Trị để được hỗ trợ"+"\nTrân trọng cảm ơn quý khách hàng!!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tk.Clear();
                txt_mk.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Frm_Hejthongkhoiphuctaikhoan khoiphuctaikhoan = new Frm_Hejthongkhoiphuctaikhoan();
            khoiphuctaikhoan.ShowDialog();
        }
    }   
}
