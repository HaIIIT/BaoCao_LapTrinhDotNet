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
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT dk.MaDangKy, dk.MaDichVu, dk.MaCanHo, dk.NgayDangKi, dk.SoLuong, dk.TrangThai, dv.TenDichVu " +
                                 "FROM DangKiDichVu dk " +
                                 "JOIN DanhMucDichVu dv ON dk.MaDichVu = dv.MaDichVu " +
                                 "JOIN HopDong hd ON dk.MaCanHo = hd.MaCanHo " +
                                 "WHERE hd.MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dataGridView1.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                ketnoi.dongketnoi();
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu frmCha = this.MdiParent as frm_Dangkydichvu;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.CurrentRow;
            string MaDangKy = row.Cells["MaDangKy"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT dk.MaDichVu, dv.TenDichVu, dk.NgayDangKi, dk.TrangThai " +
                         "FROM DangKiDichVu dk " +
                         "JOIN DanhMucDichVu dv ON dk.MaDichVu = dv.MaDichVu " +
                         "WHERE dk.MaDangKy = N'" + MaDangKy + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mdv.Text = rdr["MaDichVu"].ToString();
                        txt_tendv.Text = rdr["TenDichVu"].ToString();
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
                        if (rdr["NgayDangKi"] != DBNull.Value)
                        {
                            dtp_ngaydk.Value = Convert.ToDateTime(rdr["NgayDangKi"]);
                        }
                        else
                        {
                            dtp_ngaydk.Value = DateTime.Now;
                        }
                    }
                    rdr.Close();
                }ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
