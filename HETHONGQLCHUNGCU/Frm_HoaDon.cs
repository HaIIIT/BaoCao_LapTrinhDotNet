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
    public partial class Frm_HoaDon : Form
    {
        public Frm_Menu menu;
        private Frm_HD Frm_HD = null;  
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_TTHD_CUDAN frmhoadon = null;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        public Frm_HoaDon()
        {
            InitializeComponent();
        }
        public Frm_HoaDon(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }

        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM HoaDon";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tong.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    string sel1 = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Đã Thanh Toán'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_dathanhtoan.Text = rdr1[0].ToString();
                    }
                    rdr1.Close();
                    string sel2 = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Chưa Thanh Toán'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_chuathanhtoan.Text = rdr2[0].ToString();
                    }
                    rdr2.Close();
                    string sel3 = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Chờ Xử Lý'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_ChoXuLy.Text = rdr3[0].ToString();
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
                    string sel = "SELECT MaHoaDon, MaCanHo, MaCTHD, Thang, Nam, NgayLap, HanThanhToan, FORMAT(TongTien, 'N0') AS TongTien, TrangThai, GhiChu FROM HoaDon WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mhd.Text.Trim()))
                    {
                        sel += " AND MaHoaDon LIKE N'%" + txt_mhd.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_mch.Text.Trim()))
                    {
                        sel += " AND MaCanHo LIKE N'%" + txt_mch.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_mcthd.Text.Trim()))
                    {
                        sel += " AND MaCTHD LIKE N'%" + txt_mcthd.Text.Trim() + "%'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSHD.DataSource = tb;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //xây dựng hàm dùng chung 
        private void MDI()
        {
            Frm_HD = new Frm_HD();
            Frm_HD.MdiParent = this;
            Frm_HD.StartPosition = FormStartPosition.Manual;
            Frm_HD.Location = new Point(174, 145);
            Frm_HD.FormBorderStyle = FormBorderStyle.None;
            Frm_HD.FormClosed += Frm_HD_FormClosed;
            Frm_HD.Show();
        }
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void ancontrols()
        {
            grp_trangthai.Visible = false;
            pnlTKHD.Visible = false;
            gbx_Tracuuthongtin.Visible = false;
            lblDSHD.Visible = false;
            pnlDSHD.Visible = false;
            dgvDSHD.Visible = false;
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
        //----------------MenuStrip---------------------   
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(true, false, false);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(false, true, false);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void xoathongtinhoadon(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(false, false, true);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_HD = null;
            gbx_Tracuuthongtin.Visible = true;
            lblDSHD.Visible = true;
            pnlDSHD.Visible = true;
            dgvDSHD.Visible = true;
            pnlTKHD.Visible = true;
        }
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
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
                    if (frmhoadon != null && !frmhoadon.IsDisposed)
                    {
                        frmhoadon.Hide();
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
                if (frmhoadon != null && !frmhoadon.IsDisposed)
                {
                    frmhoadon.Show();
                    frmhoadon.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                Frm_HD = null;
                gbx_Tracuuthongtin.Visible = true;
                lblDSHD.Visible = true;
                pnlDSHD.Visible = true;
                dgvDSHD.Visible = true;
                pnlTKHD.Visible = true;
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
                    if (frmhoadon != null && !frmhoadon.IsDisposed)
                    {
                        frmhoadon.Hide();
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
                if (frmhoadon != null && !frmhoadon.IsDisposed)
                {
                    frmhoadon.Show();
                    frmhoadon.BringToFront();
                }
            }
            else
            {
                Frm_HD = null;
                gbx_Tracuuthongtin.Visible = true;
                lblDSHD.Visible = true;
                pnlDSHD.Visible = true;
                dgvDSHD.Visible = true;
                pnlTKHD.Visible = true;
            }
        }
        //-----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (Menu != null)
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
            Frm_CanHo canho = new Frm_CanHo(menu);
            canho.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hiện đang ở trang Hóa Đơn!0", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoana = new Frm_TT(menu);
            thanhtoana.Show();
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
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_bdg_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //----------------------------------------
        private void Frm_HoaDon_Load(object sender, EventArgs e)
        {
            thongke();
            btn_load.Visible = false;
            //1.Phân Quyền Chức Năng
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongketc, btn_btsc);
                quảnLýThanhToánToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmhoadon = new Frm_TTHD_CUDAN();
                frmhoadon.MdiParent = this;
                frmhoadon.StartPosition = FormStartPosition.Manual;
                frmhoadon.Location = new Point(200, 135);
                frmhoadon.FormBorderStyle = FormBorderStyle.None;
                frmhoadon.Show();
                ancontrols();
            }
            else if (quyen == 7)
            {
                //null
            }else if (quyen == 4)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            }

            //kncsdl
            Connection ketnoi = new Connection();
            //mở kết nối
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaHoaDon, MaCanHo, MaCTHD, Thang, Nam, NgayLap, HanThanhToan, FORMAT(TongTien, 'N0') AS TongTien, TrangThai, GhiChu FROM HoaDon";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSHD.DataSource = tb;
                    //đóng kết nối
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Khong the ket noi CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if(txt_mch.Text.Trim()=="" && txt_mcthd.Text.Trim() == "" && txt_mhd.Text.Trim() == "")
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
        private void btn_load_Click(object sender, EventArgs e)
        {
            Frm_HoaDon_Load(sender, e);
        }

    }
}
