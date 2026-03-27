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
    public partial class Frm_BaotruSuachua : Form
    {
        public Frm_BaotruSuachua()
        {
            InitializeComponent();
        }
        private frm_btsc frmBaoTriSuaChua = null;
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }

        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBaoTriSuaChua == null || frmBaoTriSuaChua.IsDisposed)
            {
                frmBaoTriSuaChua = new frm_btsc();
                frmBaoTriSuaChua.MdiParent = this;
                frmBaoTriSuaChua.StartPosition = FormStartPosition.Manual;
                frmBaoTriSuaChua.Location = new Point(170, 100);
                frmBaoTriSuaChua.FormBorderStyle = FormBorderStyle.None;
                frmBaoTriSuaChua.FormClosed += frmBaoTriSuaChua_FormClosed;
                frmBaoTriSuaChua.Show();
                grp_ThonTinBaoTri.Visible = false;
                grp_TraCuBaoTri.Visible = false;
                dgv_ThongTinBt.Visible = false;
            }
            else
            {
                frmBaoTriSuaChua.Activate();
            }
        }
            private void frmBaoTriSuaChua_FormClosed(object sender, FormClosedEventArgs e)
        {
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
            dgv_ThongTinBt.Visible = true;
        }
    }

    
}
    

