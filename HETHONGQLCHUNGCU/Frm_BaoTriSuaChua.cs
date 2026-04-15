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
    public partial class Frm_BaoTriSuaChua : Form
    {
        private frm_btsc frmbtsc = null;
        public Frm_Menu menu;
        public Frm_BaoTriSuaChua()
        {
            InitializeComponent();
        }
        public Frm_BaoTriSuaChua(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI()
        {
            frmbtsc = new frm_btsc();
            frmbtsc.MdiParent = this;
            frmbtsc.StartPosition = FormStartPosition.Manual;
            frmbtsc.Location = new Point(175, 140);
            frmbtsc.FormBorderStyle = FormBorderStyle.None;
            frmbtsc.FormClosed += Frmbtsc_FormClosed;
            frmbtsc.Show();
        }
        private void ancontrols()
        {
            pnl_title.Visible = false;
            pnl_title2.Visible = false;
            dgv_ThongTinBt.Visible = false;
            grp_ThonTinBaoTri.Visible = false;
            grp_TraCuBaoTri.Visible = false;
        }
        //----------------MenuStrip---------------------
        private void themthongtinbaotrotool_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void cậpNhậtThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void xóaThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void Frmbtsc_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_title.Visible = true;
            pnl_title2.Visible = true;
            dgv_ThongTinBt.Visible = true;
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
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
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(menu);
            dkdv.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang Bảo trì - Sửa chữa!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }  
}
