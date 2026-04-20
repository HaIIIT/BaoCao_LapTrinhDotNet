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
    public partial class Frm_CanHo : Form
    {        
        public Frm_Menu menu;
        private Frm_thongtincanho frmthongtincanho = null;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_QuanLyHopDong frmhopdong = null;
        private Frm_TTCanHo_CuDan frmcanho = null;
        public Frm_CanHo()
        {
            InitializeComponent();
        }       
        public Frm_CanHo(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        private void AnTatCaFormCon()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null && !frm.IsDisposed)
                {
                    frm.Close();
                }
            }
        }
        //xây dựng hàm cho grp
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM CanHo";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tong.Text = rdr[0].ToString();
                    }rdr.Close();

                    string sel1 = "SELECT COUNT(*) FROM CanHo WHERE TrangThai =N'Trống'";
                    SqlDataReader rdr1= ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_trong.Text = rdr1[0].ToString();
                    }rdr1 .Close();

                    string sel2 = "SELECT COUNT(*) FROM CanHo WHERE TrangThai =N'Đã Cho Thuê'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_dsd.Text = rdr2[0].ToString();
                    }rdr2 .Close();

                    string sel3 = "SELECT COUNT(*) FROM CanHo WHERE TrangThai =N'Đang Sửa Chữa'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_suachua.Text = rdr3[0].ToString();
                    }rdr3 .Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CanHo WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mch.Text))
                    {
                        sel += " AND MaCanHo LIKE N'%" + txt_mch.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_socan.Text))
                    {
                        sel += " AND SoCan LIKE N'%" + txt_socan.Text.Trim() + "%'";
                    }
                    if (cbx_tang.SelectedIndex > 0)
                    {
                        sel += " AND Tang =N'" + cbx_tang.SelectedIndex.ToString() + "'";
                    }
                    if (cbx_trangthai.SelectedIndex > 0)
                    {
                        sel += " AND TrangThai =N'" + cbx_trangthai.Text.Trim() + "'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_thongtincudan.DataSource = tb;                   
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------MenuStrip-----------------
        private void themcanho_Click(object sender, EventArgs e)
        {
            if (frmthongtincanho == null || frmthongtincanho.IsDisposed)
            {
                frmthongtincanho = new Frm_thongtincanho();
                frmthongtincanho.MdiParent = this;
                frmthongtincanho.StartPosition = FormStartPosition.Manual;
                frmthongtincanho.Location = new Point(164, 145);
                frmthongtincanho.FormBorderStyle = FormBorderStyle.None;
                frmthongtincanho.FormClosed += frmthongtincanho_FormClosed;
                frmthongtincanho.Show();
                frmthongtincanho.settrangthaibutton(true, false, false);
                //ẩn controls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
            }
            else
            {
                frmthongtincanho.Activate();
            }
        }
        private void capnhatthongtincanho_Click(object sender, EventArgs e)
        {
            if (frmthongtincanho == null || frmthongtincanho.IsDisposed)
            {
                frmthongtincanho = new Frm_thongtincanho();
                frmthongtincanho.MdiParent = this;
                frmthongtincanho.StartPosition = FormStartPosition.Manual;
                frmthongtincanho.Location = new Point(164, 145);
                frmthongtincanho.FormBorderStyle = FormBorderStyle.None;
                frmthongtincanho.FormClosed += frmthongtincanho_FormClosed;
                frmthongtincanho.Show();
                frmthongtincanho.settrangthaibutton(false, true, false);
                //ẩn controls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
            }
            else
            {
                frmthongtincanho.Activate();
            }
        }
        private void xoacanho_Click(object sender, EventArgs e)
        {
            if (frmthongtincanho == null || frmthongtincanho.IsDisposed)
            {
                frmthongtincanho = new Frm_thongtincanho();
                frmthongtincanho.MdiParent = this;
                frmthongtincanho.StartPosition = FormStartPosition.Manual;
                frmthongtincanho.Location = new Point(164, 145);
                frmthongtincanho.FormBorderStyle = FormBorderStyle.None;
                frmthongtincanho.FormClosed += frmthongtincanho_FormClosed;
                frmthongtincanho.Show();
                frmthongtincanho.settrangthaibutton(false, false, true);
                //ẩn controls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
            }
            else
            {
                frmthongtincanho.Activate();
            }
        }
        private void thongtintaikhoantool_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmcanho != null && !frmcanho.IsDisposed)
                    {
                        frmcanho.Hide();
                    }
                }
                else
                {
                    pnl_data.Visible = false;
                    pnl_title.Visible = false;
                    grp_BoLoc.Visible = false;
                    grp_trangthai.Visible = false;
                }
                    frmttcanhan.Show();
            }
            else
            {
                frmttcanhan.Activate();
            }
        }
        private void Frm_Thongtintaikhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmttcanhan = null;
            if (cls_chcecklogin.Quyen == 6)
            {
                if (frmcanho != null && !frmcanho.IsDisposed)
                {
                    frmcanho.Show();
                    frmcanho.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                pnl_data.Visible = true;
                pnl_title.Visible = true;
                grp_BoLoc.Visible = true;
                grp_trangthai.Visible = true;
            } 
        }
        private void frmthongtincanho_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện lại controls khi form thông tin căn hộ đóng
            pnl_data.Visible = true;
            pnl_title.Visible = true;
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuấtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(menu != null){
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
        }
        private void quảnLýHợpĐồngThuêMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmhopdong == null || frmhopdong.IsDisposed)
            {
                frmhopdong = new Frm_QuanLyHopDong();
                frmhopdong.MdiParent = this;
                frmhopdong.StartPosition = FormStartPosition.Manual;
                frmhopdong.Location = new Point(170, 125);
                frmhopdong.FormBorderStyle = FormBorderStyle.None;
                frmhopdong.FormClosed += frmhopdong_FormClosed;
                frmhopdong.Show();
                //ẩn contorls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
            }
            else
            {
                frmhopdong.Activate();
            }
        }
        private void frmhopdong_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_data.Visible = true;
            pnl_title.Visible = true;
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
        }
        //----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan frm_CuDan = new Frm_CuDan(menu);
            frm_CuDan.Show();
            this.Close();
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang Căn Hộ!!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon frmHoaDon = new Frm_HoaDon(menu);
            frmHoaDon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoadon = new Frm_HoaDon(menu);
            hoadon.Show();
            this.Close();
        }
        private void bbtn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }       
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongke = new Frm_ThongKeTaiChinh(menu);
            thongke.Show();
            this.Close();
        }
        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(menu);
            cskh.Show();
            this.Close();
        }
        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdichvu = new frm_Dangkydichvu(menu);
            dkdichvu.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baixe = new Frm_BaiXe(menu);
            baixe.Show();
            this.Close();
        }
        private void bt_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong  = new Frm_ChamCong(menu);
            chamcong.Show();
            this.Close();
        }
        private void btn_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bangphancong = new Frm_BPCNV(menu);   
            bangphancong.Show();
            this.Close();
        }
        private void btn_bangdanhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //-------------Đổ Dữ Liệu----------------
        private void Frm_CanHo_Load(object sender, EventArgs e)
        {
            thongke();
            //cbx
            cbx_tang.Items.Clear();
            cbx_tang.Items.Add("--Chọn Tầng--");
            cbx_tang.Items.Add("1");
            cbx_tang.Items.Add("2");
            cbx_tang.Items.Add("3");
            cbx_tang.Items.Add("4");
            cbx_tang.Items.Add("5");
            cbx_tang.Items.Add("6");
            cbx_tang.Items.Add("7");
            cbx_tang.Items.Add("8");
            cbx_tang.Items.Add("9");
            cbx_tang.Items.Add("10");
            cbx_tang.Items.Add("11");
            cbx_tang.Items.Add("12");
            cbx_tang.SelectedIndex = 0;
            cbx_trangthai.Items.Clear();
            cbx_trangthai.Items.Add("--Chọn Trạng Thái--");
            cbx_trangthai.Items.Add("Trống");
            cbx_trangthai.Items.Add("Đã Cho Thuê");
            cbx_trangthai.Items.Add("Đã Bán");
            cbx_trangthai.Items.Add("Đang Sửa Chữa");
            cbx_trangthai.SelectedIndex = 0;
            btn_load.Visible = false;
            //--------------Phân Quyền Chức năng---------------
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongketc, btn_btsc);
                toolStripMenuItem6.Visible = false;
                quảnLýHợpĐồngThuêMuaToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmcanho = new Frm_TTCanHo_CuDan();
                frmcanho.MdiParent = this;
                frmcanho.StartPosition = FormStartPosition.Manual;
                frmcanho.Location = new Point(170, 125);
                frmcanho.FormBorderStyle = FormBorderStyle.None;
                frmcanho.Show();
                //ẩn contorls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;              
            }
            else if (quyen == 7)
            {
                //null
            }
            //-----------------------------
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT * FROM CanHo";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgv_thongtincudan.DataSource = tb;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            Frm_CanHo_Load(sender, e);
            txt_mch.Clear();
            txt_socan.Clear();          
        }
        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (txt_mch.Text.Trim() == "" && txt_socan.Text.Trim() == "" && cbx_tang.SelectedIndex == 0 && cbx_trangthai.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một tiêu chí tìm kiếm!",
                    "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                timkiem();
                btn_load.Visible = true;
            }
        }
        private void doimatkhautool_Click(object sender, EventArgs e)
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
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmcanho != null && !frmcanho.IsDisposed)
                    {
                        frmcanho.Hide();
                    }
                }
                else
                {
                    pnl_data.Visible = false;
                    pnl_title.Visible = false;
                    grp_BoLoc.Visible = false;
                    grp_trangthai.Visible = false;
                }
                frmxacthuc.Show();
            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmxacthuc = null;
            if (cls_chcecklogin.Quyen == 6)
            {
                if (frmcanho != null && !frmcanho.IsDisposed)
                {
                    frmcanho.Show();
                    frmcanho.BringToFront();
                }
            }
            else
            {
                pnl_data.Visible = true;
                pnl_title.Visible = true;
                grp_BoLoc.Visible = true;
                grp_trangthai.Visible = true;
            }
        }
    }
}
