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
        public Frm_Menu menu;
        public Frm_BPCNV()
        {
            InitializeComponent();
        }
        public Frm_BPCNV(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI()
        {
            frmthongtinBPCNV = new Frm_thongtinBPCNV();
            frmthongtinBPCNV.MdiParent = this;
            frmthongtinBPCNV.StartPosition = FormStartPosition.Manual;
            frmthongtinBPCNV.Location = new Point(150, 130);
            frmthongtinBPCNV.FormClosed += frmthongtinBPCNV_FormClosed;
            frmthongtinBPCNV.Show();
        }   
        private void ancontrols()
        {
            gpb_trangthai.Visible = false;
            gpb_tracuu.Visible = false;
            dgv_dsnhiemvu.Visible = false;
            pnl_tiltelist.Visible = false;
            pnl_tiltethongtin.Visible = false;
        }
        //----------------MenuStrip---------------------
        private void mãCănHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtinBPCNV == null|| frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(true, false, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }           
        }
        private void CapNhatBPCtool_Click(object sender, EventArgs e)
        {
            if(frmthongtinBPCNV == null || frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(false, true, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }
        }
        private void xoaBPCtool_Click(object sender, EventArgs e)
        {
            if(frmthongtinBPCNV == null || frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(false, false, true);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }
        }
        private void frmthongtinBPCNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            gpb_trangthai.Visible = true;
            gpb_tracuu.Visible = true;
            dgv_dsnhiemvu.Visible = true;
            pnl_tiltelist.Visible = true;
            pnl_tiltethongtin.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
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
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
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
            frm_Dangkydichvu dk = new frm_Dangkydichvu(menu);
            dk.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
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
            MessageBox.Show("Bạn đang ở trang bảng phân công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }      
    }
}
