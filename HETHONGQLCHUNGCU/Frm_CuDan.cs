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
    public partial class Frm_CuDan : Form
    {
        public Frm_CuDan()
        {
            InitializeComponent();
        }
        private Frm_ThongTinCuDan frmThongTinCuDan = null;

        private void Frm_CuDan_Load(object sender, EventArgs e)
        {

        }

        private void thêmCưDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                frmThongTinCuDan = new Frm_ThongTinCuDan();
                frmThongTinCuDan.MdiParent = this;
                frmThongTinCuDan.StartPosition = FormStartPosition.Manual;
                frmThongTinCuDan.Location = new Point(424, 150);
                frmThongTinCuDan.FormBorderStyle = FormBorderStyle.None;
                frmThongTinCuDan.FormClosed += FrmThongTinCuDan_FormClosed;
                frmThongTinCuDan.Show();
                //ẩn controls 
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
                dgv_thongtincudan.Visible = false;
            }
            else
            {
                frmThongTinCuDan.Activate();
            }
        }
        private void FrmThongTinCuDan_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
            dgv_thongtincudan.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }
    }
}
