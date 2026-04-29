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
    public partial class frm_DanhGiaNhanSu : Form
    {
        private frm_dgns frmDanhGiaNhanSu = null;
        public Frm_Menu menu;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_TTDGNS_CUDAN frmdanhgia = null;
        public frm_DanhGiaNhanSu()
        {
            InitializeComponent();
        }
        public frm_DanhGiaNhanSu(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //Xây dựng hàm dùng chung
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
            frmDanhGiaNhanSu = new frm_dgns();
            frmDanhGiaNhanSu.MdiParent = this;
            frmDanhGiaNhanSu.StartPosition = FormStartPosition.Manual;
            frmDanhGiaNhanSu.Location = new Point(170, 150);
            frmDanhGiaNhanSu.FormBorderStyle = FormBorderStyle.None;
            frmDanhGiaNhanSu.FormClosed += frmDanhGiaNhanSu_FormClosed;
            frmDanhGiaNhanSu.Show();
        }
        private void ancontrols()
        {
            pnl_tiltle1.Visible = false;
            pnl_tiltle2.Visible = false;
            grp_ThongTinNhanSu.Visible = false;
            grp_TraCuNhanVien.Visible = false;
            dgv_ThongTinNs.Visible = false;
        }
        private void hiencontrols()
        {
            pnl_tiltle1.Visible = true;
            pnl_tiltle2.Visible = true;
            grp_ThongTinNhanSu.Visible = true;
            grp_TraCuNhanVien.Visible = true;
            dgv_ThongTinNs.Visible = true;
        }
        void trangthai()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM NhanSu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_1.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    string sel2 = "SELECT COUNT(*) FROM NhanSu WHERE TrangThai= N'Đang làm'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_2.Text = rdr2[0].ToString();
                    }
                    rdr2.Close();
                    string sel3 = "SELECT COUNT(*) FROM NhanSu WHERE TrangThai= N'Xin Nghỉ'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_3.Text = rdr3[0].ToString();
                    }
                    rdr3.Close();
                    string sel4 = "SELECT COUNT(*) FROM NhanSu WHERE TrangThai= N'Thử Việc'";
                    SqlDataReader rdr4 = ketnoi.truyvan(sel4);
                    if (rdr4.Read())
                    {
                        lbl_4.Text = rdr4[0].ToString();
                    }
                    rdr4.Close();
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
                    string sel = "SELECT MaDanhGia, MaNhanSu, KyDanhGia, DiemTacPhong, DiemThaiDo, DiemHieuSuat, TongDiem, NhanXet, XepLoai FROM DanhGiaNhanSu WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_msns.Text.Trim()))
                    {
                        sel += " AND MaNhanSu LIKE N'%" + txt_msns.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_htnv.Text.Trim()))
                    {
                        sel += " AND HoTen LIKE N'%" + txt_htnv.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_mdg.Text.Trim()))
                    {
                        sel += " AND MaDanhGia LIKE N'%" + txt_mdg.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_kdg.Text.Trim()))
                    {
                        sel += " AND KyDanhGia LIKE N'%" + txt_kdg.Text.Trim() + "%'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_ThongTinNs.DataSource = tb;
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
        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(true, false, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }                
        }
        private void cậpNhậtĐánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(false, true, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }
        }
        private void xóaĐánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(false, false, true);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }
        }
        private void frmDanhGiaNhanSu_FormClosed(object sender,FormClosedEventArgs e)
        {
            pnl_tiltle1.Visible = true;
            pnl_tiltle2.Visible = true;
            grp_ThongTinNhanSu.Visible = true;
            grp_TraCuNhanVien.Visible = true;
            dgv_ThongTinNs.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menu!= null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
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
                if (cls_chcecklogin.Quyen == 2)
                {
                    if (frmdanhgia != null && !frmdanhgia.IsDisposed)
                    {
                        frmdanhgia.Hide();
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
            if (cls_chcecklogin.Quyen == 2)
            {
                if (frmdanhgia == null || frmdanhgia.IsDisposed)
                {
                    frmdanhgia = new Frm_TTDGNS_CUDAN();
                    frmdanhgia.MdiParent = this;
                    frmdanhgia.StartPosition = FormStartPosition.Manual;
                    frmdanhgia.Location = new Point(165, 125);
                    frmdanhgia.FormBorderStyle = FormBorderStyle.None;
                    frmdanhgia.Show();
                }
                else
                {
                    frmdanhgia.Show();
                    frmdanhgia.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                hiencontrols();
            }
        }
        private void quênMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
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
                if (cls_chcecklogin.Quyen == 2)
                {
                    if (frmdanhgia != null && !frmdanhgia.IsDisposed)
                    {
                        frmdanhgia.Hide();
                        
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
            if (cls_chcecklogin.Quyen == 2)
            {
                if (frmdanhgia == null || frmdanhgia.IsDisposed)
                {
                    frmdanhgia = new Frm_TTDGNS_CUDAN();
                    frmdanhgia.MdiParent = this;
                    frmdanhgia.StartPosition = FormStartPosition.Manual;
                    frmdanhgia.Location = new Point(165, 125);
                    frmdanhgia.FormBorderStyle = FormBorderStyle.None;
                    frmdanhgia.Show();
                }
                else
                {
                    frmdanhgia.Show();
                    frmdanhgia.BringToFront();
                }
            }
            else
            {
                hiencontrols();
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
        private void btn_congnno_Click(object sender, EventArgs e)
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
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(menu);
            dkdv.Show();
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
            MessageBox.Show("Bạn đang ở trang đánh giá nhân sự!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //------------------
        private void frm_DanhGiaNhanSu_Load(object sender, EventArgs e)
        {
            trangthai();
            btn_load.Visible = false;
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 2)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                    btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
                bảngĐánhGiáNhânSựToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmdanhgia = new Frm_TTDGNS_CUDAN();
                frmdanhgia.MdiParent = this;
                frmdanhgia.StartPosition = FormStartPosition.Manual;
                frmdanhgia.Location = new Point(165, 125);
                frmdanhgia.FormBorderStyle = FormBorderStyle.None;
                frmdanhgia.Show();
                //ẩn contorls
                ancontrols();
            }
            else if (quyen == 7)
            {
                //null
            }
            else if (quyen == 3)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            }
                Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaDanhGia, MaNhanSu, KyDanhGia, DiemTacPhong, DiemHieuSuat, DiemThaiDo, TongDiem, NhanXet, XepLoai FROM DanhGiaNhanSu";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgv_ThongTinNs.DataSource = tb;
                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if(txt_htnv.Text.Trim()==""&&txt_mdg.Text.Trim()==""&& txt_msns.Text.Trim() == "" && txt_kdg.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 giá trị cần tìm!", "Hệ Thống Quản Lý Chung Cư - Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tiemkiem();
                btn_load.Visible = true;
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu_Load(sender, e);
            txt_htnv.Clear();
            txt_kdg.Clear();
            txt_mdg.Clear();
            txt_msns.Clear();
        }
        
    }
}
