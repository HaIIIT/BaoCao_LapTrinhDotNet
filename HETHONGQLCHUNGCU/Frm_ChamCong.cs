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
        private Frm_htchamcong frmchamcong = null;
        public Frm_Menu menu;
        public Frm_ChamCong()
        {
            InitializeComponent();
        }
        public Frm_ChamCong(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void AnTatCaFormCon()
        {
            if (Frm_CCcs != null && !Frm_CCcs.IsDisposed)
                Frm_CCcs.Hide();
            if (frmchamcong != null && !frmchamcong.IsDisposed)
                frmchamcong.Hide();
        }
        private void MDI()
        {
            Frm_CCcs = new Frm_CCcs();
            Frm_CCcs.MdiParent = this;
            Frm_CCcs.StartPosition = FormStartPosition.Manual;
            Frm_CCcs.Location = new Point(175, 150);
            Frm_CCcs.FormBorderStyle = FormBorderStyle.None;
            Frm_CCcs.FormClosed += Frm_CCcs_FormClosed;
            Frm_CCcs.Show();
        }
        private void ancontrols()
        {
            gpb_trangthai.Visible = false;
            pnlTTCC.Visible = false;
            gbxTTCC.Visible = false;
            pnlDSCC.Visible = false;
            dgvDSCC.Visible = false;
        }
        //----------------MenuStrip---------------------
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }                      
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs != null && !Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_CCcs != null && !Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }
        }
        private void Frm_CCcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_CCcs = null;
            gpb_trangthai.Visible = true;
            pnlTTCC.Visible = true;
            gbxTTCC.Visible = true;
            pnlDSCC.Visible = true;
            dgvDSCC.Visible = true;
        }
        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmchamcong == null || frmchamcong.IsDisposed)
            {
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
            }
            else
            {
                frmchamcong.Activate();
            }         
        }
        private void Frm_htchamcong_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmchamcong = null;
            gpb_trangthai.Visible = true;
            pnlTTCC.Visible = true;
            gbxTTCC.Visible = true;
            pnlDSCC.Visible = true;
            dgvDSCC.Visible = true;
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
            Frm_CanHo canHo = new Frm_CanHo(menu);
            canHo.Show();
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
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKe = new Frm_ThongKeTaiChinh(menu);
            thongKe.Show();
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
            MessageBox.Show("Bạn đang ở trang chấm công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(menu);
            danhGiaNhanSu.Show();
            this.Close();
        }    
    }
}
