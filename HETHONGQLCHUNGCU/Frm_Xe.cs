using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Xe : Form
    {
        // Đổi lại chuỗi kết nối cho đúng máy của bạn
        private string connectionString = @"Data Source=.;Initial Catalog=QLChungCu;Integrated Security=True";

        public Frm_Xe()
        {
            InitializeComponent();
        }

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

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}