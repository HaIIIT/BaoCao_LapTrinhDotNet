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
    public partial class Frm_thongtinBPCNV : Form
    {
        string IDPC = "";
        public Frm_thongtinBPCNV()
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
        void load_cbx_mns()
        {
                Connection ketnoi = new Connection();
                try
                {
                    if (ketnoi.moketnoi())
                    {
                        string sql = "SELECT MaNhanSu, (MaNhanSu + ' - ' + HoTen) AS HienThi FROM NhanSu";
                        SqlDataReader rdr = ketnoi.truyvan(sql);
                        DataTable tb = new DataTable();
                        tb.Load(rdr);
                        rdr.Close();
                        DataRow r = tb.NewRow();
                        r["MaNhanSu"] = "";
                        r["HienThi"] = "-- Chọn nhân sự --";
                        tb.Rows.InsertAt(r, 0);
                        cbx_mns.DataSource = tb;
                        cbx_mns.DisplayMember = "HienThi";   
                        cbx_mns.ValueMember = "MaNhanSu";    
                        cbx_mns.SelectedIndex = 0;
                        ketnoi.dongketnoi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load nhân sự: " + ex.Message);
                }
        }
        string LayMucDo()
        {
            if (rdb_thap.Checked) return "Thấp";
            if (rdb_bth.Checked) return "Bình Thường";
            if (rdb_cao.Checked) return "Cao";
            if (rdb_kc.Checked) return "Khẩn Cấp";
            return "";
        }

        string LayTrangThai()
        {
            if (rdb_cth.Checked) return "Chưa Thực Hiện";
            if (rdb_dth.Checked) return "Đang Thực Hiện";
            if (rdb_ht.Checked) return "Hoàn Thành";
            if (rdb_td.Checked) return "Tạm Dừng";
            return "";
        }
        private void Frm_thongtinBPCNV_Load(object sender, EventArgs e)
        {
            load_cbx_mns();
            Connection ketnoi = new Connection();
            
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT MaPhanCong,MaNhanSu,TieuDeCongViec FROM PhanCongNhiemVu";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dspc.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgv_dspc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv_dspc.CurrentRow;
            IDPC = row.Cells["MaPhanCong"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM PhanCongNhiemVu WHERE MaPhanCong = '" + IDPC + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        txt_mpc.Text = rdr["MaPhanCong"].ToString();
                        txt_td.Text = rdr["TieuDeCongViec"].ToString();
                        txt_nd.Text = rdr["NoiDung"].ToString();
                        cbx_mns.SelectedValue = rdr["MaNhanSu"].ToString();
                        if (rdr["NgayGiao"] != DBNull.Value)
                            dtp_ng.Value = Convert.ToDateTime(rdr["NgayGiao"]);
                        if (rdr["HanHoanThanh"] != DBNull.Value)
                            dtp_hht.Value = Convert.ToDateTime(rdr["HanHoanThanh"]);
                        string mucdo = rdr["MucDoUuTien"].ToString();
                        rdb_thap.Checked = mucdo == "Thấp";
                        rdb_bth.Checked = mucdo == "Bình Thường";
                        rdb_cao.Checked = mucdo == "Cao";
                        rdb_kc.Checked = mucdo == "Khẩn Cấp";
                        string trangthai = rdr["TrangThai"].ToString();
                        rdb_cth.Checked = trangthai == "Chưa Thực Hiện";
                        rdb_dth.Checked = trangthai == "Đang Thực Hiện";
                        rdb_ht.Checked = trangthai == "Hoàn Thành";
                        rdb_td.Checked = trangthai == "Tạm Dừng";
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_mpc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phân công");
                txt_mpc.Focus();
                return;
            }

            if (cbx_mns.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân sự");
                return;
            }

            if (txt_td.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tiêu đề công việc");
                txt_td.Focus();
                return;
            }

            if (LayMucDo() == "")
            {
                MessageBox.Show("Vui lòng chọn mức độ");
                return;
            }

            if (LayTrangThai() == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }

            // ===== LẤY DỮ LIỆU =====
            string mpc = txt_mpc.Text.Trim();
            string mns = cbx_mns.SelectedValue.ToString();
            string td = txt_td.Text.Trim();
            string nd = txt_nd.Text.Trim();
            DateTime ngaygiao = dtp_ng.Value;
            DateTime hanht = dtp_hht.Value;
            string mucdo = LayMucDo();
            string trangthai = LayTrangThai();

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    // ===== CHECK TRÙNG =====
                    string check = "SELECT COUNT(*) FROM PhanCongNhiemVu WHERE MaPhanCong = '" + mpc + "'";
                    SqlCommand cmdCheck = new SqlCommand(check, ketnoi.conn);
                    int dem = (int)cmdCheck.ExecuteScalar();

                    if (dem > 0)
                    {
                        MessageBox.Show("Mã phân công đã tồn tại!");
                        ketnoi.dongketnoi();
                        return;
                    }

                    // ===== INSERT =====
                    string insert = "INSERT INTO PhanCongNhiemVu " +
                        "(MaPhanCong, MaNhanSu, TieuDeCongViec, NoiDung, NgayGiao, HanHoanThanh, MucDoUuTien, TrangThai) VALUES (" +
                        "N'" + mpc + "'," +
                        "N'" + mns + "'," +
                        "N'" + td + "'," +
                        "N'" + nd + "'," +
                        "'" + ngaygiao.ToString("yyyy-MM-dd") + "'," +
                        "'" + hanht.ToString("yyyy-MM-dd") + "'," +
                        "N'" + mucdo + "'," +
                        "N'" + trangthai + "')";

                    SqlCommand cmd = new SqlCommand(insert, ketnoi.conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!");
                    btn_lammoi_Click(sender, e);
                    Frm_thongtinBPCNV_Load(sender, e);

                    ketnoi.dongketnoi();

                    // ===== LOAD LẠI DGV =====
                    Frm_thongtinBPCNV_Load(null, null);

                    // ===== RESET FORM =====
                    txt_mpc.Clear();
                    txt_td.Clear();
                    txt_nd.Clear();
                    cbx_mns.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (IDPC == "")
            {
                MessageBox.Show("Vui lòng chọn phân công cần cập nhật!");
                return;
            }
            if (txt_mpc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phân công");
                txt_mpc.Focus();
                return;
            }
            if (cbx_mns.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân sự");
                return;
            }
            if (txt_td.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tiêu đề công việc");
                txt_td.Focus();
                return;
            }
            if (LayMucDo() == "")
            {
                MessageBox.Show("Vui lòng chọn mức độ");
                return;
            }
            if (LayTrangThai() == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }
            string mpc = txt_mpc.Text.Trim();
            string mns = cbx_mns.SelectedValue.ToString();
            string td = txt_td.Text.Trim();
            string nd = txt_nd.Text.Trim();
            string mucdo = LayMucDo();
            string trangthai = LayTrangThai();
            DateTime ngaygiao = dtp_ng.Value;
            DateTime hanhoanthanh = dtp_hht.Value;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string update = "UPDATE PhanCongNhiemVu SET " +
                                    "MaPhanCong = N'" + mpc + "', " +
                                    "MaNhanSu = N'" + mns + "', " +
                                    "TieuDeCongViec = N'" + td + "', " +
                                    "NoiDung = N'" + nd + "', " +
                                    "NgayGiao = '" + ngaygiao.ToString("yyyy-MM-dd") + "', " +
                                    "HanHoanThanh = '" + hanhoanthanh.ToString("yyyy-MM-dd") + "', " +
                                    "MucDoUuTien = N'" + mucdo + "', " +
                                    "TrangThai = N'" + trangthai + "' " +
                                    "WHERE MaPhanCong = N'" + IDPC + "'";
                    SqlCommand cmd = new SqlCommand(update, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    btn_lammoi_Click(sender, e);
                    Frm_thongtinBPCNV_Load(sender, e);
                    ketnoi.dongketnoi();
                    Frm_thongtinBPCNV_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDPC == "")
            {
                MessageBox.Show("Vui lòng chọn phân công cần xóa!");
                return;
            }
            DialogResult tl = MessageBox.Show(
                "Bạn có chắc muốn xóa phân công này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (tl == DialogResult.No)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string del = "DELETE FROM PhanCongNhiemVu WHERE MaPhanCong = N'" + IDPC + "'";
                    SqlCommand cmd = new SqlCommand(del, ketnoi.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    btn_lammoi_Click(sender, e);
                    Frm_thongtinBPCNV_Load(sender, e);
                    ketnoi.dongketnoi();
                    Frm_thongtinBPCNV_Load(null, null);
                    IDPC = "";
                    txt_mpc.Clear();
                    txt_td.Clear();
                    txt_nd.Clear();
                    cbx_mns.SelectedIndex = 0;
                    dtp_ng.Value = DateTime.Now;
                    dtp_hht.Value = DateTime.Now;
                    rdb_thap.Checked = false;
                    rdb_bth.Checked = false;
                    rdb_cao.Checked = false;
                    rdb_kc.Checked = false;

                    rdb_cth.Checked = false;
                    rdb_dth.Checked = false;
                    rdb_ht.Checked = false;
                    rdb_td.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            IDPC = "";
            txt_mpc.Clear();
            txt_td.Clear();
            txt_nd.Clear();
            cbx_mns.SelectedIndex = 0;

            dtp_ng.Value = DateTime.Now;
            dtp_hht.Value = DateTime.Now;

            rdb_thap.Checked = false;
            rdb_bth.Checked = false;
            rdb_cao.Checked = false;
            rdb_kc.Checked = false;

            rdb_cth.Checked = false;
            rdb_dth.Checked = false;
            rdb_ht.Checked = false;
            rdb_td.Checked = false;
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            IDPC = "";
            txt_mpc.Clear();
            txt_td.Clear();
            txt_nd.Clear();
            cbx_mns.SelectedIndex = 0;

            dtp_ng.Value = DateTime.Now;
            dtp_hht.Value = DateTime.Now;

            rdb_thap.Checked = false;
            rdb_bth.Checked = false;
            rdb_cao.Checked = false;
            rdb_kc.Checked = false;

            rdb_cth.Checked = false;
            rdb_dth.Checked = false;
            rdb_ht.Checked = false;
            rdb_td.Checked = false;
        }
    }
}
