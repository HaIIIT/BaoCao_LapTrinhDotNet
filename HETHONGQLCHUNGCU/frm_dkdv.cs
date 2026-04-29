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
    public partial class frm_dkdv : Form
    {
        string IDDK = "";
        public frm_dkdv()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void loadCanHo()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaCanHo FROM CanHo";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaCanHo"] = "";
                row["MaCanHo"] = "-Click-";
                tb.Rows.InsertAt(row, 0);
                cbx_mch.DataSource = tb;
                cbx_mch.DisplayMember = "MaCanHo";
                cbx_mch.ValueMember = "MaCanHo";
            }
        }
        void loadDichVu()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaDichVu, MaDichVu + ' - ' + TenDichVu AS HienThi FROM DanhMucDichVu";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaDichVu"] = ""; 
                row["HienThi"] = "--Chọn dịch vụ--";
                tb.Rows.InsertAt(row, 0);
                cbx_mdv.DataSource = tb;
                cbx_mdv.DisplayMember = "HienThi";
                cbx_mdv.ValueMember = "MaDichVu" ;
                cbx_mdv.SelectedIndex = 0;
            }
        }
        private void frm_dkdv_Load(object sender, EventArgs e)
        {
            loadCanHo();
            loadDichVu();
            cbx_tt.Items.Clear();
            cbx_tt.Items.Add("--Chọn trạng thái--");
            cbx_tt.Items.Add("Chờ duyệt");
            cbx_tt.Items.Add("Đã duyệt");
            cbx_tt.Items.Add("Hủy");
            cbx_tt.SelectedIndex = 0;
            if (cls_chcecklogin.Quyen == 6) { 
                cbx_tt.SelectedItem = "Chờ duyệt";
                cbx_tt.Enabled = false;
            }
            else
            {
                cbx_tt.SelectedIndex = 0;
                cbx_tt.Enabled = true;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql1 = "";
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        sql1 = "SELECT dk.MaDangKy, dk.MaDichVu, dk.MaCanHo, dk.TrangThai " +
                               "FROM DangKiDichVu dk " +
                               "JOIN HopDong hd ON dk.MaCanHo = hd.MaCanHo " +
                               "WHERE hd.MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                    }
                    else 
                    {
                        sql1 = "SELECT MaDangKy, MaDichVu, MaCanHo, TrangThai FROM DangKiDichVu";
                    }
                    SqlDataReader rdr1 = ketnoi.truyvan(sql1);
                    DataTable tb1 = new DataTable();
                    tb1.Load(rdr1);
                    rdr1.Close();
                    dgv_dsdk.DataSource = tb1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgv_dsdk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv_dsdk.CurrentRow;
            IDDK= row.Cells["MaDangKy"].Value.ToString();
            string MaDK = row.Cells["MaDangKy"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM DangKiDichVu WHERE MaDangKy = '" + MaDK + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        txt_mdk.Text = rdr["MaDangKy"].ToString();
                        cbx_mch.SelectedValue = rdr["MaCanHo"].ToString();
                        cbx_mdv.SelectedValue = rdr["MaDichVu"].ToString();
                        if (rdr["NgayDangKi"] != DBNull.Value)
                            dtp_ngay.Value = Convert.ToDateTime(rdr["NgayDangKi"]);
                        if (rdr["SoLuong"] != DBNull.Value)
                            upd_sl.Value = Convert.ToDecimal(rdr["SoLuong"]);
                        cbx_tt.Text = rdr["TrangThai"].ToString();
                        txt_gc.Text = rdr["GhiChu"].ToString();
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

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            IDDK = "";
            txt_gc.Clear();
            txt_mdk.Clear();
            upd_sl.Value = upd_sl.Minimum;
            cbx_mch.SelectedIndex = 0;
            cbx_mdv.SelectedIndex = 0;
            if(cls_chcecklogin.Quyen == 6) 
            {
                cbx_tt.SelectedItem = "Chờ duyệt";
                cbx_tt.Enabled = false;
            }
            else
            {
                cbx_tt.SelectedIndex = 0;
                cbx_tt.Enabled = true;
            }
            dtp_ngay.Value = DateTime.Now;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mdk.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã đăng ký!");
                txt_mdk.Focus();
                return;
            }
            if (cbx_mch.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn căn hộ!");
                return;
            }
            if (cbx_mdv.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }
            if (upd_sl.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!");
                return;
            }
            string trangThai;
            if (cls_chcecklogin.Quyen == 6) 
            {
                trangThai = "Chờ duyệt";
            }
            else
            {
                if (cbx_tt.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!");
                    return;
                }
                trangThai = cbx_tt.Text.Trim();
            }
            Connection ketnoi = new Connection();
            try
            {            
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string check = "SELECT MaDangKy FROM DangKiDichVu WHERE MaDangKy = N'" + txt_mdk.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã đăng ký đã tồn tại!");
                        hople = false;
                    }rdr.Close();
                    string checkTrungDV = "SELECT MaDangKy FROM DangKiDichVu " +
                                          "WHERE MaCanHo = N'" + cbx_mch.SelectedValue.ToString() + "' " +
                                          "AND MaDichVu = N'" + cbx_mdv.SelectedValue.ToString() + "'";
                    SqlDataReader rdrTrung = ketnoi.truyvan(checkTrungDV);
                    if (rdrTrung.Read())
                    {
                        rdrTrung.Close();
                        MessageBox.Show("Căn hộ này đã đăng ký dịch vụ này rồi!");
                        return;
                    }
                    rdrTrung.Close();
                    if (hople)
                    {
                        string checkDV = "SELECT MaDichVu FROM DanhMucDichVu " +
                            "WHERE MaDichVu = N'" + cbx_mdv.SelectedValue.ToString() + "' " +
                            "AND TrangThai = N'Ngưng cung cấp'";
                        SqlDataReader rdrDV = ketnoi.truyvan(checkDV);
                        if (rdrDV.Read())
                        {
                            rdrDV.Close();
                            MessageBox.Show("Đăng ký không thành công vì dịch vụ đã ngưng cung cấp!",
                                "Hệ Thống Quản Lý Chung Cư",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        rdrDV.Close();
                        string ins = "INSERT INTO DangKiDichVu(MaDangKy, MaCanHo, MaDichVu, NgayDangKi, SoLuong, TrangThai, GhiChu) " +
                                     "VALUES(N'" + txt_mdk.Text.Trim() + "', N'" +
                                     cbx_mch.SelectedValue.ToString() + "', N'" +
                                     cbx_mdv.SelectedValue.ToString() + "', '" +
                                     dtp_ngay.Value.ToString("yyyy-MM-dd") + "', " +
                                     upd_sl.Value + ", N'" +
                                     trangThai + "', N'" +
                                     txt_gc.Text.Trim() + "')";
                        int ketqua = ketnoi.capnhat(ins);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Đăng Ký thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm_dkdv_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Đăng Ký không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string checkMa = "SELECT MaDangKy FROM DangKiDichVu " +
                                     "WHERE MaDangKy = N'" + txt_mdk.Text.Trim() + "' " +
                                     "AND MaDangKy <> N'" + IDDK + "'";
                    SqlDataReader rdrMa = ketnoi.truyvan(checkMa);
                    if (rdrMa.Read())
                    {
                        rdrMa.Close();
                        MessageBox.Show("Mã đăng ký đã tồn tại!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    rdrMa.Close();
                    // 2. kiểm tra dịch vụ có ngưng cung cấp không
                    string checkDV = "SELECT MaDichVu FROM DanhMucDichVu " +
                                     "WHERE MaDichVu = N'" + cbx_mdv.SelectedValue.ToString() + "' " +
                                     "AND TrangThai = N'Ngưng cung cấp'";
                    SqlDataReader rdrDV = ketnoi.truyvan(checkDV);
                    if (rdrDV.Read())
                    {
                        rdrDV.Close();
                        MessageBox.Show("Cập nhật không thành công vì dịch vụ đã ngưng cung cấp!",
                            "Hệ Thống Quản Lý Chung Cư",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    rdrDV.Close();
                    string trangThai;
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        trangThai = "Chờ duyệt";
                    }
                    else
                    {
                        if (cbx_tt.SelectedIndex <= 0)
                        {
                            MessageBox.Show("Vui lòng chọn trạng thái!");
                            return;
                        }
                        trangThai = cbx_tt.Text.Trim();
                    }
                    string upd = "UPDATE DangKiDichVu SET " +
                                 "MaDangKy = N'" + txt_mdk.Text.Trim() + "', " +
                                 "MaCanHo = N'" + cbx_mch.SelectedValue.ToString() + "', " +
                                 "MaDichVu = N'" + cbx_mdv.SelectedValue.ToString() + "', " +
                                 "NgayDangKi = '" + dtp_ngay.Value.ToString("yyyy-MM-dd") + "', " +
                                 "SoLuong = " + upd_sl.Value + ", " +
                                 "TrangThai = N'" + trangThai + "', " +
                                 "GhiChu = N'" + txt_gc.Text.Trim() + "' " +
                                 "WHERE MaDangKy = N'" + IDDK + "'";
                    int ketqua = ketnoi.capnhat(upd);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        IDDK = txt_mdk.Text.Trim();
                        frm_dkdv_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa đăng ký này?",
                "Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string check = "SELECT TrangThai FROM DangKiDichVu WHERE MaDangKy = N'" + IDDK + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        string tt = rdr["TrangThai"].ToString().Trim();
                        if (tt.Equals("Đã duyệt", StringComparison.OrdinalIgnoreCase))
                        {
                            rdr.Close();
                            MessageBox.Show("Không thể xóa đăng ký đã duyệt!",
                                "Hệ Thống Quản Lý Chung Cư",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    rdr.Close();
                    string del = "DELETE FROM DangKiDichVu WHERE MaDangKy = N'" + IDDK + "'";
                    int ketqua = ketnoi.capnhat(del);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Xóa thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        IDDK = "";
                        btn_lammoi_Click(sender, e);
                        frm_dkdv_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
