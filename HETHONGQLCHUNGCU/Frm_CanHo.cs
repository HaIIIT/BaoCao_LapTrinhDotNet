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
    public partial class Frm_CanHo : Form
    {
        public Frm_CanHo()
        {
            InitializeComponent();
        }
        private Frm_thongtincanho frmthongtincanho = null;

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if(frmthongtincanho == null || frmthongtincanho.IsDisposed)
            {
                frmthongtincanho = new Frm_thongtincanho();
                frmthongtincanho.MdiParent = this;
                frmthongtincanho.StartPosition = FormStartPosition.Manual;
                frmthongtincanho.Location = new Point(424, 150);
                frmthongtincanho.FormBorderStyle = FormBorderStyle.None;  
                frmthongtincanho.Show();
                //ẩn controls
                pnl_data.Visible = false;
                pnl_title.Visible = false;
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
            }
            else
            {
                frmthongtincanho.Activate();
            }
        }
        private void frmthongtincanho_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện controls
            pnl_data.Visible = true;
            pnl_title.Visible = true;
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}
