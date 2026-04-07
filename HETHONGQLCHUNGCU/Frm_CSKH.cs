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
        public Frm_Menu Menu;
        public Frm_CSKH()
        {
            InitializeComponent();
        }
        public Frm_CSKH(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }


        private void mãCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            {
                frmThongtincskh = new Frm_thongtincskh();
                frmThongtincskh.MdiParent = this;
                frmThongtincskh.StartPosition = FormStartPosition.Manual;
                frmThongtincskh.Location = new Point(370, 130);
                frmThongtincskh.FormBorderStyle = FormBorderStyle.None;
                frmThongtincskh.FormClosed += frmThongtincskh_FormClosed;
                frmThongtincskh.Show();
                // 
                pnl_data.Visible = false;
                pnl_input.Visible = false;
                pnl_titlelist.Visible = false;
                pnl_titleyc.Visible = false;
            }
            else
            {
                frmThongtincskh.Activate();

            }
        }


        private void frmThongtincskh_FormClosed(object sender, FormClosedEventArgs e) {
            pnl_data.Visible = true;
            pnl_input.Visible = true;
            pnl_titlelist.Visible = true;
            pnl_titleyc.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Menu != null)
            {
                Menu.Show();
            }this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Menu != null)
            {
                Menu.DangXuat();
                Menu.Show();
            }this.Close();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.Show();
            }
            this.Close();
        }

        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(Menu);
            cudan.Show();
            this.Close();
        }

        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo(Menu);
            canho.Show();
            this.Close();
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoadon = new Frm_HoaDon(Menu);
            hoadon.Show();
            this.Close();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(Menu);
            thanhtoan.Show();
            this.Close();
        }

        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(Menu);
            congno.Show();
            this.Close();
        }

        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongketc = new Frm_ThongKeTaiChinh(Menu);
            thongketc.Show();
            this.Close();
        }

        private void btn_cskh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hiện đang ở trang CSKH!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(Menu);
            dkdv.Show();
            this.Close();
        }

        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaotruSuachua btsc = new Frm_BaotruSuachua(Menu);
            btsc.Show();
            this.Close();
        }

        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baixe = new Frm_BaiXe(Menu);
            baixe.Show();
            this.Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong = new Frm_ChamCong(Menu);
            chamcong.Show();
            this.Close();
        }

        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(Menu);
            bpc.Show();
            this.Close();
        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(Menu);
            danhgia.Show();
            this.Close();
        }
    }
}
