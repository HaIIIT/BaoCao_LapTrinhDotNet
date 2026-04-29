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
    public partial class frm_Dangkydichvu : Form
    {
        private frm_dkdv frmDangKyDichVu = null;
        private Frm_ThemDMDV_DKDV frmdmdv = null;
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_TTDV_DKDV_CUDAN frmdichvu = null;
        public frm_Dangkydichvu()
        {
            InitializeComponent();
        }
        public frm_Dangkydichvu(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
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
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void MDI1()
        {
            frmDangKyDichVu = new frm_dkdv();
            frmDangKyDichVu.MdiParent = this;
            frmDangKyDichVu.StartPosition = FormStartPosition.Manual;
            frmDangKyDichVu.Location = new Point(178, 105);
            frmDangKyDichVu.FormBorderStyle = FormBorderStyle.None;
            frmDangKyDichVu.FormClosed += frmDangKyDichVu_FormClosed;
            frmDangKyDichVu.Show();
        }
        private void MDI2()
        {
            frmdmdv = new Frm_ThemDMDV_DKDV();
            frmdmdv.MdiParent = this;
            frmdmdv.StartPosition = FormStartPosition.Manual;
            frmdmdv.Location = new Point(270, 150);
            frmdmdv.FormBorderStyle = FormBorderStyle.None;
            frmdmdv.FormClosed += frmdmdv_FormClosed;
            frmdmdv.Show();
        }
        private void ancontrols()
        {
            pnl_titel1.Visible = false;
            grp_ThonTinDangKy.Visible = false;
            grp_TraCuDichVu.Visible = false;
            pnl_tiltel2.Visible = false;
            grb_dsdkdv.Visible = false;
            grb_dsdvti.Visible = false;
        }
        void ThongKe()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi()) { 
                    // 1. Lấy tổng số đăng ký dịch vụ
                    string sel = "SELECT COUNT(*) FROM DangKiDichVu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tongdv.Text = rdr[0].ToString();
                    }rdr.Close();
                    // 2. Lấy tổng số dịch vụ hiện có
                    string sel1 = "SELECT COUNT(*) FROM DangKiDichVu WHERE TrangThai=N'Chờ Duyệt'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_dkm.Text = rdr1[0].ToString();
                    }rdr1.Close();
                    // 3. Lấy số dịch vụ đang hoạt động
                    string sel2 = "SELECT COUNT(*) FROM DanhMucDichVu";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_ti.Text = rdr2[0].ToString();
                    }rdr2.Close();
                    // 4. Lấy số dịch vụ ngưng hoạt động
                    string sel3 = "SELECT COUNT(*) FROM DanhMucDichVu WHERE TrangThai=N'Đang Cung Cấp'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_tidhd.Text = rdr3[0].ToString();
                    }rdr3.Close();
                    string sel4 = "SELECT COUNT(*) FROM DanhMucDichVu WHERE TrangThai=N'Ngưng Cung Cấp'";
                    SqlDataReader rdr4 = ketnoi.truyvan(sel4);
                    if (rdr4.Read())
                    {
                        lbl_tinhd.Text = rdr4[0].ToString();
                    }rdr4.Close();
                }ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message,"Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void tiemkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaDangKy, MaCanHo, TrangThai FROM DangKiDichVu WHERE 1=1";
                    string sel1 = "SELECT MaDichVu, TrangThai, TenDichVu FROM DanhMucDichVu WHERE 1=1";
                    if (txt_mdk.Text.Trim()!="" || txt_mch.Text.Trim()!="" || cbx_ttdk.SelectedIndex > 0)
                    {
                        if (!string.IsNullOrEmpty(txt_mdk.Text.Trim()))
                        {
                            sel += " AND MaDangKy LIKE N'%" + txt_mdk.Text.Trim() + "%'";
                        }
                        if (!string.IsNullOrEmpty(txt_mch.Text.Trim()))
                        {
                            sel += " AND MaCanHo LIKE N'%" + txt_mch.Text.Trim() + "%'";
                        }
                        if (cbx_ttdk.SelectedIndex > 0) { 
                            sel+= " AND TrangThai=N'"+cbx_ttdk.Text.ToString()+"'";
                        }
                        SqlDataReader rdr = ketnoi.truyvan(sel);
                        DataTable tb = new DataTable();
                        tb.Load(rdr);
                        rdr.Close();
                        dgv_dsdkdv.DataSource = tb;
                        ketnoi.dongketnoi();
                    }
                    else if(txt_mdv.Text.Trim() != "" || txt_tendv.Text.Trim() != "" || cbx_ttdv.SelectedIndex > 0 ){
                        if (!string.IsNullOrEmpty(txt_mdv.Text.Trim()))
                        {
                            sel1 += " AND MaDichVu LIKE N'%" + txt_mdv.Text.Trim() + "%'";
                        }
                        if (!string.IsNullOrEmpty(txt_tendv.Text.Trim()))
                        {
                            sel1 += " AND TenDichVu LIKE N'%" + txt_tendv.Text.Trim() + "%'";
                        }
                        if (cbx_ttdv.SelectedIndex > 0)
                        {
                            sel1 += " AND TrangThai=N'" + cbx_ttdv.Text.ToString() + "'";
                        }
                        SqlDataReader rdr = ketnoi.truyvan(sel1);
                        DataTable tb = new DataTable();
                        tb.Load(rdr);
                        rdr.Close();
                        dgv_dsdmdv.DataSource = tb;
                        ketnoi.dongketnoi();
                    }                               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //----------------MenuStrip---------------------
        private void dangkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {
                MDI1();
                frmDangKyDichVu.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void sửaĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {

                MDI1();
                frmDangKyDichVu.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void xóaĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {
                MDI1();
                frmDangKyDichVu.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void frmDangKyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangKyDichVu = null;
            if (cls_chcecklogin.Quyen == 6)
            {
                if (frmdichvu != null && !frmdichvu.IsDisposed)
                {
                    frmdichvu.Show();
                    frmdichvu.BringToFront();
                }
            }
            else
            {
                frmxacthuc = null;
                pnl_titel1.Visible = true;
                grp_ThonTinDangKy.Visible = true;
                grp_TraCuDichVu.Visible = true;
                pnl_tiltel2.Visible = true;
                grb_dsdkdv.Visible = true;
                grb_dsdvti.Visible = true;
            }
        }
        private void thêmDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void sửaDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void xóaDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void frmdmdv_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_titel1.Visible = true;
            grp_ThonTinDangKy.Visible = true;
            grp_TraCuDichVu.Visible = true;
            pnl_tiltel2.Visible = true;
            grb_dsdkdv.Visible = true;
            grb_dsdvti.Visible = true;
        }
        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(240, 100);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                frmttcanhan.Show();
                //ẩn contorls              
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmdichvu != null && !frmdichvu.IsDisposed)
                    {
                        frmdichvu.Hide();
                    }
                }
                else
                {
                    ancontrols();
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
                if (frmdichvu != null && !frmdichvu.IsDisposed)
                {
                    frmdichvu.Show();
                    frmdichvu.BringToFront();
                }
            }
            else
            {
                frmttcanhan = null;
                pnl_titel1.Visible = true;
                grp_ThonTinDangKy.Visible = true;
                grp_TraCuDichVu.Visible = true;
                pnl_tiltel2.Visible = true;
                grb_dsdkdv.Visible = true;
                grb_dsdvti.Visible = true;
            }
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
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmdichvu != null && !frmdichvu.IsDisposed)
                    {
                        frmdichvu.Hide();
                    }
                }
                else
                {
                    ancontrols();
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
                if (frmdichvu != null && !frmdichvu.IsDisposed)
                {
                    frmdichvu.Show();
                    frmdichvu.BringToFront();
                }
            }
            else
            {
                frmxacthuc = null;
                pnl_titel1.Visible = true;
                grp_ThonTinDangKy.Visible = true;
                grp_TraCuDichVu.Visible = true;
                pnl_tiltel2.Visible = true;
                grb_dsdkdv.Visible = true;
                grb_dsdvti.Visible = true;
            }
        }
        //-----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
        }
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
            Frm_CuDan cudan = new Frm_CuDan(menu);
            cudan.Show();
            this.Close();
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canHo = new Frm_CanHo(menu);
            canHo.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoaDon = new Frm_HoaDon(menu);
            hoaDon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
            this.Close();
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(menu);
            thongKeTaiChinh.Show();
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
            MessageBox.Show("Bạn hiện đang ở trang Đăng Ký Dịch Vụ!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);       
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(menu);
            baiXe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(menu);
            chamCong.Show();
            this.Close();
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(menu);
            danhGiaNhanSu.Show();
            this.Close();
        }
        //-----------------------------------------
        private void frm_Dangkydichvu_Load(object sender, EventArgs e)
        {
            //phân quyền
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongketc, btn_btsc);
                AnTatCaFormCon();
                điềuChỉnhDịchVụToolStripMenuItem.Visible = false;
                frmdichvu = new Frm_TTDV_DKDV_CUDAN();
                frmdichvu.MdiParent = this;
                frmdichvu.StartPosition = FormStartPosition.Manual;
                frmdichvu.Location = new Point(280, 155);
                frmdichvu.FormBorderStyle = FormBorderStyle.None;
                frmdichvu.Show();
                //ẩn contorls
                ancontrols();
            }
            else if (quyen == 7)
            {
                //null
            }else if (quyen == 5)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc);
            }
            ThongKe();
            //gán dữ liệu combobox
            cbx_ttdk.Items.Clear();
            cbx_ttdk.Items.Add("--Chọn Trạng Thái Đăng Ký--");
            cbx_ttdk.Items.Add("Đang Sử Dụng");
            cbx_ttdk.Items.Add("Đã Hết Hạn");
            cbx_ttdk.Items.Add("Chờ Xử Lý");
            cbx_ttdk.SelectedIndex = 0;
            cbx_ttdv.Items.Clear();
            cbx_ttdv.Items.Add("--Chọn Trạng Thái Dịch Vụ--");
            cbx_ttdv.Items.Add("Đang Cung Cấp");
            cbx_ttdv.Items.Add("Ngưng Cung Cấp");
            cbx_ttdv.SelectedIndex = 0;
            btn_load.Visible = false;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql1 = "SELECT * FROM DangKiDichVu";
                    SqlDataReader rdr1 = ketnoi.truyvan(sql1);
                    DataTable tb1 = new DataTable();
                    tb1.Load(rdr1);
                    rdr1.Close();
                    dgv_dsdkdv.DataSource = tb1;
                    string sql2 = "SELECT * FROM DanhMucDichVu";
                    SqlDataReader rdr2 = ketnoi.truyvan(sql2);
                    DataTable tb2 = new DataTable();
                    tb2.Load(rdr2);
                    rdr2.Close();
                    dgv_dsdmdv.DataSource = tb2;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (txt_mch.Text.Trim() == "" && txt_mdk.Text.Trim() == "" && txt_mdv.Text.Trim() == "" && txt_tendv.Text.Trim() == "" && cbx_ttdk.SelectedIndex == 0 && cbx_ttdv.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một tiêu chí tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            frm_Dangkydichvu_Load(sender, e);
            txt_mch.Clear();
            txt_mdk.Clear();
            txt_mdv.Clear();
            txt_tendv.Clear();
            cbx_ttdk.SelectedIndex = 0;
            cbx_ttdv.SelectedIndex = 0;
        }
    }    
}
