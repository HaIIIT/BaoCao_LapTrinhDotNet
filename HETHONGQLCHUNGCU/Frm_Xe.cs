using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Xe : Form
    {
        string IDXe = "";
        public Frm_Xe()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        public void LoadData(   )
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaXe, MaCuDan, BienSo, LoaiXe, HangXe, MauSac, NgayDangKi,TrangThai FROM Xe";
                SqlDataAdapter ad = new SqlDataAdapter(sel, ketnoi.conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvXe.DataSource = dt;
                dgvXe.Columns["MaXe"].HeaderText = "Mã Xe";
                dgvXe.Columns["MaCuDan"].HeaderText = "Mã Cư Dân";
                dgvXe.Columns["BienSo"].HeaderText = "Biển Số";
                dgvXe.Columns["LoaiXe"].HeaderText = "Loại Xe";
                dgvXe.Columns["HangXe"].HeaderText = "Hãng Xe";
                dgvXe.Columns["MauSac"].HeaderText = "Màu Sắc";
                dgvXe.Columns["NgayDangKi"].HeaderText = "Ngày Đăng Kí";
                dgvXe.Columns["TrangThai"].HeaderText = "Trạng Thái";

                ketnoi.dongketnoi();
            }
            //đổ dữ liệu vào combobox
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT DISTINCT LoaiXe FROM Xe";
                SqlDataAdapter ad = new SqlDataAdapter(sel, ketnoi.conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                DataRow row = dt.NewRow();
                row["LoaiXe"] = "Xe Mô Tô";
                dt.Rows.InsertAt(row, 0);

                cbx_LoaiXe.DataSource = dt;
                cbx_LoaiXe.DisplayMember = "LoaiXe";
                cbx_LoaiXe.ValueMember = "LoaiXe";
                ketnoi.dongketnoi();
            }

        }
        private void Frm_Xe_Load(object sender, EventArgs e)
        {
            LoadData();
            

        }

        private void btn_add_Click(object sender, EventArgs e)
        {// 1. Kiểm tra đầu vào
            /*if (string.IsNullOrEmpty(txt_MaXe.Text) || string.IsNullOrEmpty(txt_MaCuDan.Text) ||
                string.IsNullOrEmpty(txt_BienSo.Text) || string.IsNullOrEmpty(cbx_LoaiXe.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string SQl = "INSERT INTO Xe(MaXe, MaCuDan, BienSo, LoaiXe, HangXe, MauSac, NgayDangKi, TrangThai, MaDichVu) " +
                                 "VALUES (@MaXe, @MaCuDan, @BienSo, @LoaiXe, @HangXe, @MauSac, @NgayDangKi, @TrangThai, 'DV00001')";

                    SqlCommand cmd = new SqlCommand(SQl, ketnoi.conn);

                    // 2. Thêm tham số (Sử dụng đúng kiểu dữ liệu giúp tránh lỗi định dạng)
                    cmd.Parameters.AddWithValue("@MaXe", txt_MaXe.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaCuDan", txt_MaCuDan.Text.Trim());
                    cmd.Parameters.AddWithValue("@BienSo", txt_BienSo.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiXe", cbx_LoaiXe.Text);
                    cmd.Parameters.AddWithValue("@HangXe", txt_HangXe.Text.Trim());
                    cmd.Parameters.AddWithValue("@MauSac", txt_MauSac.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayDangKi", dtb_NgayDangKy.Value);

                    // Xử lý RadioButton cho trạng thái
                    string trangThai = rdbDangGui.Checked ? "Đang gửi" : "Ngừng gửi";
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    // 3. Thực thi trực tiếp từ SqlCommand thay vì gọi hàm capnhat(string)
                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadData();

                        // Cập nhật dữ liệu tại Frm_BaiXe nếu đang mở
                        Frm_BaiXe frmBaiXe = (Frm_BaiXe)Application.OpenForms["Frm_BaiXe"];
                        if (frmBaiXe != null)
                        {
                            frmBaiXe.LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ketnoi.dongketnoi();
            }
            */
            Connection conn = new Connection();
             string sql = " select * from Xe ";
             SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
             SqlCommandBuilder cb = new SqlCommandBuilder(da);
             DataTable dt = new DataTable();
             da.Fill(dt);

             DataRow[] rowsToUpdate = dt.Select("MaXe = '" + txt_MaXe.Text+ "'");
             if (rowsToUpdate.Length == 0)
             {
                 DataRow row = dt.NewRow();
                 row["MaXe"] = txt_MaXe.Text;
                 row["MaCuDan"] = txt_MaCuDan.Text;
                 row["BienSo"] = txt_BienSo.Text;
                 row["LoaiXe"] = cbx_LoaiXe.SelectedValue.ToString();
                 row["HangXe"] = txt_HangXe.Text;
                 row["MauSac"] = txt_MauSac.Text;
                 row["NgayDangKi"] = dtb_NgayDangKy.Value;
                 if(rdbDangGui.Checked)
                     row["TrangThai"] = "Đang gửi";
                 else
                     row["TrangThai"] = "Ngừng gửi";
                row["MaDichVu"] = "DV00001";
                     dt.Rows.Add(row);
                 try
                 {
                     da.Update(dt);
                     MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     LoadData();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Lỗi khi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
             else
             {
                 MessageBox.Show("Không thể thêm xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }






        }
        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0)
            {
                return;
            }
            DataGridViewRow row = dgvXe.CurrentRow;
            IDXe = row.Cells["MaXe"].Value.ToString();
            string MaXe = row.Cells["MaXe"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if(ketnoi.moketnoi())
                {
                    string selStr= "SELECT MaXe, MaCuDan, BienSo, LoaiXe, HangXe, " +
                        "MauSac, NgayDangKi FROM Xe WHERE MaXe ='" + MaXe + "'";
                    SqlDataReader reader = ketnoi.truyvan(selStr);
                    if (reader.Read())
                    {
                        txt_MaXe.Text = reader["MaXe"].ToString().Trim();
                        txt_MaCuDan.Text = reader["MaCuDan"].ToString();
                        txt_BienSo.Text = reader["BienSo"].ToString();
                        cbx_LoaiXe.Text = reader["LoaiXe"].ToString();
                        txt_HangXe.Text = reader["HangXe"].ToString();
                        txt_MauSac.Text = reader["MauSac"].ToString();
                        dtb_NgayDangKy.Value = Convert.ToDateTime(reader["NgayDangKi"]);
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection conn= new Connection();
            string sql = " select * from Xe ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaXe = '" + IDXe + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row["MaCuDan"] = txt_MaCuDan.Text;
                row["BienSo"] = txt_BienSo.Text;
                row["LoaiXe"] = cbx_LoaiXe.Text;
                row["HangXe"] = txt_HangXe.Text;
                row["MauSac"] = txt_MauSac.Text;
                row["NgayDangKi"] = dtb_NgayDangKy.Value;
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Cập nhật xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
             else
            {
                MessageBox.Show("Không tìm thấy xe để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string sql = " select * from Xe ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn.conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow[] rowsToUpdate = dt.Select("MaXe = '" + txt_MaXe.Text + "'");
            if (rowsToUpdate.Length > 0)
            {
                DataRow row = rowsToUpdate[0];
                row.Delete();
                try
                {
                    da.Update(dt);
                    MessageBox.Show("Xóa xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /*
// ==================== HÀM KIỂM TRA DỮ LIỆU ====================
private bool KiemTraDuLieu()
{
if (txt_MaXe.Text.Trim() == "")
{
MessageBox.Show("Vui lòng nhập mã xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaXe.Focus();
return false;
}

if (txt_BienSo.Text.Trim() == "")
{
MessageBox.Show("Vui lòng nhập biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_BienSo.Focus();
return false;
}

if (txt_MaCuDan.Text.Trim() == "")
{
MessageBox.Show("Vui lòng nhập mã cư dân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaCuDan.Focus();
return false;
}

if (cbx_LoaiXe.Text.Trim() == "")
{
MessageBox.Show("Vui lòng chọn loại xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
cbx_LoaiXe.Focus();
return false;
}



return true;
}

// ==================== HÀM KIỂM TRA MÃ XE TỒN TẠI ====================
private bool KiemTraMaXeTonTai(string maXe)
{
bool tonTai = false;

using (SqlConnection conn = new SqlConnection(connectionString))
{
string sql = "SELECT COUNT(*) FROM Xe WHERE MaXe = @MaXe";
using (SqlCommand cmd = new SqlCommand(sql, conn))
{
cmd.Parameters.Add("@MaXe", SqlDbType.Char, 10).Value = maXe;
conn.Open();
int count = (int)cmd.ExecuteScalar();
tonTai = count > 0;
}
}

return tonTai;
}

// ==================== HÀM KIỂM TRA BIỂN SỐ TỒN TẠI ====================
private bool KiemTraBienSoTonTai(string bienSo, string maXe = "")
{
bool tonTai = false;

using (SqlConnection conn = new SqlConnection(connectionString))
{
string sql = "SELECT COUNT(*) FROM Xe WHERE BienSo = @BienSo";
if (maXe != "")
{
sql += " AND MaXe <> @MaXe";
}

using (SqlCommand cmd = new SqlCommand(sql, conn))
{
cmd.Parameters.Add("@BienSo", SqlDbType.NVarChar, 20).Value = bienSo;

if (maXe != "")
cmd.Parameters.Add("@MaXe", SqlDbType.Char, 10).Value = maXe;

conn.Open();
int count = (int)cmd.ExecuteScalar();
tonTai = count > 0;
}
}

return tonTai;
}

// ==================== THÊM ====================
private void btn_Them_Click(object sender, EventArgs e)
{
try
{
if (!KiemTraDuLieu())
return;

string maXe = txt_MaXe.Text.Trim();
string bienSo = txt_BienSo.Text.Trim();
string maCuDan = txt_MaCuDan.Text.Trim();
string loaiXe = cbx_LoaiXe.Text.Trim();
string hangXe = txt_HangXe.Text.Trim();
string mauSac = txt_MauSac.Text.Trim();
DateTime ngayDangKy = dtb_NgayDangKy.Value.Date;


if (KiemTraMaXeTonTai(maXe))
{
MessageBox.Show("Mã xe đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaXe.Focus();
return;
}

if (KiemTraBienSoTonTai(bienSo))
{
MessageBox.Show("Biển số đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_BienSo.Focus();
return;
}

using (SqlConnection conn = new SqlConnection(connectionString))
{
string sql = @"INSERT INTO Xe
(MaXe, MaCuDan, BienSo, LoaiXe, HangXe, MauSac, NgayDangKy, TrangThai)
VALUES
(@MaXe, @MaCuDan, @BienSo, @LoaiXe, @HangXe, @MauSac, @NgayDangKy, @TrangThai)";

using (SqlCommand cmd = new SqlCommand(sql, conn))
{
cmd.Parameters.Add("@MaXe", SqlDbType.Char, 10).Value = maXe;
cmd.Parameters.Add("@MaCuDan", SqlDbType.Char, 10).Value = maCuDan;
cmd.Parameters.Add("@BienSo", SqlDbType.NVarChar, 20).Value = bienSo;
cmd.Parameters.Add("@LoaiXe", SqlDbType.NVarChar, 30).Value = loaiXe;
cmd.Parameters.Add("@HangXe", SqlDbType.NVarChar, 50).Value = string.IsNullOrEmpty(hangXe) ? (object)DBNull.Value : hangXe;
cmd.Parameters.Add("@MauSac", SqlDbType.NVarChar, 30).Value = string.IsNullOrEmpty(mauSac) ? (object)DBNull.Value : mauSac;
cmd.Parameters.Add("@NgayDangKy", SqlDbType.Date).Value = ngayDangKy;


conn.Open();
int rows = cmd.ExecuteNonQuery();

if (rows > 0)
{
MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
LamMoi();
}
else
{
MessageBox.Show("Thêm xe thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}
}
catch (SqlException ex)
{
MessageBox.Show("Lỗi SQL khi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception ex)
{
MessageBox.Show("Lỗi khi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

// ==================== SỬA ====================
private void btn_Sua_Click(object sender, EventArgs e)
{
try
{
if (!KiemTraDuLieu())
return;

string maXe = txt_MaXe.Text.Trim();
string bienSo = txt_BienSo.Text.Trim();
string maCuDan = txt_MaCuDan.Text.Trim();
string loaiXe = cbx_LoaiXe.Text.Trim();
string hangXe = txt_HangXe.Text.Trim();
string mauSac = txt_MauSac.Text.Trim();
DateTime ngayDangKy = dtb_NgayDangKy.Value.Date;


if (!KiemTraMaXeTonTai(maXe))
{
MessageBox.Show("Mã xe không tồn tại để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaXe.Focus();
return;
}

if (KiemTraBienSoTonTai(bienSo, maXe))
{
MessageBox.Show("Biển số đã tồn tại ở xe khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_BienSo.Focus();
return;
}

using (SqlConnection conn = new SqlConnection(connectionString))
{
string sql = @"UPDATE Xe
SET MaCuDan = @MaCuDan,
  BienSo = @BienSo,
  LoaiXe = @LoaiXe,
  HangXe = @HangXe,
  MauSac = @MauSac,
  NgayDangKy = @NgayDangKy,
  TrangThai = @TrangThai
WHERE MaXe = @MaXe";

using (SqlCommand cmd = new SqlCommand(sql, conn))
{
cmd.Parameters.Add("@MaXe", SqlDbType.Char, 10).Value = maXe;
cmd.Parameters.Add("@MaCuDan", SqlDbType.Char, 10).Value = maCuDan;
cmd.Parameters.Add("@BienSo", SqlDbType.NVarChar, 20).Value = bienSo;
cmd.Parameters.Add("@LoaiXe", SqlDbType.NVarChar, 30).Value = loaiXe;
cmd.Parameters.Add("@HangXe", SqlDbType.NVarChar, 50).Value = string.IsNullOrEmpty(hangXe) ? (object)DBNull.Value : hangXe;
cmd.Parameters.Add("@MauSac", SqlDbType.NVarChar, 30).Value = string.IsNullOrEmpty(mauSac) ? (object)DBNull.Value : mauSac;
cmd.Parameters.Add("@NgayDangKy", SqlDbType.Date).Value = ngayDangKy;


conn.Open();
int rows = cmd.ExecuteNonQuery();

if (rows > 0)
{
MessageBox.Show("Sửa xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
LamMoi();
}
else
{
MessageBox.Show("Sửa xe thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}
}
catch (SqlException ex)
{
MessageBox.Show("Lỗi SQL khi sửa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception ex)
{
MessageBox.Show("Lỗi khi sửa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

// ==================== XÓA ====================
private void btn_Xoa_Click(object sender, EventArgs e)
{
try
{
string maXe = txt_MaXe.Text.Trim();

if (maXe == "")
{
MessageBox.Show("Vui lòng nhập mã xe cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaXe.Focus();
return;
}

if (!KiemTraMaXeTonTai(maXe))
{
MessageBox.Show("Mã xe không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
txt_MaXe.Focus();
return;
}

DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa xe này không?",
                 "Xác nhận xóa",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

if (result == DialogResult.No)
return;

using (SqlConnection conn = new SqlConnection(connectionString))
{
string sql = "DELETE FROM Xe WHERE MaXe = @MaXe";

using (SqlCommand cmd = new SqlCommand(sql, conn))
{
cmd.Parameters.Add("@MaXe", SqlDbType.Char, 10).Value = maXe;

conn.Open();
int rows = cmd.ExecuteNonQuery();

if (rows > 0)
{
MessageBox.Show("Xóa xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
LamMoi();
}
else
{
MessageBox.Show("Xóa xe thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}
}
catch (SqlException ex)
{
MessageBox.Show("Lỗi SQL khi xóa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception ex)
{
MessageBox.Show("Lỗi khi xóa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

// ==================== LÀM MỚI ====================
private void btn_LamMoi_Click(object sender, EventArgs e)
{
LamMoi();
}

private void LamMoi()
{
txt_MaXe.Clear();
txt_BienSo.Clear();
txt_MaCuDan.Clear();
txt_HangXe.Clear();
txt_MauSac.Clear();

cbx_LoaiXe.SelectedIndex = -1;
dtb_NgayDangKy.Value = DateTime.Now;

txt_MaXe.Focus();
}

private void Frm_Xe_Load(object sender, EventArgs e)
{

}
*/

    }
}