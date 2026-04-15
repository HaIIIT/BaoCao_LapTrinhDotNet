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
    public partial class frm_Dangkydichvu : Form
    {
        private frm_dkdv frmDangKyDichVu = null;
        private Frm_ThemDMDV_DKDV frmdmdv = null;
        public Frm_Menu menu;
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
        private void MDI1()
        {
            frmDangKyDichVu = new frm_dkdv();
            frmDangKyDichVu.MdiParent = this;
            frmDangKyDichVu.StartPosition = FormStartPosition.Manual;
            frmDangKyDichVu.Location = new Point(170, 100);
            frmDangKyDichVu.FormBorderStyle = FormBorderStyle.None;
            frmDangKyDichVu.FormClosed += frmDangKyDichVu_FormClosed;
            frmDangKyDichVu.Show();
        }
        private void MDI2()
        {
            frmdmdv = new Frm_ThemDMDV_DKDV();
            frmdmdv.MdiParent = this;
            frmdmdv.StartPosition = FormStartPosition.Manual;
            frmdmdv.Location = new Point(170, 100);
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
            pnl_titel1.Visible = true;
            grp_ThonTinDangKy.Visible = true;
            grp_TraCuDichVu.Visible = true;
            pnl_tiltel2.Visible = true;
            grb_dsdkdv.Visible = true;
            grb_dsdvti.Visible = true;
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
    }
}
