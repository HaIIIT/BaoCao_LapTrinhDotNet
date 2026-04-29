using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_GuiXe : Form
    {
        string Guixe = "";
        public Frm_GuiXe()
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
                    string sel = "SELECT MaGuiXe, MaXe, MaViTri, NgayBatDau, NgayKetThuc, PhiGui, TrangThai FROM GuiXe";
                    SqlDataAdapter ad = new SqlDataAdapter(sel, ketnoi.conn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dgvGuiXe.DataSource = dt;

                    dgvGuiXe.Columns["MaGuiXe"].HeaderText = "Mã Gửi Xe";
                    dgvGuiXe.Columns["MaXe"].HeaderText = "Mã Xe";
                    dgvGuiXe.Columns["MaViTri"].HeaderText = "Mã Vị Trí";
                    dgvGuiXe.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                    dgvGuiXe.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                    dgvGuiXe.Columns["PhiGui"].HeaderText = "Phí Gửi";
                    dgvGuiXe.Columns["TrangThai"].HeaderText = "Trạng Thái";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo");
                }
                finally
                {
                    ketnoi.dongketnoi();
                }
            }
            else
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thất bại!", "Lỗi");
            }
        }
        private void Frm_GuiXe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvGuiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvGuiXe.CurrentRow;
            Guixe = row.Cells["MaGuiXe"].Value.ToString();
            string MaGuiXe = row.Cells["MaGuiXe"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT MaGuiXe, MaXe, MaViTri, NgayBatDau, NgayKetThuc, PhiGui, TrangThai " +
                        " FROM GuiXe WHERE MaGuiXe ='" + MaGuiXe + "'";
                    SqlDataReader reader = ketnoi.truyvan(selStr);
                    if (reader.Read())
                    {
                        txt_MaGui.Text = reader["MaGuiXe"].ToString().Trim();
                        txt_MaXe.Text = reader["MaXe"].ToString();
                        txt_MaViTri.Text = reader["MaViTri"].ToString();
                        dtp_BatDau.Value = Convert.ToDateTime(reader["NgayBatDau"].ToString());
                        dtp_KetThuc.Value = Convert.ToDateTime(reader["NgayKetThuc"].ToString());
                        txt_PhiGui.Text = reader["PhiGui"].ToString();
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
            string sql = "select * from GuiXe";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaGuiXe = '" + txt_MaGui.Text + "'");
            if (rowsToUpdate.Length == 0)
            {
                DataRow row = dt.NewRow();
                row["MaGuiXe"] = txt_MaGui.Text;
                row["MaXe"] = txt_MaXe.Text;
                row["MaViTri"] = txt_MaViTri.Text;
                row["NgayBatDau"] = dtp_BatDau.Value;
                row["NgayKetThuc"] = dtp_KetThuc.Value;
                row["PhiGui"] = txt_PhiGui.Text;
                if (rdbDathanhtoan.Checked)
                {
                    row["TrangThai"] = "Đã Thanh Toán";
                }
                else if (rdbChuaThanhToan.Checked)
                {
                    row["TrangThai"] = "Chưa Thanh Toán";
                }

                dt.Rows.Add(row);
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã Gửi Xe đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = "select * from GuiXe";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaGuiXe = '" + Guixe + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row["MaGuiXe"] = txt_MaGui.Text;
                row["MaXe"] = txt_MaXe.Text;
                row["MaViTri"] = txt_MaViTri.Text;
                row["NgayBatDau"] = dtp_BatDau.Value;
                row["NgayKetThuc"] = dtp_KetThuc.Value;
                row["PhiGui"] = txt_PhiGui.Text;
                if (rdbDathanhtoan.Checked)
                {
                    row["TrangThai"] = "Đã Thanh Toán";
                }
                else if (rdbChuaThanhToan.Checked)
                {
                    row["TrangThai"] = "Chưa Thanh Toán";
                }
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã Gửi Xe cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = "select * from GuiXe";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaGuiXe = '" + Guixe + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row.Delete();
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btn_Lammoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã Gửi Xe cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txt_MaGui.Clear();
            txt_MaViTri.Clear();
            txt_MaXe.Clear();
            txt_PhiGui.Clear();
            rdbChuaThanhToan.Checked = false;
            rdbDathanhtoan.Checked = false;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}