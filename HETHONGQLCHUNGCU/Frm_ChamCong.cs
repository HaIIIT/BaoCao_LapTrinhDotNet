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
    public partial class Frm_ChamCong : Form
    {
        private Frm_CCcs Frm_CCcs = null;
        public Frm_Menu Menu;
        public Frm_ChamCong()
        {
            InitializeComponent();
        }
        public Frm_ChamCong(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }
        private void AnTatCaFormCon()
        {
            if (Frm_CCcs != null && !Frm_CCcs.IsDisposed)
                Frm_CCcs.Hide();


        }

        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                Frm_CCcs = new Frm_CCcs();
                Frm_CCcs.MdiParent = this;
                Frm_CCcs.StartPosition = FormStartPosition.Manual;
                Frm_CCcs.Location = new Point(380, 200);
                Frm_CCcs.FormBorderStyle = FormBorderStyle.None;
                Frm_CCcs.FormClosed += Frm_CCcs_FormClosed;
                Frm_CCcs.Show();
            }
            else
            {
                Frm_CCcs.Show();
                Frm_CCcs.Activate();
            }

            pnlTTCC.Visible = false;
            gbxTTCC.Visible = false;
            pnlDSCC.Visible = false;
            dgvDSCC.Visible = false;
             
        }
        private void Frm_CCcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_CCcs = null;
            pnlTTCC.Visible = true;
            gbxTTCC.Visible = true;
            pnlDSCC.Visible = true;
            dgvDSCC.Visible = true;
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
            if (Menu != null)
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
            Frm_CanHo canHo = new Frm_CanHo(Menu);
            canHo.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoaDon = new Frm_HoaDon(Menu);
            hoaDon.Show();
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
            Frm_CongNo congNo = new Frm_CongNo(Menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKe = new Frm_ThongKeTaiChinh(Menu);
            thongKe.Show();
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
            Frm_BaotruSuachua baotri = new Frm_BaotruSuachua(Menu);
            baotri.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(Menu);
            baiXe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang chấm công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(Menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(Menu);
            danhGiaNhanSu.Show();
            this.Close();
        }
    }
}
