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

        private void btn_add_Click(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(txt_MaViTri.Text) || string.IsNullOrEmpty(txt_KhuVuc.Text) || string.IsNullOrEmpty(txt_Tang.Text) || string.IsNullOrEmpty(txt_SoCho.Text) || string.IsNullOrEmpty(cbx_LoaiCho.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int tang;
            if (!int.TryParse(txt_Tang.Text, out tang))
            {
                MessageBox.Show("Số tầng phải là chữ số!", "Lỗi nhập liệu");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string ins = "INSERT INTO ViTriBaiXe (MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai) VALUES (@MaViTri, @KhuVuc, @Tang, @SoCho, @LoaiCho, @TrangThai)";
                    SqlCommand cmd = new SqlCommand(ins, ketnoi.conn);
                    cmd.Parameters.AddWithValue("@MaViTri", txt_MaViTri.Text);
                    cmd.Parameters.AddWithValue("@KhuVuc", txt_KhuVuc.Text);
                    cmd.Parameters.AddWithValue("@Tang", tang); 
                    cmd.Parameters.AddWithValue("@SoCho", txt_SoCho.Text);
                    cmd.Parameters.AddWithValue("@LoaiCho", cbx_LoaiCho.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", "Trống");

                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        Frm_BaiXe frmBaiXe= (Frm_BaiXe)Application.OpenForms["Frm_BaiXe"];
                        if (frmBaiXe != null)
                        {
                            frmBaiXe.LoadData();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                ketnoi.dongketnoi();
            }*/
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
                if(rdbTrong.Checked)
                {
                    row["TrangThai"] = "Trống";
                }
                else if(rdbDangSuDung.Checked)
                {
                    row["TrangThai"] = "Đã Thuê";
                }
                else if(rdbBaoTri.Checked)
                {
                    row["TrangThai"] = "Bảo Trì";
                }    

                    try
                    {
                        da.Update(dt);
                        MessageBox.Show("Cập nhật vị trí bãi xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
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


    

