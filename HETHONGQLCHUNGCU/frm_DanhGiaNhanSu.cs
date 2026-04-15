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
    public partial class frm_DanhGiaNhanSu : Form
    {
        private frm_dgns frmDanhGiaNhanSu = null;
        public Frm_Menu menu;
        public frm_DanhGiaNhanSu()
        {
            InitializeComponent();
        }
        public frm_DanhGiaNhanSu(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //Xây dựng hàm dùng chung
        private void MDI()
        {
            frmDanhGiaNhanSu = new frm_dgns();
            frmDanhGiaNhanSu.MdiParent = this;
            frmDanhGiaNhanSu.StartPosition = FormStartPosition.Manual;
            frmDanhGiaNhanSu.Location = new Point(170, 150);
            frmDanhGiaNhanSu.FormBorderStyle = FormBorderStyle.None;
            frmDanhGiaNhanSu.FormClosed += frmDanhGiaNhanSu_FormClosed;
            frmDanhGiaNhanSu.Show();
        }
        private void ancontrols()
        {
            pnl_tiltle1.Visible = false;
            pnl_tiltle2.Visible = false;
            grp_ThongTinNhanSu.Visible = false;
            grp_TraCuNhanVien.Visible = false;
            dgv_ThongTinNs.Visible = false;
        }
        //----------------MenuStrip---------------------
        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(true, false, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }                
        }
        private void cậpNhậtĐánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(false, true, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }
        }
        private void xóaĐánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                MDI();
                frmDanhGiaNhanSu.settrangthaibutton(false, false, true);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }
        }
        private void frmDanhGiaNhanSu_FormClosed(object sender,FormClosedEventArgs e)
        {
            pnl_tiltle1.Visible = true;
            pnl_tiltle2.Visible = true;
            grp_ThongTinNhanSu.Visible = true;
            grp_TraCuNhanVien.Visible = true;
            dgv_ThongTinNs.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menu!= null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
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
            Frm_HoaDon hoaDon = new Frm_HoaDon(menu);
            hoaDon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
            this.Close();
        }
        private void btn_congnno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(menu);
            thongKeTaiChinh.Show();
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
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(menu);
            baiXe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(menu);
            chamCong.Show();
            this.Close();
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang đánh giá nhân sự!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       
    }
}
