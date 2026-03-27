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
    public partial class frm_DanhGiaNhanSu : Form
    {
        public frm_DanhGiaNhanSu()
        {
            InitializeComponent();
        }


        private void frm_DanhGiaNhanSu_Load(object sender, EventArgs e)
        {
            
        }
        private frm_dgns
            frmDanhGiaNhanSu = null;
        private void btn_dkdv_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }

        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                frmDanhGiaNhanSu = new frm_dgns();
                frmDanhGiaNhanSu.MdiParent = this;
                frmDanhGiaNhanSu.StartPosition = FormStartPosition.Manual;
                frmDanhGiaNhanSu.Location = new Point(170,100);
                frmDanhGiaNhanSu.FormBorderStyle = FormBorderStyle.None;
                frmDanhGiaNhanSu.FormClosed += frmDanhGiaNhanSu_FormClosed;
                frmDanhGiaNhanSu.Show();
                grp_ThongTinNhanSu.Visible = false;
                grp_TraCuNhanVien.Visible = false;
                dgv_ThongTinNs.Visible = false;
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }    
        }
        private void frmDanhGiaNhanSu_FormClosed(object sender,FormClosedEventArgs e)
        {
            grp_ThongTinNhanSu.Visible = true;
            grp_TraCuNhanVien.Visible = true;
            dgv_ThongTinNs.Visible = true;
        }
    }
}
