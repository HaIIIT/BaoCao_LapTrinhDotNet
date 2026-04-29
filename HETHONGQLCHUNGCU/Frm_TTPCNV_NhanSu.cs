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
    public partial class Frm_TTPCNV_NhanSu : Form
    {
        string IDPC = "";
        public Frm_TTPCNV_NhanSu()
        {
            InitializeComponent();
        }
        void load_cbx_trangthai()
        {
            cbx_tt.Items.Clear();
            cbx_tt.Items.Add("--Chọn Trạng Thái--");
            cbx_tt.Items.Add("Hoàn Thành");
            cbx_tt.Items.Add("Chưa Hoàn Thành");
            cbx_tt.Items.Add("Chưa Thực Hiện");
            cbx_tt.Items.Add("Tạm Dừng");
            cbx_tt.SelectedIndex = 0;
        }
        void load_nhiemvu_theo_nhansu()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT MaPhanCong, TieuDeCongViec, NoiDung, NgayGiao, HanHoanThanh, MucDoUuTien, TrangThai " +
                                 "FROM PhanCongNhiemVu " +
                                 "WHERE MaNhanSu = N'" + cls_chcecklogin.MaNhanVien + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dsnhiemvu.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhiệm vụ: " + ex.Message);
            }
        }
        void tracuu_theongay()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    DateTime ngay = dtp_lichnhiemvu.Value.Date;

                    string sql = "SELECT MaPhanCong, TieuDeCongViec, NoiDung, NgayGiao, HanHoanThanh, MucDoUuTien, TrangThai " +
                                 "FROM PhanCongNhiemVu " +
                                 "WHERE NgayGiao >= '" + ngay.ToString("yyyy-MM-dd") + "' " +
                                 "AND NgayGiao < '" + ngay.AddDays(1).ToString("yyyy-MM-dd") + "'";

                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();

                    dgv_dsnhiemvu.DataSource = tb;

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu: " + ex.Message);
            }
        }
        private void Frm_TTPCNV_NhanSu_Load(object sender, EventArgs e)
        {
            btn_load1.Visible = false;
            load_cbx_trangthai();
            load_nhiemvu_theo_nhansu();
            btn_load.Visible = false;
            btn_tracuu.Visible = true;
            dtp_lichnhiemvu.Value=DateTime.Now;
        }

        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            
            tracuu_theongay();
            btn_load.Visible = true;
            btn_tracuu.Visible = false;
            
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            load_nhiemvu_theo_nhansu();
            btn_load.Visible=false;
            btn_tracuu.Visible=true;
        }

        private void dgv_dsnhiemvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv_dsnhiemvu.CurrentRow == null) return;

            DataGridViewRow row = dgv_dsnhiemvu.CurrentRow;

            IDPC = row.Cells["MaPhanCong"].Value.ToString();

            txt_nd.Text = row.Cells["NoiDung"].Value.ToString();

            if (row.Cells["NgayGiao"].Value != DBNull.Value && row.Cells["NgayGiao"].Value != null)
            {
                txt_nggiao.Text = Convert.ToDateTime(row.Cells["NgayGiao"].Value).ToString("dd/MM/yyyy");
            }
            else
            {
                txt_nggiao.Clear();
            }

            if (row.Cells["HanHoanThanh"].Value != DBNull.Value && row.Cells["HanHoanThanh"].Value != null)
            {
                txt_hanhoanthanh.Text = Convert.ToDateTime(row.Cells["HanHoanThanh"].Value).ToString("dd/MM/yyyy");
            }
            else
            {
                txt_hanhoanthanh.Clear();
            }

            string trangthai = row.Cells["TrangThai"].Value.ToString();
            cbx_tt.Text = trangthai;

            if (trangthai == "Hoàn Thành")
            {
                btn_check.Visible = false;
            }
            else
            {
                btn_check.Visible = true;
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (IDPC == "")
            {
                MessageBox.Show("Vui lòng chọn nhiệm vụ cần cập nhật!");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "UPDATE PhanCongNhiemVu " +
                                 "SET TrangThai = N'Hoàn Thành' " +
                                 "WHERE MaPhanCong = N'" + IDPC + "'";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật trạng thái thành Hoàn Thành!");
                    cbx_tt.Text = "Hoàn Thành";
                    btn_check.Visible = false;
                    ketnoi.dongketnoi();
                    tracuu_theongay(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message);
            }
            btn_load1.Visible = true;
        }

        private void btn_load1_Click(object sender, EventArgs e)
        {
            load_nhiemvu_theo_nhansu();
            btn_load1.Visible = false;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Frm_BPCNV frmCha = this.MdiParent as Frm_BPCNV;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
    }
}
