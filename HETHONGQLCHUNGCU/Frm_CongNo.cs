using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_CongNo : Form
    {
        private Frm_thongtincongno frmthongtincongno = null;
        public Frm_Menu Menu;
        public Frm_CongNo()
        {
            InitializeComponent();
           
        }
        public Frm_CongNo(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }


        private void mãCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtincongno == null || frmthongtincongno.IsDisposed)
            {
                frmthongtincongno = new Frm_thongtincongno();
                frmthongtincongno.MdiParent = this;
                frmthongtincongno.StartPosition = FormStartPosition.Manual;
                frmthongtincongno.Location = new Point(370, 130);
                frmthongtincongno.FormBorderStyle = FormBorderStyle.None;
                frmthongtincongno.FormClosed += frmthongtincongno_FormClosed;
                frmthongtincongno.Show();
                //ẩn controls
                pnl_data.Visible = false;
                pnl_find.Visible = false;
                pnl_titel.Visible = false;
                pnl_titel2.Visible = false;
            }
            else
            {
                frmthongtincongno.Activate(); 
            }
        }
        private void frmthongtincongno_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện contorls
            pnl_data.Visible = true;
            pnl_find.Visible = true;
            pnl_titel.Visible = true;
            pnl_titel2.Visible = true;
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
            Frm_CuDan cudan = new Frm_CuDan();
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
            Frm_HoaDon hoadon = new Frm_HoaDon();
            hoadon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT();
            thanhtoan.Show();
            this.Close();
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang Công Nợ!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongketc = new Frm_ThongKeTaiChinh();
            thongketc.Show();
            this.Close();
        }

        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH();
            cskh.Show();
            this.Close();
        }

        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu();
            dkdv.Show();
            this.Close();
        }

        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaotruSuachua btsc = new Frm_BaotruSuachua();
            btsc.Show();
            this.Close();
        }

        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baixe = new Frm_BaiXe();
            baixe.Show();
            this.Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong = new Frm_ChamCong();
            chamcong.Show();
            this.Close();
        }

        private void btn_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpcnv = new Frm_BPCNV();
            bpcnv.Show();
            this.Close();
        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu();
            danhgia.Show();
            this.Close();
        }
    }
}
