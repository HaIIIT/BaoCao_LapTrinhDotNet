using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_BPCNV : Form
    {
        private Frm_thongtinBPCNV frmthongtinBPCNV = null;
        public Frm_Menu Menu;
        public Frm_BPCNV()
        {
            InitializeComponent();
        }
        public Frm_BPCNV(Frm_Menu frmmenu)
        {
            InitializeComponent();
            this.Menu = frmmenu;
        }
        private void mãCănHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtinBPCNV == null|| frmthongtinBPCNV.IsDisposed)
            {
                frmthongtinBPCNV=new Frm_thongtinBPCNV();
                frmthongtinBPCNV.MdiParent=this;
                frmthongtinBPCNV.StartPosition=FormStartPosition.Manual;
                frmthongtinBPCNV.Location = new Point(320, 130);
                frmthongtinBPCNV.FormClosed += frmthongtinBPCNV_FormClosed;
                frmthongtinBPCNV.Show();
                // ẩn control
                pnl_data.Visible= false;
                pnl_input.Visible= false;
                pnl_tiltelist.Visible= false;
                pnl_tiltethongtin.Visible = false;
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }           
        }
        private void frmthongtinBPCNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_data.Visible = true;
            pnl_input.Visible = true;
            pnl_tiltelist.Visible = true;
            pnl_tiltethongtin.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
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
            Frm_TT thanhtoan = new Frm_TT(Menu);
            thanhtoan.Show();
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
            frm_Dangkydichvu dk = new frm_Dangkydichvu(Menu);
            dk.Show();
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
            MessageBox.Show("Bạn đang ở trang bảng phân công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(Menu);
            danhgia.Show();
            this.Close();
        }
    }
}
