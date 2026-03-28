using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_CongNo : Form
    {
        public Frm_CongNo()
        {
            InitializeComponent();
           
        }
        private Frm_thongtincongno frmthongtincongno = null;

        private void mãCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtincongno == null || frmthongtincongno.IsDisposed)
            {
                frmthongtincongno = new Frm_thongtincongno();
                frmthongtincongno.MdiParent = this;
                frmthongtincongno.StartPosition = FormStartPosition.Manual;
                frmthongtincongno.Location = new Point(370, 130);
                frmthongtincongno.FormBorderStyle = FormBorderStyle.None;
                frmthongtincongno.FormClosed += frmthongtincongno_FormClosed;
                frmthongtincongno.Show();
                //ẩn controls
                pnl_data.Visible = false;
                pnl_find.Visible = false;
                pnl_titel.Visible = false;
                pnl_titel2.Visible = false;
            }
            else
            {
                frmthongtincongno.Activate(); 
            }
        }
        private void frmthongtincongno_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện contorls
            pnl_data.Visible = true;
            pnl_find.Visible = true;
            pnl_titel.Visible = true;
            pnl_titel2.Visible = true;
        }
    }
}
