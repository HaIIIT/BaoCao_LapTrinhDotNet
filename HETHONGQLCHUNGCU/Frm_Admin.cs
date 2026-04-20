using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Admin : Form
    {
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_TTADMIN frmttadmin = null;
        private Frm_Thongtintaikhoan frmttcanhan= null;
        public Frm_Admin()
        {
            InitializeComponent();
        }
        //xây dựng ham tinh tong ở grp trạng thái
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if(ketnoi.moketnoi())
                {
                    //tổng số tài khoản
                    string sel = "SELECT COUNT(*) FROM TaiKhoanNguoiDung";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tong.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    //tổng số tài khoản cư dân
                    string sel2 = "SELECT COUNT(*) FROM TaiKhoanNguoiDung WHERE Quyen = '6'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if(rdr2.Read())
                    {
                        lbl_tkcudan.Text = rdr2[0].ToString();
                    } rdr2.Close();
                    //tổng số tài khoản nhân sự
                    string sel3 = "SELECT COUNT(*) FROM TaiKhoanNguoiDung WHERE Quyen = '2' OR Quyen = '3' OR Quyen = '4' OR Quyen = '5'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_tknhansu.Text = rdr3[0].ToString();
                    }
                    rdr3.Close();
                    //tổng số tài khoản Admin
                    string sel4 = "SELECT COUNT(*) FROM TaiKhoanNguoiDung WHERE Quyen = '1'";
                    SqlDataReader rdr4 = ketnoi.truyvan(sel4);
                    if (rdr4.Read())
                    {
                        lbl_tkadmin.Text = rdr4[0].ToString();
                    }
                    rdr4.Close();
                    //tổng số tài khoản đang hoạt động
                    string sel5 = "SELECT COUNT(*) FROM TaiKhoanNguoiDung WHERE TrangThai = '0'";
                    SqlDataReader rdr5 = ketnoi.truyvan(sel5);
                    if (rdr5.Read())
                    {
                        lbl_hoatdong.Text = rdr5[0].ToString();
                    }
                    rdr5.Close();                  
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }
        void tiemkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaTaiKhoan, TenDangNhap, Email, Quyen, TrangThai, FORMAT(NgayTao, 'dd-MM-yyyy') AS NgayTao, MaCuDan, MaNhanVien FROM TaiKhoanNguoiDung WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mtk.Text.Trim()))
                    {
                        sel += " AND MaTaiKhoan LIKE N'%" + txt_mtk.Text.Trim() + "%'";                    }
                    if (!string.IsNullOrEmpty(txt_tentk.Text.Trim()))
                    {
                        sel += " AND TenDangNhap LIKE N'%" + txt_tentk.Text.Trim() + "%'";
                    }
                    if (cbx_quyen.SelectedIndex > 0)
                    {
                        string Quyen = cbx_quyen.Text.Split('-')[0].Trim();
                        sel += " AND Quyen = '" + Quyen + "'";
                    }
                    if (cbx_trangthai.SelectedIndex > 0) 
                    {
                        string TrangThai = cbx_trangthai.Text.Split('-')[0].Trim();
                        sel += " AND TrangThai = '" + TrangThai + "'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dstaikhoan.DataSource = tb;
                    ketnoi.dongketnoi();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadFullTaiKhoan()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaTaiKhoan, TenDangNhap, Email, Quyen, TrangThai, FORMAT(NgayTao, 'dd-MM-yyyy') AS NgayTao, MaCuDan, MaNhanVien FROM TaiKhoanNguoiDung";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgv_dstaikhoan.DataSource = tb;
                ketnoi.dongketnoi();
            }
        }
        void LoadComboBox()
        {
            cbx_quyen.Items.Clear();
            cbx_quyen.Items.Add("-- Chọn quyền --");
            cbx_quyen.Items.Add("1-Admin");
            cbx_quyen.Items.Add("2-Nhân viên");
            cbx_quyen.Items.Add("3-Trưởng BP Nhân Sự");
            cbx_quyen.Items.Add("4-Trưởng BP KH-TC");
            cbx_quyen.Items.Add("5-Trưởng BP QLDV-Ti");
            cbx_quyen.Items.Add("6-Cư dân");
            cbx_quyen.Items.Add("7-Ban Quản Lý");
            cbx_quyen.SelectedIndex = 0;
            cbx_trangthai.Items.Clear();
            cbx_trangthai.Items.Add("-- Chọn trạng thái --");
            cbx_trangthai.Items.Add("0-Đang Hoạt động");
            cbx_trangthai.Items.Add("1-Ngưng Hoạt Động");
            cbx_trangthai.SelectedIndex = 0;
        }
        //-------------MenuStrip-----------------
        private void MDI()
        {
            frmttadmin = new Frm_TTADMIN();
            frmttadmin.MdiParent = this;
            frmttadmin.StartPosition = FormStartPosition.Manual;
            frmttadmin.Location = new Point(80, 140);
            frmttadmin.FormBorderStyle = FormBorderStyle.None;
            frmttadmin.FormClosed += Frm_TTADMIN_FormClosed;
            frmttadmin.Show();
        }
        private void ancontrols()
        {
            pnl_title.Visible = false;
            grp_trangthai.Visible = false;
            grp_TraCu.Visible = false;
            ppnl_tiltle1.Visible = false;
            dgv_dstaikhoan.Visible = false;
        }
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cls_chcecklogin.DangXuat();
            this.Close();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
        private void quênMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                //ẩn contorls
                ancontrols();
            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            pnl_title.Visible = true;
            grp_trangthai.Visible = true;
            grp_TraCu.Visible = true;
            ppnl_tiltle1.Visible = true;
            dgv_dstaikhoan.Visible = true;
        }
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(130, 90);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                frmttcanhan.Show();
                //ẩn contorls
                ancontrols();
            }
            else
            {
                frmttcanhan.Activate();
            }
        }
        private void Frm_Thongtintaikhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            pnl_title.Visible = true;
            grp_trangthai.Visible = true;
            grp_TraCu.Visible = true;
            ppnl_tiltle1.Visible = true;
            dgv_dstaikhoan.Visible = true;
        }
        private void themthongtinbaotrotool_Click(object sender, EventArgs e)
        {
            if(frmttadmin == null || frmttadmin.IsDisposed)
            {
                MDI();
                frmttadmin.settrangthaibutton(true, false, false);
                ancontrols();
            }
            else
            {
                frmttadmin.Activate();
            }
        }
        private void cậpNhậtThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttadmin == null || frmttadmin.IsDisposed)
            {
                MDI();
                frmttadmin.settrangthaibutton(false, true, false);
                ancontrols();
            }
            else
            {
                frmttadmin.Activate();
            }
        }
        private void xóaThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttadmin == null || frmttadmin.IsDisposed)
            {
                MDI();
                frmttadmin.settrangthaibutton(false, false, true);
                ancontrols();
            }
            else
            {
                frmttadmin.Activate();
            }
        }
        private void Frm_TTADMIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            pnl_title.Visible = true;
            grp_trangthai.Visible = true;
            grp_TraCu.Visible = true;
            ppnl_tiltle1.Visible = true;
            dgv_dstaikhoan.Visible = true;
            Frm_Admin_Load(sender, e);
        }
        //-------------Đổ Dữ Liệu-----------------
        private void Frm_Admin_Load(object sender, EventArgs e)
        {
            btn_load.Visible = false;
            LoadComboBox();
            thongke();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel ="SELECT MaTaiKhoan, TenDangNhap, Email, Quyen, TrangThai, FORMAT(NgayTao, 'dd-MM-yyyy') AS NgayTao, MaCuDan, MaNhanVien FROM TaiKhoanNguoiDung";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dstaikhoan.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if(txt_mtk.Text.Trim() == "" && txt_tentk.Text.Trim() == "" && cbx_trangthai.SelectedIndex == 0 && cbx_quyen.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tiemkiem();
                btn_load.Visible = true;
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            txt_mtk.Clear();
            txt_tentk.Clear();
            cbx_quyen.SelectedIndex = 0;
            cbx_trangthai.SelectedIndex = 0;
            LoadFullTaiKhoan();
            btn_load.Visible = false;
        }
    }
}
