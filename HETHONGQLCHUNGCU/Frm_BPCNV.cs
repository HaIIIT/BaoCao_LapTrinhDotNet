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
        public Frm_BPCNV()
        {
            InitializeComponent();
        }
        private  Frm_thongtinBPCNV frmthongtinBPCNV = null;

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_BPCNV_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void mãCănHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtinBPCNV == null|| frmthongtinBPCNV.IsDisposed)
            {
                frmthongtinBPCNV=new Frm_thongtinBPCNV();
                frmthongtinBPCNV.MdiParent=this;
                frmthongtinBPCNV.StartPosition=FormStartPosition.Manual;
                frmthongtinBPCNV.Location = new Point(320, 130);
                frmthongtinBPCNV.FormClosed += frmthongtinBPCNV_FormClosed;
                frmthongtinBPCNV.Show();
                // ẩn control
                pnl_data.Visible= false;
                pnl_input.Visible= false;
                pnl_tiltelist.Visible= false;
                pnl_tiltethongtin.Visible = false;

            }
            else
            {
                frmthongtinBPCNV.Activate();

            }
            
        }
        private void frmthongtinBPCNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_data.Visible = true;
            pnl_input.Visible = true;
            pnl_tiltelist.Visible = true;
            pnl_tiltethongtin.Visible = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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
