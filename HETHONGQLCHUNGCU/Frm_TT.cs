using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TT : Form
    {
        public Frm_Menu menu;
        private Frm_ThanhToan Frm_ThanhToan = null;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_TTThanhToan_CuDan frmthanhtoan = null;
        public Frm_TT()
        {
            InitializeComponent();
        }
        public Frm_TT(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //Xây dựng hàm dùng chung
        private void MDI()
        {
            Frm_ThanhToan = new Frm_ThanhToan();
            Frm_ThanhToan.MdiParent = this;
            Frm_ThanhToan.StartPosition = FormStartPosition.Manual;
            Frm_ThanhToan.Location = new Point(175, 140);
            Frm_ThanhToan.FormBorderStyle = FormBorderStyle.None;
            Frm_ThanhToan.FormClosed += Frm_HD_FormClosed;
            Frm_ThanhToan.Show();
        }
        private void ancontrols()
        {
            grp_trangthai.Visible = false;
            pnlTKTT.Visible = false;
            gbxTCTTTT.Visible = false;
            pnlDSTT.Visible = false;
            dgvDSTT.Visible = false;
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
        void LoadThongKe()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM ThanhToan";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_4.Text = rdr[0].ToString();
                    }
                    rdr.Close();

                    string sel1 = "SELECT COUNT(*) FROM ThanhToan WHERE TrangThai =N'Đã Thanh Toán'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_1.Text = rdr1[0].ToString();
                    }
                    rdr1.Close();

                    string sel2 = "SELECT COUNT(*) FROM ThanhToan WHERE TrangThai =N'Chưa Thanh Toán'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_2.Text = rdr2[0].ToString();
                    }
                    rdr2.Close();

                    string sel3 = "SELECT COUNT(*) FROM ThanhToan WHERE TrangThai =N'Chờ Xử Lý'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_3.Text = rdr3[0].ToString();
                    }
                    rdr3.Close();
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
                    string sel = "SELECT MaThanhToan, MaHoaDon,NgayThanhToan,SoTien, PhuongThuc, NoiDung, NguoiThu, GhiChu FROM ThanhToan WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_tt.Text.Trim()))
                    {
                        sel += " AND MaThanhToan LIKE N'%" + txt_tt.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_hd.Text.Trim()))
                    {
                        sel += " AND MaHoaDon LIKE N'%" + txt_hd.Text.Trim() + "%'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSTT.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //----------------MenuStrip---------------------
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_ThanhToan == null || Frm_ThanhToan.IsDisposed)
            {
                MDI();
                Frm_ThanhToan.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_ThanhToan.Activate();
            }
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_ThanhToan == null || Frm_ThanhToan.IsDisposed)
            {
                MDI();
                Frm_ThanhToan.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_ThanhToan.Activate();
            }
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_ThanhToan == null || Frm_ThanhToan.IsDisposed)
            {
                MDI();
                Frm_ThanhToan.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_ThanhToan.Activate();
            }
        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ThanhToan = null;
            grp_trangthai.Visible = true;
            pnlTKTT.Visible = true;
            gbxTCTTTT.Visible = true;
            pnlDSTT.Visible = true;
            dgvDSTT.Visible = true;
        }
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
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
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmthanhtoan != null && !frmthanhtoan.IsDisposed)
                    {
                        frmthanhtoan.Hide();
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
                if (frmthanhtoan != null && !frmthanhtoan.IsDisposed)
                {
                    frmthanhtoan.Show();
                    frmthanhtoan.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                Frm_ThanhToan = null;
                grp_trangthai.Visible = true;
                pnlTKTT.Visible = true;
                gbxTCTTTT.Visible = true;
                pnlDSTT.Visible = true;
                dgvDSTT.Visible = true;
            }
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (frmthanhtoan != null && !frmthanhtoan.IsDisposed)
                    {
                        frmthanhtoan.Hide();
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
                if (frmthanhtoan != null && !frmthanhtoan.IsDisposed)
                {
                    frmthanhtoan.Show();
                    frmthanhtoan.BringToFront();
                }
            }
            else
            {
                Frm_ThanhToan = null;
                grp_trangthai.Visible = true;
                pnlTKTT.Visible = true;
                gbxTCTTTT.Visible = true;
                pnlDSTT.Visible = true;
                dgvDSTT.Visible = true;
            }
        }
        //-----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(menu);
            cudan.Show();
            this.Close();
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo cudan = new Frm_CanHo(menu);
            cudan.Show();
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
            MessageBox.Show("Bạn hiện đang ở trang Thanh Toán!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(menu);
            congno.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(menu);
            congno.Show();
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
            Frm_BPCNV phancong = new Frm_BPCNV(menu);
            phancong.Show();
            this.Close();
        }
        private void btn_bdg_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //-------------------------------
        private void Frm_TT_Load(object sender, EventArgs e)
        {
            btn_load.Visible = false;
            LoadThongKe();
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongketc, btn_btsc);
                quảnLýThanhToánToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmthanhtoan = new Frm_TTThanhToan_CuDan();
                frmthanhtoan.MdiParent = this;
                frmthanhtoan.StartPosition = FormStartPosition.Manual;
                frmthanhtoan.Location = new Point(200, 115);
                frmthanhtoan.FormBorderStyle = FormBorderStyle.None;
                frmthanhtoan.Show();
                //ẩn contorls
                ancontrols();
            }
            else if (quyen == 7)
            {
                //null
            }
            else
            {
                if (quyen == 4)
                {
                    PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
                }
            }
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaThanhToan, MaHoaDon, NgayThanhToan, SoTien, NguoiThu, PhuongThuc,NoiDung, GhiChu FROM ThanhToan";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgvDSTT.DataSource = tb;
                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }
        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (txt_tt.Text.Trim() == "" && txt_hd.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Frm_TT_Load(sender, e);
            txt_hd.Clear();
            txt_tt.Clear();
        }

        
    }
}
