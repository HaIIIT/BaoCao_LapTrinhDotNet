using System;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_BaiXe : Form
    {
        private Frm_Xe Frm_Xe = null;
        private Frm_ViTriBaiXe Frm_ViTriBaiXe = null;
        private Frm_GuiXe Frm_GuiXe = null;
        public Frm_Menu menu;
        public Frm_BaiXe()
        {
            InitializeComponent();
        }
        public Frm_BaiXe(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void AnTatCaFormCon()
        {
            if (Frm_Xe != null && !Frm_Xe.IsDisposed)
                Frm_Xe.Hide();
            if (Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
                Frm_ViTriBaiXe.Hide();
            if (Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
                Frm_GuiXe.Hide();
        }
        private void MDITTBX()
        {
            Frm_Xe = new Frm_Xe();
            Frm_Xe.MdiParent = this;
            Frm_Xe.StartPosition = FormStartPosition.Manual;
            Frm_Xe.Location = new Point(180, 150);
            Frm_Xe.FormBorderStyle = FormBorderStyle.None;
            Frm_Xe.FormClosed += Frm_Xe_FormClosed;
            Frm_Xe.Show();
        }
        private void MDIVTRIBX()
        {
            Frm_ViTriBaiXe = new Frm_ViTriBaiXe();
            Frm_ViTriBaiXe.MdiParent = this;
            Frm_ViTriBaiXe.StartPosition = FormStartPosition.Manual;
            Frm_ViTriBaiXe.Location = new Point(180, 150);
            Frm_ViTriBaiXe.FormBorderStyle = FormBorderStyle.None;
            Frm_ViTriBaiXe.FormClosed += Frm_ViTriBaiXe_FormClosed;
            Frm_ViTriBaiXe.Show();
        }
        private void MDIGUIXE()
        {
            Frm_GuiXe = new Frm_GuiXe();
            Frm_GuiXe.MdiParent = this;
            Frm_GuiXe.StartPosition = FormStartPosition.Manual;
            Frm_GuiXe.Location = new Point(180, 150);
            Frm_GuiXe.FormBorderStyle = FormBorderStyle.None;
            Frm_GuiXe.FormClosed += Frm_GuiXe_FormClosed;
            Frm_GuiXe.Show();
        }
        private void ancontrols()
        {
            pnl_tiltle1.Visible = false;
            pnl_title2.Visible = false;
            pnl_dgv.Visible = false;
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }
        private void hiencontrols()
        {
            pnl_tiltle1.Visible = true;
            pnl_title2.Visible = true;
            pnl_dgv.Visible = true;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
        }
        //----------------MenuStrip---------------------
        /// <MDIThongTinXe>
        private void thêmThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_Xe == null || Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                MDITTBX();
                Frm_Xe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_Xe.Activate();
            }
        }
        private void cậpNhậtThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_Xe != null && !Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_Xe.Show();
                Frm_Xe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xóaThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_Xe != null && !Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_Xe.Show();
                Frm_Xe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_Xe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_Xe = null;
            hiencontrols();
        }
        /// </MDIThongTinXe>

        /// <MDIViTriBaiXe>
        private void thembaidotool_Click(object sender, EventArgs e)
        {
            if(Frm_ViTriBaiXe == null || Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                MDIVTRIBX();
                Frm_ViTriBaiXe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_ViTriBaiXe.Activate();
            }
        }
        private void capnhatvtribaidotool_Click(object sender, EventArgs e)
        {
            if(Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_ViTriBaiXe.Show();
                Frm_ViTriBaiXe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xoavtribaidotool_Click(object sender, EventArgs e)
        {
            if(Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_ViTriBaiXe.Show();
                Frm_ViTriBaiXe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_ViTriBaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ViTriBaiXe = null;
            hiencontrols();
        }
        ///</MDIViTriBaiXe>

        /// <MDIGuiXe>
        private void thêmThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_GuiXe == null || Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                MDIGUIXE();
                Frm_GuiXe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_GuiXe.Activate();
            }
        }
        private void cậpNhậtThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_GuiXe.Show();
                Frm_GuiXe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xóaThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_GuiXe.Show();
                Frm_GuiXe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_GuiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_GuiXe = null;
            hiencontrols();
        }
        /// </MDIGuiXe>
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menu != null)
            {
                menu.Show();
            }
            this.Close();
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
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTC = new Frm_ThongKeTaiChinh(menu);
            thongKeTC.Show();
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
            MessageBox.Show("Bạn đang ở trang Bãi Xe!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(menu);
            danhGiaNhanSu.Show();
            this.Close();
        }       
    }
}