using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TTDV_DKDV_CUDAN : Form
    {
        public Frm_TTDV_DKDV_CUDAN()
        {
            InitializeComponent();
        }

        private void Frm_TTDV_DKDV_CUDAN_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT * FROM DanhMucDichVu";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();           
                dgv_dsdv.DataSource = tb;

                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_dsdv.CurrentRow;
            string MaDichVu = row.Cells["MaDichVu"].Value.ToString();
            //tao ket noi
            Connection ketnoi = new Connection();
            //moketnoi
            if (ketnoi.moketnoi())
            {
                //truy van 
                string selStr = "SELECT MaDichVu,TenDichVu,NgayDangKy,TrangThai FROM DanhMucDichVu WHERE MaDichVu = '" + MaDichVu + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {

                    txt_mdv.Text = rdr["MaDichVu"].ToString();
                    txt_tdv.Text = rdr["TenDichVu"].ToString();
                    dtp_ndk.Value = Convert.ToDateTime(rdr["NgayDangKy"].ToString());
                    txt_tt.Text = rdr["TrangThai"].ToString();
                }
            }
        }
    }
}
