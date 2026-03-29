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
        public Frm_HoaDon()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private Frm_HD Frm_HD = null;
        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void AnTatCaFormCon()
        {
            if (Frm_HD != null && !Frm_HD.IsDisposed)
                Frm_HD.Hide();

           
        }
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_HD == null || Frm_HD.IsDisposed)
            {
                Frm_HD = new Frm_HD();
                Frm_HD.MdiParent = this;
                Frm_HD.StartPosition = FormStartPosition.Manual;
                Frm_HD.Location = new Point(380, 200);
                Frm_HD.FormBorderStyle = FormBorderStyle.None;
                Frm_HD.FormClosed += Frm_HD_FormClosed;
                Frm_HD.Show();
            }
            else
            {
                Frm_HD.Show();
                Frm_HD.Activate();
            }

            pnlTKHD.Visible = false;
            gbx_Tracuuthongtin.Visible = false;
            lblDSHD.Visible = false;
            pnlDSHD.Visible = false;
            dgvDSHD.Visible=false;

        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_HD = null;
            gbx_Tracuuthongtin.Visible = true;
            lblDSHD.Visible = true;
            pnlDSHD.Visible = true;
            dgvDSHD.Visible = true;

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();

        }
    }
}
