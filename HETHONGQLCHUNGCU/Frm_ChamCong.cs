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
        public Frm_ChamCong()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

        }
        private Frm_CCcs Frm_CCcs = null;
        private void AnTatCaFormCon()
        {
            if (Frm_CCcs != null && !Frm_CCcs.IsDisposed)
                Frm_CCcs.Hide();


        }

        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                Frm_CCcs = new Frm_CCcs();
                Frm_CCcs.MdiParent = this;
                Frm_CCcs.StartPosition = FormStartPosition.Manual;
                Frm_CCcs.Location = new Point(380, 200);
                Frm_CCcs.FormBorderStyle = FormBorderStyle.None;
                Frm_CCcs.FormClosed += Frm_CCcs_FormClosed;
                Frm_CCcs.Show();
            }
            else
            {
                Frm_CCcs.Show();
                Frm_CCcs.Activate();
            }

            pnlTTCC.Visible = false;
            gbxTTCC.Visible = false;
            pnlDSCC.Visible = false;
            dgvDSCC.Visible = false;
             
        }
        private void Frm_CCcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_CCcs = null;
            pnlTTCC.Visible = true;
            gbxTTCC.Visible = true;
            pnlDSCC.Visible = true;
            dgvDSCC.Visible = true;

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}
