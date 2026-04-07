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
    public partial class Frm_CanHo : Form
    {        
        public Frm_Menu menu;
        private Frm_thongtincanho frmthongtincanho = null;
        public Frm_CanHo()
        {
            InitializeComponent();
        }       
        public Frm_CanHo(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //bẫy sự kiện cho menustrip them, sua, xoa can ho
        private void themcanho_Click(object sender, EventArgs e)
        {
            if (frmthongtincanho == null || frmthongtincanho.IsDisposed)
            {
                frmthongtincanho = new Frm_thongtincanho();
                frmthongtincanho.MdiParent = this;
                frmthongtincanho.StartPosition = FormStartPosition.Manual;
                frmthongtincanho.Location = new Point(324, 170);
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
                frmthongtincanho.Location = new Point(324, 170);
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
                frmthongtincanho.Location = new Point(324, 170);
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
        //=========================================================
        private void frmthongtincanho_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện lại controls khi form thông tin căn hộ đóng
            pnl_data.Visible = true;
            pnl_title.Visible = true;
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
        }
        //=========================================================
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

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }


        //======================setup thanh chuc nang=============================
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
            Frm_BaotruSuachua baotri = new Frm_BaotruSuachua(menu);
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
        //===========================================================
    }
}
