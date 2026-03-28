using System;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_BaiXe : Form
    {
        public Frm_BaiXe()
        {
            InitializeComponent();
        }

        private Frm_Xe Frm_Xe = null;
        private Frm_ViTriBaiXe Frm_ViTriBaiXe = null;
        private Frm_GuiXe Frm_GuiXe = null;
        

        private void Frm_BaiXe_Load(object sender, EventArgs e)
        {
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
            dgv_BaiXe.Visible = false;
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
            dgv_BaiXe.Visible = false;  
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
            dgv_BaiXe.Visible = false;
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
            dgv_BaiXe.Visible = false;
        }

        private void Frm_Xe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_Xe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
            dgv_BaiXe.Visible = true;
        }

        private void Frm_ViTriBaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ViTriBaiXe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
            dgv_BaiXe.Visible = true;
        }

        private void Frm_GuiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_GuiXe = null;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
            dgv_BaiXe.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}