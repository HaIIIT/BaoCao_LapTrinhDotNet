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
    public partial class Frm_CuDan : Form
    {
        public Frm_Menu menu;
        private Frm_ThongTinCuDan frmThongTinCuDan = null;
        public Frm_CuDan()
        {
            InitializeComponent();
        }        
        public Frm_CuDan(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        private void Frm_CuDan_Load(object sender, EventArgs e)
        {

        }
        private void thêmCưDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                frmThongTinCuDan = new Frm_ThongTinCuDan();
                frmThongTinCuDan.MdiParent = this;
                frmThongTinCuDan.StartPosition = FormStartPosition.Manual;
                frmThongTinCuDan.Location = new Point(324, 150);
                frmThongTinCuDan.FormBorderStyle = FormBorderStyle.None;
                frmThongTinCuDan.FormClosed += FrmThongTinCuDan_FormClosed;
                frmThongTinCuDan.Show();
                frmThongTinCuDan.settrangthaibutton(true, false, false);
                //ẩn controls 
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
                dgv_thongtincudan.Visible = false;
                pnl_title.Visible = false;
            }
            else
            {
                frmThongTinCuDan.Activate();
            }
        }
        private void cậpNhậtThôngTinCưDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                frmThongTinCuDan = new Frm_ThongTinCuDan();
                frmThongTinCuDan.MdiParent = this;
                frmThongTinCuDan.StartPosition = FormStartPosition.Manual;
                frmThongTinCuDan.Location = new Point(324, 150);
                frmThongTinCuDan.FormBorderStyle = FormBorderStyle.None;
                frmThongTinCuDan.FormClosed += FrmThongTinCuDan_FormClosed;
                frmThongTinCuDan.Show();
                frmThongTinCuDan.settrangthaibutton(false, true, false);
                //ẩn controls 
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
                dgv_thongtincudan.Visible = false;
                pnl_title.Visible = false;
            }
            else
            {
                frmThongTinCuDan.Activate();
            }
        }

        private void xóaTHÔToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                frmThongTinCuDan = new Frm_ThongTinCuDan();
                frmThongTinCuDan.MdiParent = this;
                frmThongTinCuDan.StartPosition = FormStartPosition.Manual;
                frmThongTinCuDan.Location = new Point(324, 150);
                frmThongTinCuDan.FormBorderStyle = FormBorderStyle.None;
                frmThongTinCuDan.FormClosed += FrmThongTinCuDan_FormClosed;
                frmThongTinCuDan.Show();
                frmThongTinCuDan.settrangthaibutton(false, false, true);
                //ẩn controls 
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
                dgv_thongtincudan.Visible = false;
                pnl_title.Visible = false;
            }
            else
            {
                frmThongTinCuDan.Activate();    
            }
        }
        private void FrmThongTinCuDan_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
            dgv_thongtincudan.Visible = true;
            pnl_title.Visible = true;
        }
        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        { if (menu != null)
            {
                menu.Show();
            } this.Close();
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
            MessageBox.Show("Bạn đang ở trang Cư Dân!!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_canho_Click(object sender, EventArgs e)
        {           
            Frm_CanHo frmCanHo = new Frm_CanHo(menu);
            frmCanHo.Show();
            this.Close();
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon frmHoaDon = new Frm_HoaDon(menu);
            frmHoaDon.Show();
            this.Close();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT frmThanhToan = new Frm_TT(menu);
            frmThanhToan.Show();
            this.Close();
        }

        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo frmCongNo = new Frm_CongNo(menu);
            frmCongNo.Show();
            this.Close();
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh frmThongKe = new Frm_ThongKeTaiChinh(menu);
            frmThongKe.Show();
            this.Close();
        }

        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH frmcskh = new Frm_CSKH(menu);
            frmcskh.Show();
            this.Close();
        }

        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu frmDangKyDichVu = new frm_Dangkydichvu(menu);
            frmDangKyDichVu.Show();
            this.Close();
        }

        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaotruSuachua frmBaoTriSuaChua = new Frm_BaotruSuachua(menu);
            frmBaoTriSuaChua.Show();
            this.Close();
        }

        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe frmBaiXe = new Frm_BaiXe(menu);
            frmBaiXe.Show();
            this.Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong frmChamCong = new Frm_ChamCong(menu);
            frmChamCong.Show();
            this.Close();
        }

        private void btn_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV frmPhanCong = new Frm_BPCNV(menu);
            frmPhanCong.Show();
            this.Close();
        }

        private void btn_bangdanhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu frmBangDanhGia = new frm_DanhGiaNhanSu();
            frmBangDanhGia.Show(menu);
            this.Close();
        }
    }
}
