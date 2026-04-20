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
        public Frm_Menu menu;
        private Frm_HD Frm_HD = null;       
        public Frm_HoaDon()
        {
            InitializeComponent();
        }
        public Frm_HoaDon(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung 
        private void MDI()
        {
            Frm_HD = new Frm_HD();
            Frm_HD.MdiParent = this;
            Frm_HD.StartPosition = FormStartPosition.Manual;
            Frm_HD.Location = new Point(174, 145);
            Frm_HD.FormBorderStyle = FormBorderStyle.None;
            Frm_HD.FormClosed += Frm_HD_FormClosed;
            Frm_HD.Show();
        }
        private void ancontrols()
        {
            pnlTKHD.Visible = false;
            gbx_Tracuuthongtin.Visible = false;
            lblDSHD.Visible = false;
            pnlDSHD.Visible = false;
            dgvDSHD.Visible = false;
        }
        //----------------MenuStrip---------------------   
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(true, false, false);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(false, true, false);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void xoathongtinhoadon(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                MDI();
                Frm_HD.settrangthaibutton(false, false, true);
            }
            else
            {
                Frm_HD.Activate();
            }
            ancontrols();
        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_HD = null;
            gbx_Tracuuthongtin.Visible = true;
            lblDSHD.Visible = true;
            pnlDSHD.Visible = true;
            dgvDSHD.Visible = true;
            pnlTKHD.Visible = true;
        }
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
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
            if (Menu != null)
            {
                menu.Show();
            }this.Close(); 
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
            MessageBox.Show("Bạn hiện đang ở trang Hóa Đơn!0", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoana = new Frm_TT(menu);
            thanhtoana.Show();
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
        private void btn_bdg_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //----------------------------------------
        private void Frm_HoaDon_Load(object sender, EventArgs e)
        {
            //1.Phân Quyền Chức Năng

        }
        
    }
}
