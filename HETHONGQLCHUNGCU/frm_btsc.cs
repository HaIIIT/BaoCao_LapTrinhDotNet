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
    public partial class frm_btsc : Form
    {
        public frm_btsc()
        {
            InitializeComponent();
        }

        private void txt_cp_TextChanged(object sender, EventArgs e)
        {
            decimal chiPhi;
            if (!decimal.TryParse(txt_cp.Text, out chiPhi))
            {
                MessageBox.Show("Chi phí không hợp lệ!");
                return;
            }
        }

        private void btn_moi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
