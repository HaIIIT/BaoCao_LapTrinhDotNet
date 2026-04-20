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
    public partial class Frm_TTThanhToan_CuDan : Form
    {
        public Frm_TTThanhToan_CuDan()
        {
            InitializeComponent();
        }

        private void Frm_TTThanhToan_CuDan_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT * FROM ThanhToan";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgv_cktt.DataSource = tb;

                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgv_cktt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_cktt.CurrentRow;
            string MaThanhToan = row.Cells["MaThanhToan"].Value.ToString();
            //tao ket noi
            Connection ketnoi = new Connection();
            //moketnoi
            if (ketnoi.moketnoi())
            {
                //truy van 
                string selStr = "SELECT MaThanhToan, MaHoaDon, NgayThanhToan, SoTien, MaCongNo,NoiDung FROM ThanhToan WHERE MaThanhToan = '" + MaThanhToan + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {

                    txt_mtt.Text = rdr["MaThanhToan"].ToString();
                    txt_mhd.Text = rdr["MaHoaDon"].ToString();
                    txt_mcn.Text = rdr["MaCongNo"].ToString();
                    txt_st.Text = rdr["SoTien"].ToString();
                    txt_tt.Text = rdr["TrangThai"].ToString();
                    txt_nd.Text = rdr["NoiDung"].ToString();
                    dtp_ntt.Value = Convert.ToDateTime(rdr["NgayThanhToan"].ToString());
                }
            }
        }
    }
}
