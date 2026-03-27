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
    public partial class frm_Dangkydichvu : Form
    {
        public frm_Dangkydichvu()
        {
            InitializeComponent();
        }
        private frm_dkdv frmDangKyDichVu = null;

        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {
                frmDangKyDichVu = new frm_dkdv();
                frmDangKyDichVu.MdiParent = this;
                frmDangKyDichVu.StartPosition = FormStartPosition.Manual;
                frmDangKyDichVu.Location = new Point(170, 100);
                frmDangKyDichVu.FormBorderStyle = FormBorderStyle.None;
                frmDangKyDichVu.FormClosed += frmDangKyDichVu_FormClosed;
                frmDangKyDichVu.Show();
                grp_ThonTinDangKy.Visible = false;
                grp_TraCuDichVu.Visible = false;
                dgv_ThongTinBt.Visible = false;
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
             private void frmDangKyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            grp_ThonTinDangKy.Visible = true;
            grp_TraCuDichVu.Visible = true;
            dgv_ThongTinBt.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
    
}
