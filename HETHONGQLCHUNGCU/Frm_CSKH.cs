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
    public partial class Frm_CSKH : Form
    {
        public Frm_CSKH()
        {
            InitializeComponent();
        }
        private Frm_thongtincskh frmThongtincskh=null;


        private void mãCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongtincskh == null || frmThongtincskh.IsDisposed)
            {
                frmThongtincskh = new Frm_thongtincskh();
                frmThongtincskh.MdiParent = this;
                frmThongtincskh.StartPosition = FormStartPosition.Manual;
                frmThongtincskh.Location = new Point(370, 130);
                frmThongtincskh.FormBorderStyle = FormBorderStyle.None;
                frmThongtincskh.FormClosed += frmThongtincskh_FormClosed;
                frmThongtincskh.Show();
                // 
                pnl_data.Visible = false;
                pnl_input.Visible = false;
                pnl_titlelist.Visible = false;
                pnl_titleyc.Visible = false;
            }
            else
            {
                frmThongtincskh.Activate();

            }
        }


        private void frmThongtincskh_FormClosed(object sender, FormClosedEventArgs e) {
            pnl_data.Visible = true;
            pnl_input.Visible = true;
            pnl_titlelist.Visible = true;
            pnl_titleyc.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}
