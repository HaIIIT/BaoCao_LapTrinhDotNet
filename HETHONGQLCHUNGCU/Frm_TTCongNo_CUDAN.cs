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
    public partial class Frm_TTCongNo_CUDAN : Form
    {
        public Frm_TTCongNo_CUDAN()
        {
            InitializeComponent();
        }

        private void Frm_TTCongNo_CUDAN_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaCongNo, MaCanHo, SoTienNo, NgayPhatSinh,HanNo,TrangThai,GhiChu FROM CongNo";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                dgv_dscn.DataSource = tb;
                rdr.Close();
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgv_dscn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_dscn.Rows[e.RowIndex];
            string MaCongNo = row.Cells["MaCongNo"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CongNo WHERE MaCongNo = N'" + MaCongNo + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mcn.Text = rdr["MaCongNo"].ToString();
                        if (rdr["NgayPhatSinh"] != DBNull.Value)
                            txt_ngayps.Text = Convert.ToDateTime(rdr["NgayPhatSinh"]).ToString("dd/MM/yyyy");
                        if (rdr["HanNo"] != DBNull.Value)
                            txt_hanno.Text = Convert.ToDateTime(rdr["HanNo"]).ToString("dd/MM/yyyy");
                        if (rdr["SoTienNo"] != DBNull.Value)
                            txt_sotien.Text = Convert.ToDecimal(rdr["SoTienNo"]).ToString("N0");
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Frm_CongNo frmCha = this.MdiParent as Frm_CongNo;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
    }
}
