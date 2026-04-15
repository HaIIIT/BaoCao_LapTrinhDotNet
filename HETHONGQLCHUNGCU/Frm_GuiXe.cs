using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_GuiXe : Form
    {
        public Frm_GuiXe()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}