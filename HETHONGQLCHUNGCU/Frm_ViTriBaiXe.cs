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
    public partial class Frm_ViTriBaiXe : Form
    {
        string MVT = "";
        public Frm_ViTriBaiXe()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        public void LoadData()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                try
                {
                    //  Đổ dữ liệu vào dgv
                    string sqlGird = "SELECT MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai FROM ViTriBaiXe";
                    SqlDataAdapter adGrid = new SqlDataAdapter(sqlGird, ketnoi.conn);
                    DataTable dtGrid = new DataTable();
                    adGrid.Fill(dtGrid);
                    dgvViTriBaiXe.DataSource = dtGrid;

                    //  Đổ dữ liệu vào cbx
                    string sqlCombo = "SELECT DISTINCT LoaiCho FROM ViTriBaiXe";
                    SqlDataAdapter adCombo = new SqlDataAdapter(sqlCombo, ketnoi.conn);
                    DataTable dtCombo = new DataTable();
                    adCombo.Fill(dtCombo);

                    cbx_LoaiCho.DataSource = dtCombo;
                    cbx_LoaiCho.DisplayMember = "LoaiCho";
                    cbx_LoaiCho.ValueMember = "LoaiCho";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {

                    ketnoi.dongketnoi();
                }
            }
        }

        private void Frm_ViTriBaiXe_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvViTriBaiXe.Columns["MaViTri"].HeaderText = "Mã Vị Trí";
            dgvViTriBaiXe.Columns["KhuVuc"].HeaderText = "Khu Vực";
            dgvViTriBaiXe.Columns["Tang"].HeaderText = "Tầng";
            dgvViTriBaiXe.Columns["SoCho"].HeaderText = "Số Chỗ";
            dgvViTriBaiXe.Columns["LoaiCho"].HeaderText = "Loại Chỗ";
            dgvViTriBaiXe.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        private void dgvViTriBaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvViTriBaiXe.CurrentRow;
            MVT = row.Cells["MaViTri"].Value.ToString();
            string MaViTri = row.Cells["MaViTri"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT MaViTri, KhuVuc, Tang," +
                        " SoCho, LoaiCho, TrangThai FROM ViTriBaiXe WHERE MaViTri ='" + MaViTri + "'";
                    SqlDataReader reader = ketnoi.truyvan(selStr);
                    if (reader.Read())
                    {
                        txt_MaViTri.Text = reader["MaViTri"].ToString().Trim();
                        txt_KhuVuc.Text = reader["KhuVuc"].ToString();
                        txt_Tang.Text = reader["Tang"].ToString();
                        txt_SoCho.Text = reader["SoCho"].ToString();
                        cbx_LoaiCho.Text = reader["LoaiCho"].ToString();
                        string trangThai = reader["TrangThai"].ToString();
                    }
                    reader.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = " select * from ViTriBaiXe ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaViTri = '" + txt_MaViTri.Text + "'");
            if (rowsToUpdate.Length == 0)
            {
                DataRow row = dt.NewRow();
                row["MaViTri"] = txt_MaViTri.Text;
                row["KhuVuc"] = txt_KhuVuc.Text;
                row["Tang"] = txt_Tang.Text;
                row["SoCho"] = txt_SoCho.Text;
                row["LoaiCho"] = cbx_LoaiCho.SelectedValue.ToString();
                if (rdbTrong.Checked)
                    row["TrangThai"] = "Trống";
                else if (rdbDangSuDung.Checked)
                    row["TrangThai"] = "Đã Thuê";
                else if (rdbBaoTri.Checked)
                    row["TrangThai"] = "Bảo Trì";
                dt.Rows.Add(row);


                try
                {
                    da.Update(dt);
                    MessageBox.Show("Thêm vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi Thêm vị trí bãi xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không Thêm vị trí bãi xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = " select * from ViTriBaiXe ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaViTri = '" + txt_MaViTri.Text + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row["MaViTri"] = txt_MaViTri.Text;
                row["KhuVuc"] = txt_KhuVuc.Text;
                row["Tang"] = txt_Tang.Text;
                row["SoCho"] = txt_SoCho.Text;
                row["LoaiCho"] = cbx_LoaiCho.Text;
                if (rdbTrong.Checked)
                {
                    row["TrangThai"] = "Trống";
                }
                else if (rdbDangSuDung.Checked)
                {
                    row["TrangThai"] = "Đã Thuê";
                }
                else if (rdbBaoTri.Checked)
                {
                    row["TrangThai"] = "Bảo Trì";
                }

                try
                {
                    da.Update(dt);
                    MessageBox.Show("Cập nhật vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật vị trí bãi xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy vị trí bãi xe để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = " select * from ViTriBaiXe ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaViTri = '" + txt_MaViTri.Text + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row.Delete();
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Xóa Vị Trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Mã lỗi 547 là lỗi vi phạm ràng buộc khóa ngoại
                    {
                        MessageBox.Show("Không thể xóa vị trí này vì đang có dữ liệu gửi xe liên quan. " +
                                        "Vui lòng kiểm tra lại bảng Gửi Xe!", "Lỗi vi phạm dữ liệu",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Vị Trí để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txt_KhuVuc.Clear();
            txt_MaViTri.Clear();
            txt_Tang.Clear();
            txt_SoCho.Clear();
            cbx_LoaiCho.SelectedIndex = 0;
            rdbBaoTri.Checked = false;
            rdbDangSuDung.Checked = false;
            rdbTrong.Checked = false;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


    

