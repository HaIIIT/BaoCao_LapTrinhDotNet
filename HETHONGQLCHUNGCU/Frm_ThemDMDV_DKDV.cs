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
    public partial class Frm_ThemDMDV_DKDV : Form
    {
        string IDDV = "";
        public Frm_ThemDMDV_DKDV()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void load_dmdv()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaDichVu, TenDichVu, LoaiDichVu FROM DanhMucDichVu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dgvdmdv.DataSource = dt;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load: " + ex.Message);
            }
        }
        void lammoidl()
        {
            IDDV = "";
            txt_mdk.Clear();
            txttendv.Clear();
            txtdvt.Clear();
            txtdg.Clear();
            txtldv.Clear();
            txt_mt.Clear();
            rdb_dcc.Checked = false;
            rdb_ncc.Checked = false;
            txt_mdk.Enabled = true;
            dgvdmdv.ClearSelection();

        }
        private void Frm_ThemDMDV_DKDV_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaDichVu, TenDichVu, LoaiDichVu FROM DanhMucDichVu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dgvdmdv.DataSource = dt;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvdmdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvdmdv.CurrentRow;
            IDDV = row.Cells["MaDichVu"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM DanhMucDichVu WHERE MaDichVu = N'" + IDDV + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        txt_mdk.Text = rdr["MaDichVu"].ToString();
                        txttendv.Text = rdr["TenDichVu"].ToString();
                        txtdvt.Text = rdr["DonViTinh"].ToString();
                        txtdg.Text = rdr["DonGia"].ToString();
                        txtldv.Text = rdr["LoaiDichVu"].ToString();
                        txt_mt.Text = rdr["MoTa"].ToString();
                        string trangthai = rdr["TrangThai"].ToString().Trim();
                        rdb_dcc.Checked = false;
                        rdb_ncc.Checked = false;
                        if (trangthai == "Đang Cung Cấp")
                        {
                            rdb_dcc.Checked = true;
                        }
                        else if (trangthai == "Ngưng Cung Cấp")
                        {
                            rdb_ncc.Checked = true;
                        }
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_mdk.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã dịch vụ");
                txt_mdk.Focus();
                return;
            }

            if (txttendv.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên dịch vụ");
                txttendv.Focus();
                return;
            }
            if (txtdg.Text.Trim() == "")
            {
                MessageBox.Show("Nhập đơn giá");
                txtdg.Focus();
                return;
            }
            decimal dongia;
            if (!decimal.TryParse(txtdg.Text, out dongia))
            {
                MessageBox.Show("Đơn giá phải là số");
                return;
            }
            string trangthai = rdb_dcc.Checked ? "Đang Cung Cấp" :
                          rdb_ncc.Checked ? "Ngưng Cung Cấp" : "";
            if (trangthai == "")
            {
                MessageBox.Show("Chọn loại dịch vụ");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    // check trùng
                    string check = "SELECT MaDichVu FROM DanhMucDichVu WHERE MaDichVu=N'" + txt_mdk.Text + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã đã tồn tại");
                        rdr.Close();
                        return;
                    }
                    rdr.Close();
                    string sql = "INSERT INTO DanhMucDichVu " +
             "(MaDichVu, TenDichVu, DonViTinh, DonGia, LoaiDichVu, TrangThai, MoTa) " +
             "VALUES (" +
             "N'" + txt_mdk.Text.Trim() + "', " +
             "N'" + txttendv.Text.Trim() + "', " +
             "N'" + txtdvt.Text.Trim() + "', " +
             dongia + ", " +
             "N'" + txtldv.Text.Trim() + "', " +
             "N'" + trangthai + "', " +
             "N'" + txt_mt.Text.Trim() + "')";
                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        load_dmdv();
                        lammoidl();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (IDDV == "")
            {
                MessageBox.Show("Chọn dòng cần sửa");
                return;
            }

            decimal dongia;
            if (!decimal.TryParse(txtdg.Text, out dongia))
            {
                MessageBox.Show("Đơn giá phải là số");
                return;
            }

            string trangthai = rdb_dcc.Checked ? "Đang Cung Cấp" :
                          rdb_ncc.Checked ? "Ngưng Cung Cấp" : "";

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "UPDATE DanhMucDichVu SET " +
                                 "TenDichVu=N'" + txttendv.Text + "'," +
                                 "DonViTinh=N'" + txtdvt.Text + "'," +
                                 "DonGia=" + dongia + "," +
                                 "LoaiDichVu=N'" + trangthai + "'," +
                                 "MoTa=N'" + txt_mt.Text + "' " +
                                 "WHERE MaDichVu=N'" + IDDV + "'";

                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        load_dmdv();
                        lammoidl();

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDDV == "")
            {
                MessageBox.Show("Chọn dòng cần xóa");
                return;
            }

            if (MessageBox.Show("Xóa dịch vụ?", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "DELETE FROM DanhMucDichVu WHERE MaDichVu=N'" + IDDV + "'";

                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        load_dmdv();
                        lammoidl();

                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            lammoidl();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
