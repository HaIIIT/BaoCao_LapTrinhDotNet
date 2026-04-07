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
        public Frm_Menu Menu;
        public Frm_BaiXe()
        {
            InitializeComponent();
        }
        public Frm_BaiXe(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }

        private void Frm_BaiXe_Load(object sender, EventArgs e)
        {
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }

        private void AnTatCaFormCon()
        {
            if (Frm_Xe != null && !Frm_Xe.IsDisposed)
                Frm_Xe.Hide();

            if (Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
                Frm_ViTriBaiXe.Hide();

            if (Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
                Frm_GuiXe.Hide();
        }

        private void thôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnTatCaFormCon();
            if (Frm_Xe == null || Frm_Xe.IsDisposed)
            {
                Frm_Xe = new Frm_Xe();
                Frm_Xe.MdiParent = this;
                Frm_Xe.StartPosition = FormStartPosition.Manual;
                Frm_Xe.Location = new Point(380, 200);
                Frm_Xe.FormBorderStyle = FormBorderStyle.None;
                Frm_Xe.FormClosed += Frm_Xe_FormClosed;
                Frm_Xe.Show();
            }
            else
            {
                Frm_Xe.Show();
                Frm_Xe.Activate();
            }
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }
        private void vịTríBãiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnTatCaFormCon();
            if (Frm_ViTriBaiXe == null || Frm_ViTriBaiXe.IsDisposed)
            {
                Frm_ViTriBaiXe = new Frm_ViTriBaiXe();
                Frm_ViTriBaiXe.MdiParent = this;
                Frm_ViTriBaiXe.StartPosition = FormStartPosition.Manual;
                Frm_ViTriBaiXe.Location = new Point(380, 200);
                Frm_ViTriBaiXe.FormBorderStyle = FormBorderStyle.None;
                Frm_ViTriBaiXe.FormClosed += Frm_ViTriBaiXe_FormClosed;
                Frm_ViTriBaiXe.Show();
            }
            else
            {
                Frm_ViTriBaiXe.Show();
                Frm_ViTriBaiXe.Activate();
            }
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }
        private void thôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnTatCaFormCon();
            if (Frm_GuiXe == null || Frm_GuiXe.IsDisposed)
            {
                Frm_GuiXe = new Frm_GuiXe();
                Frm_GuiXe.MdiParent = this;
                Frm_GuiXe.StartPosition = FormStartPosition.Manual;
                Frm_GuiXe.Location = new Point(380, 200);
                Frm_GuiXe.FormBorderStyle = FormBorderStyle.None;
                Frm_GuiXe.FormClosed += Frm_GuiXe_FormClosed;
                Frm_GuiXe.Show();
            }
            else
            {
                Frm_GuiXe.Show();
                Frm_GuiXe.Activate();
            }
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }
        private void Frm_Xe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_Xe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
        }
        private void Frm_ViTriBaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ViTriBaiXe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
        }
        private void Frm_GuiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_GuiXe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Menu != null)
            {
                Menu.Show();
            }
            this.Close();
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
            Frm_CongNo congNo = new Frm_CongNo(Menu);
            congNo.Show();
            this.Close();
        }

        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTC = new Frm_ThongKeTaiChinh(Menu);
            thongKeTC.Show();
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
            MessageBox.Show("Bạn đang ở trang Bãi Xe!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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