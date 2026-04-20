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
    public partial class Frm_TTDGNS_CUDAN : Form
    {
        public Frm_TTDGNS_CUDAN()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_TTDGNS_CUDAN_Load(object sender, EventArgs e)
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
                dgv_dsdg.DataSource = tb;

                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgv_dsdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_dsdg.CurrentRow;
            string MaNhanSu = row.Cells["MaNhanSu"].Value.ToString();
            //tao ket noi
            Connection ketnoi = new Connection();
            //moketnoi
            if (ketnoi.moketnoi())
            {
                //truy van 
                string selStr = "SELECT MaNhanSu,MaDanhGia,KyDanhGia,NgayDanhGia,DiemTacPhong,DiemHieuSuat,DiemThaiDo,TongDiem,NhanXet FROM DanhGiaNhanSu WHERE MaNhanSu = '" + MaNhanSu + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {

                    txt_mns.Text = rdr["MaNhanSu"].ToString();
                    txt_mdg.Text = rdr["MaDanhGia"].ToString();                 
                    txt_kdg.Text = rdr["KyDanhGia"].ToString();
                    txt_ndg.Text = rdr["NgayDanhGia"].ToString();
                    txt_dtp.Text = rdr["DiemTacPhong"].ToString();
                    txt_dhs.Text = rdr["DiemHieuSuat"].ToString();
                    txt_dtd.Text = rdr["DiemThaiDo"].ToString();
                    txt_td.Text = rdr["TongDiem"].ToString();
                    txt_nx.Text = rdr["NhanXet"].ToString();
                }
            }
        }
    }
}
