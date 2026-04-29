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
        private void Frm_TTDGNS_CUDAN_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM DanhGiaNhanSu WHERE MaNhanSu='"+cls_chcecklogin.MaNhanVien+"'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dgvdsdg.DataSource = dt;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }
        private void dgvdsdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvdsdg.CurrentRow;
            string madanhgia = row.Cells["MaDanhGia"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM DanhGiaNhanSu WHERE MaDanhGia = N'" + madanhgia + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        txt_mdg.Text = rdr["MaDanhGia"].ToString();
                        txt_ns.Text = rdr["MaNhanSu"].ToString();
                        txt_kydg.Text = rdr["KyDanhGia"].ToString();                        
                        txt_nx.Text = rdr["NhanXet"].ToString();
                        txt_ngdg.Text = rdr["NgayDanhGia"].ToString();
                        txt_dtp.Text = rdr["DiemTacPhong"].ToString();
                        txt_dhx.Text = rdr["DiemHieuSuat"].ToString();
                        txt_dtd.Text = rdr["DiemThaiDo"].ToString();
                        txt_Tongd.Text = rdr["TongDiem"].ToString();
                        txt_nx.Text = rdr["NhanXet"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CellClick: " + ex.Message);
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu frmCha = this.MdiParent as frm_DanhGiaNhanSu;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
    }
}
