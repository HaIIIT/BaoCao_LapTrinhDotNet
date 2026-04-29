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
    public partial class Frm_CSKH : Form
    {
        private Frm_thongtincskh frmThongtincskh = null;
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        public Frm_CSKH()
        {
            InitializeComponent();
        }
        public Frm_CSKH(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm sử dụng chung
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
        private void MDI()
        {
            AnTatCaFormCon();
            frmThongtincskh = new Frm_thongtincskh();
            frmThongtincskh.MdiParent = this;
            frmThongtincskh.StartPosition = FormStartPosition.Manual;
            frmThongtincskh.Location = new Point(170, 130);
            frmThongtincskh.FormBorderStyle = FormBorderStyle.None;
            frmThongtincskh.FormClosed += frmThongtincskh_FormClosed;
            frmThongtincskh.Show();
        }
        private void ancontrols()
        {
            gpb_trangthai.Visible = false;
            gpb_timkiem.Visible = false;
            pnl_titlelist.Visible = false;
            pnl_titleyc.Visible = false;
            dgv_ttcskh.Visible = false;
        }
        private void hiencontrols()
        {
            gpb_trangthai.Visible = true;
            gpb_timkiem.Visible = true;
            pnl_titlelist.Visible = true;
            pnl_titleyc.Visible = true;
            dgv_ttcskh.Visible = true;
        }
        void load_dgv()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaYeuCau, MaCuDan, TieuDe, NoiDung, LoaiYeuCau, MucDoUuTien, NgayGui, TrangThai FROM CSKH WHERE 1=1";
                if (cls_chcecklogin.Quyen == 6)
                {
                    sel += " AND MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                }
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                dgv_ttcskh.DataSource = tb;
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string dk = "";
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        dk = " AND MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                    }
                    string sel = "SELECT COUNT(*) FROM CSKH WHERE 1=1" + dk;
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read()) lbl_tongyc.Text = rdr[0].ToString();
                    rdr.Close();
                    string sel1 = "SELECT COUNT(*) FROM CSKH WHERE LoaiYeuCau = N'Khiếu Nại'" + dk;
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read()) lbl_tongkn.Text = rdr1[0].ToString();
                    rdr1.Close();
                    string sel2 = "SELECT COUNT(*) FROM CSKH WHERE LoaiYeuCau = N'Góp Ý'" + dk;
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read()) lbl_tonggy.Text = rdr2[0].ToString();
                    rdr2.Close();
                    string sel3 = "SELECT COUNT(*) FROM CSKH WHERE LoaiYeuCau = N'Hỗ Trợ'" + dk;
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read()) lbl_tonght.Text = rdr3[0].ToString();
                    rdr3.Close();
                    string sel4 = "SELECT COUNT(*) FROM CSKH WHERE LoaiYeuCau = N'Phản Ánh'" + dk;
                    SqlDataReader rdr4 = ketnoi.truyvan(sel4);
                    if (rdr4.Read()) lbl_tongpa.Text = rdr4[0].ToString();
                    rdr4.Close();
                    string sel5 = "SELECT COUNT(*) FROM CSKH WHERE TrangThai = N'Đang Xử Lý'" + dk;
                    SqlDataReader rdr5 = ketnoi.truyvan(sel5);
                    if (rdr5.Read()) lbl_tongcgq.Text = rdr5[0].ToString();
                    rdr5.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void chk_ngay_CheckedChanged_1(object sender, EventArgs e)
        {
            dtp_ngaygui.Enabled = chk_ngay.Checked;
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaYeuCau, MaCuDan, TieuDe, NoiDung, LoaiYeuCau, MucDoUuTien, NgayGui, TrangThai FROM CSKH WHERE 1=1";
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        sel += " AND MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                    }
                    if (!string.IsNullOrEmpty(txt_myc.Text))
                        sel += " AND MaYeuCau LIKE N'%" + txt_myc.Text.Trim() + "%'";
                    if (chk_ngay.Checked)
                        sel += " AND CONVERT(date, NgayGui) = '" + dtp_ngaygui.Value.ToString("yyyy-MM-dd") + "'";
                    if (rdb_kn.Checked) sel += " AND LoaiYeuCau = N'Khiếu Nại'";
                    else if (rdb_gy.Checked) sel += " AND LoaiYeuCau = N'Góp Ý'";
                    else if (rdb_ht.Checked) sel += " AND LoaiYeuCau = N'Hỗ Trợ'";
                    else if (rdb_pa.Checked) sel += " AND LoaiYeuCau = N'Phản Ánh'";
                    if (rdb_cxl.Checked) sel += " AND TrangThai = N'Chờ Xử Lý'";
                    else if (rdb_dxl.Checked) sel += " AND TrangThai = N'Đang Xử Lý'";
                    else if (rdb_dht.Checked) sel += " AND TrangThai = N'Đã Hoàn Tất'";
                    else if (rdb_tc.Checked) sel += " AND TrangThai = N'Từ Chối'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgv_ttcskh.DataSource = tb;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //----------------MenuStrip---------------------
        private void themyctool_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            { 
                MDI();
                frmThongtincskh.settrangthaibutton(true, false, false);
                // 
                ancontrols();
            }
            else
            {
                frmThongtincskh.Activate();
            }
        }
        private void suayctool_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            {
                
                MDI();
                frmThongtincskh.settrangthaibutton(false, true, false);
                // 
                ancontrols();
            }
            else
            {
                frmThongtincskh.Activate();
            }
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            {
                
                MDI();
                frmThongtincskh.settrangthaibutton(false, true, false);
                // 
                ancontrols();
            }
            else
            {
                frmThongtincskh.Activate();
            }
        }
        private void frmThongtincskh_FormClosed(object sender, FormClosedEventArgs e) {
            hiencontrols();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
        }
        //-----------------------------------------
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
            Frm_CuDan cudan = new Frm_CuDan(menu);
            cudan.Show();
            this.Close();
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo(menu);
            canho.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoadon = new Frm_HoaDon(menu);
            hoadon.Show();
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
            Frm_CongNo congno = new Frm_CongNo(menu);
            congno.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongketc = new Frm_ThongKeTaiChinh(menu);
            thongketc.Show();
            this.Close();
        }
        private void btn_cskh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hiện đang ở trang CSKH!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(menu);
            dkdv.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua btsc = new Frm_BaoTriSuaChua(menu);
            btsc.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baixe = new Frm_BaiXe(menu);
            baixe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong = new Frm_ChamCong(menu);
            chamcong.Show();
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
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //-------------------------------
        private void Frm_CSKH_Load(object sender, EventArgs e)
        {
            dtp_ngaygui.Enabled = false;
            btn_load.Visible = false;
            load_dgv();
            thongke();
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongketc, btn_btsc);
            }else if (quyen == 5)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc);
            }else if (quyen == 7)
            {
                //null
            }

        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_myc.Text)
                && !rdb_kn.Checked && !rdb_gy.Checked && !rdb_ht.Checked && !rdb_pa.Checked
                && !rdb_cxl.Checked && !rdb_dxl.Checked && !rdb_dht.Checked && !rdb_tc.Checked)
            {
                MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm!","Hệ Thống Quản Lý chung Cư - Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                timkiem();
                btn_load.Visible = true;
            }
                
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            txt_myc.Clear();
            rdb_kn.Checked = false;
            rdb_gy.Checked = false;
            rdb_ht.Checked = false;
            rdb_pa.Checked = false;
            rdb_cxl.Checked = false;
            rdb_dxl.Checked = false;
            rdb_dht.Checked = false;
            rdb_tc.Checked = false;
            Frm_CSKH_Load(sender, e);
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                AnTatCaFormCon();
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                ancontrols();
                //
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
            hiencontrols();
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                AnTatCaFormCon();
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                ancontrols();
            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmxacthuc = null;
            hiencontrols();
        }
    }
}
