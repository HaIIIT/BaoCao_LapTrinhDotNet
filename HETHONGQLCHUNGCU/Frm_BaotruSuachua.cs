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
    public partial class Frm_BaotruSuachua : Form
    {
        private frm_btsc frmBaoTriSuaChua = null;
        public Frm_Menu Menu;
        public Frm_BaotruSuachua()
        {
            InitializeComponent();
           
        }
        public Frm_BaotruSuachua(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }

        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBaoTriSuaChua == null || frmBaoTriSuaChua.IsDisposed)
            {
                frmBaoTriSuaChua = new frm_btsc();
                frmBaoTriSuaChua.MdiParent = this;
                frmBaoTriSuaChua.StartPosition = FormStartPosition.Manual;
                frmBaoTriSuaChua.Location = new Point(170, 100);
                frmBaoTriSuaChua.FormBorderStyle = FormBorderStyle.None;
                frmBaoTriSuaChua.FormClosed += frmBaoTriSuaChua_FormClosed;
                frmBaoTriSuaChua.Show();
                grp_ThonTinBaoTri.Visible = false;
                grp_TraCuBaoTri.Visible = false;
                dgv_ThongTinBt.Visible = false;
            }
            else
            {
                frmBaoTriSuaChua.Activate();
            }
        }
            private void frmBaoTriSuaChua_FormClosed(object sender, FormClosedEventArgs e)
        {
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
            dgv_ThongTinBt.Visible = true;
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(Menu != null)
            {
                Menu.Show();
            }this.Close();
        }

        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
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
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(Menu);
            thongKeTaiChinh.Show();
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
            MessageBox.Show("Bạn đang ở trang Bảo trì - Sửa chữa!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(Menu);
            baiXe.Show();
            this.Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(Menu);
            chamCong.Show();
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
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(Menu);
            danhGiaNhanSu.Show();
            this.Close();
        }
    }

    
}
    

