using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Frm_Menu Menu;
        private Frm_ThanhToan Frm_ThanhToan = null;
        public Frm_TT()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        public Frm_TT(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
            this.IsMdiContainer = true;
        }
        

        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_ThanhToan == null || Frm_ThanhToan.IsDisposed)
            {
                Frm_ThanhToan = new Frm_ThanhToan();
                Frm_ThanhToan.MdiParent = this;
                Frm_ThanhToan.StartPosition = FormStartPosition.Manual;
                Frm_ThanhToan.Location = new Point(340, 140);
                Frm_ThanhToan.FormBorderStyle = FormBorderStyle.None;
                Frm_ThanhToan.FormClosed += Frm_HD_FormClosed;
                Frm_ThanhToan.Show();
            }
            else
            {
                Frm_ThanhToan.Activate();
            }

            pnlTKTT.Visible = false;
            gbxTCTTTT.Visible = false;
            pnlDSTT.Visible = false;
            dgvDSTT.Visible = false;


        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ThanhToan = null;
            pnlTKTT.Visible = true;
            gbxTCTTTT.Visible = true;
            pnlDSTT.Visible = true;
            dgvDSTT.Visible = true;

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.Show();
            }
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.DangXuat();
                Menu.Show();
            }
            this.Close();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.Show();
            }this.Close();
        }

        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(Menu);
            cudan.Show();
            this.Close();
        }

        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo cudan = new Frm_CanHo(Menu);
            cudan.Show();
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
            MessageBox.Show("Bạn hiện đang ở trang Thanh Toán!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(Menu);
            congno.Show();
            this.Close();
        }

        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(Menu);
            congno.Show();
            this.Close();
        }

        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(Menu);
            cskh.Show();
            this.Close();
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
            Frm_BPCNV phancong = new Frm_BPCNV(Menu);
            phancong.Show();
            this.Close();
        }

        private void btn_bdg_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(Menu);
            danhgia.Show();
            this.Close();
        }
    }
}
