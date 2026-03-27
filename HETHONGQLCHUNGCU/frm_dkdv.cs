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
    public partial class frm_dkdv : Form
    {
        public frm_dkdv()
        {
            InitializeComponent();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
        
            // Kiểm tra dữ liệu
            if (txt_mdk.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đăng ký!");
                txt_mdk.Focus();
                return;
            }

            if (cbx_mch.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn mã căn hộ!");
                return;
            }

            if (cbx_mdv.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn dịch vụ!");
                return;
            }

            string maDK = txt_mdk.Text;
            string maCanHo = cbx_mch.SelectedValue.ToString();
            string maDV = cbx_mdv.SelectedValue.ToString();
            DateTime ngayDK = dtp_ngay.Value;
            int soLuong = (int) nud_sl.Value;
            string trangThai = cbx_tt.Text;
            string ghiChu = txt_gc.Text;

            MessageBox.Show("Lưu thành công!");
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {         
            txt_mdk.Clear();
            cbx_mch.SelectedIndex = -1;
            cbx_mdv.SelectedIndex = -1;
            dtp_ngay.Value = DateTime.Now;
            nud_sl.Value = 0;
            cbx_tt.SelectedIndex = -1;
            txt_gc.Clear();
        }

        private void cbx_mch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cbx_mch.SelectedIndex != -1)
            {
                string maCanHo = cbx_mch.SelectedValue.ToString();

            }
        }

        private void cbx_mdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_mdv.SelectedIndex != -1)
            {
                nud_sl.Value = 1;
            }
        }

        private void nud_sl_ValueChanged(object sender, EventArgs e)
        {
            if (nud_sl.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0");
                nud_sl.Value = 1;
            }
        }

        private void btn_th_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
