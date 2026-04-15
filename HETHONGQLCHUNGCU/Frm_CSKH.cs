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
    public partial class Frm_CSKH : Form
    {
        private Frm_thongtincskh frmThongtincskh = null;
        public Frm_Menu menu;
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
        private void MDI()
        {
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
        //----------------MenuStrip---------------------
        private void themyctool_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            {
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
            gpb_trangthai.Visible = true;
            gpb_timkiem.Visible = true;
            pnl_titlelist.Visible = true;
            pnl_titleyc.Visible = true;
            dgv_ttcskh.Visible = true;
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
    }
}
