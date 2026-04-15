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
        string strConn = @"Data Source=.;Initial Catalog=QLChungCu;Integrated Security=True";
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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
        private bool KiemTraDuLieu()
        {
            if (txt_MaViTri.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return false;
            }

            if (txt_KhuVuc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_KhuVuc.Focus();
                return false;
            }

            if (txt_Tang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tầng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tang.Focus();
                return false;
            }

            if (txt_SoCho.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoCho.Focus();
                return false;
            }

            int tang;
            if (!int.TryParse(txt_Tang.Text.Trim(), out tang))
            {
                MessageBox.Show("Tầng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Tang.Focus();
                return false;
            }

            if (cbx_LoaiCho.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_LoaiCho.Focus();
                return false;
            }


            return true;
        }
        // =========================
        // HÀM KIỂM TRA MÃ ĐÃ TỒN TẠI
        // =========================
        private bool MaViTriDaTonTai(string maViTri)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "SELECT COUNT(*) FROM ViTriBaiXe WHERE MaViTri = @MaViTri";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaViTri", maViTri);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
        // =========================
        // HÀM LÀM MỚI
        // =========================
        private void LamMoi()
        {
            txt_MaViTri.Clear();
            txt_KhuVuc.Clear();
            txt_Tang.Clear();
            txt_SoCho.Clear();

            if (cbx_LoaiCho.Items.Count > 0)
                cbx_LoaiCho.SelectedIndex = 0;

     
            txt_MaViTri.Focus();
        }
        // =========================
        // THÊM
        // =========================
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            string maViTri = txt_MaViTri.Text.Trim();

            if (MaViTriDaTonTai(maViTri))
            {
                MessageBox.Show("Mã vị trí đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"INSERT INTO ViTriBaiXe
                               (MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai)
                               VALUES
                               (@MaViTri, @KhuVuc, @Tang, @SoCho, @LoaiCho, @TrangThai)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaViTri", txt_MaViTri.Text.Trim());
                cmd.Parameters.AddWithValue("@KhuVuc", txt_KhuVuc.Text.Trim());
                cmd.Parameters.AddWithValue("@Tang", int.Parse(txt_Tang.Text.Trim()));
                cmd.Parameters.AddWithValue("@SoCho", txt_SoCho.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiCho", cbx_LoaiCho.Text.Trim());
        

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // =========================
        // SỬA
        // =========================
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            string maViTri = txt_MaViTri.Text.Trim();

            if (!MaViTriDaTonTai(maViTri))
            {
                MessageBox.Show("Không tìm thấy mã vị trí để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn sửa vị trí này không?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"UPDATE ViTriBaiXe
                               SET KhuVuc = @KhuVuc,
                                   Tang = @Tang,
                                   SoCho = @SoCho,
                                   LoaiCho = @LoaiCho,
                                   TrangThai = @TrangThai
                               WHERE MaViTri = @MaViTri";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaViTri", txt_MaViTri.Text.Trim());
                cmd.Parameters.AddWithValue("@KhuVuc", txt_KhuVuc.Text.Trim());
                cmd.Parameters.AddWithValue("@Tang", int.Parse(txt_Tang.Text.Trim()));
                cmd.Parameters.AddWithValue("@SoCho", txt_SoCho.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiCho", cbx_LoaiCho.Text.Trim());
             

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // =========================
        // XÓA
        // =========================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaViTri.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã vị trí cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return;
            }

            string maViTri = txt_MaViTri.Text.Trim();

            if (!MaViTriDaTonTai(maViTri))
            {
                MessageBox.Show("Mã vị trí không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa vị trí này không?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "DELETE FROM ViTriBaiXe WHERE MaViTri = @MaViTri";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaViTri", maViTri);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa dữ liệu!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // =========================
        // TÌM THEO MÃ VỊ TRÍ
        // =========================
        private void TimViTri()
        {
            if (txt_MaViTri.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã vị trí để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaViTri.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"SELECT MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai
                               FROM ViTriBaiXe
                               WHERE MaViTri = @MaViTri";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaViTri", txt_MaViTri.Text.Trim());

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txt_MaViTri.Text = dr["MaViTri"].ToString().Trim();
                        txt_KhuVuc.Text = dr["KhuVuc"].ToString().Trim();
                        txt_Tang.Text = dr["Tang"].ToString().Trim();
                        txt_SoCho.Text = dr["SoCho"].ToString().Trim();
                        cbx_LoaiCho.Text = dr["LoaiCho"].ToString().Trim();
                        
                        MessageBox.Show("Đã tìm thấy vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã vị trí này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================
        // LÀM MỚI
        // =========================
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        // =========================
        // TÌM KHI NHẤN ENTER Ở txt_MaViTri
        // =========================
        private void txt_MaViTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimViTri();
                e.SuppressKeyPress = true;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */
    }
}


    

