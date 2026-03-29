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
    public partial class Frm_TT : Form
    {
        public Frm_TT()
        {
            InitializeComponent();
            this.IsMdiContainer= true;
        }

        private Frm_ThanhToan Frm_ThanhToan = null;
        private void AnTatCaFormCon()
        {
            if (Frm_ThanhToan != null && !Frm_ThanhToan.IsDisposed)
                Frm_ThanhToan.Hide();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_ThanhToan == null || Frm_ThanhToan.IsDisposed)
            {
                Frm_ThanhToan = new Frm_ThanhToan();
                Frm_ThanhToan.MdiParent = this;
                Frm_ThanhToan.StartPosition = FormStartPosition.Manual;
                Frm_ThanhToan.Location = new Point(340, 140);
                Frm_ThanhToan.FormBorderStyle = FormBorderStyle.None;
                Frm_ThanhToan.FormClosed += Frm_HD_FormClosed;
                Frm_ThanhToan.Show();
            }
            else
            {
                Frm_ThanhToan.Show();
                Frm_ThanhToan.Activate();
            }

            pnlTKTT.Visible = false;
            gbxTCTTTT.Visible = false;
            pnlDSTT.Visible = false;
            dgvDSTT.Visible = false;
            

        }
        private void Frm_HD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ThanhToan = null;
            pnlTKTT.Visible = true;
            gbxTCTTTT.Visible = true;
            pnlDSTT.Visible = true;
            dgvDSTT.Visible = true;

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}
