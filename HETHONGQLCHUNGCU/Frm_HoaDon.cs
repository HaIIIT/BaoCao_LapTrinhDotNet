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
    public partial class Frm_HoaDon : Form
    {
        private Frm_HD Frm_HD = null;
        public Frm_Menu Menu;
        public Frm_HoaDon()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        public Frm_HoaDon(Frm_Menu menu)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.Menu = menu;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void AnTatCaFormCon()
        {
            if (Frm_HD != null && !Frm_HD.IsDisposed)
                Frm_HD.Hide();

           
        }
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                Frm_HD = new Frm_HD();
                Frm_HD.MdiParent = this;
                Frm_HD.StartPosition = FormStartPosition.Manual;
                Frm_HD.Location = new Point(380, 200);
                Frm_HD.FormBorderStyle = FormBorderStyle.None;
                Frm_HD.FormClosed += Frm_HD_FormClosed;
                Frm_HD.Show();
            }
            else
            {
                Frm_HD.Show();
                Frm_HD.Activate();
            }

            pnlTKHD.Visible = false;
            gbx_Tracuuthongtin.Visible = false;
            lblDSHD.Visible = false;
            pnlDSHD.Visible = false;
            dgvDSHD.Visible=false;

        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_HD = null;
            gbx_Tracuuthongtin.Visible = true;
            lblDSHD.Visible = true;
            pnlDSHD.Visible = true;
            dgvDSHD.Visible = true;

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Menu != null)
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
            }this.Hide(); 
        }

        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(Menu);
            cudan.Show();
            this.Close();
        }

        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo();
            canho.Show();
            this.Close();
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hiện đang ở trang Hóa Đơn!0", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoana = new Frm_TT(Menu);
            thanhtoana.Show();
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
            Frm_BPCNV bpc = new Frm_BPCNV(Menu);
            bpc.Show();
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
