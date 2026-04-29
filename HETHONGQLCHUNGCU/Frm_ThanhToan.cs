using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_ThanhToan : Form
    {
        string IDTT = "";
        bool dangLoadCombo = false;
        public Frm_ThanhToan()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void BoChonPhuongThuc()
        {
            rdb_tm.Checked = false;
            rdb_ck.Checked = false;
            rdb_vdt.Checked = false;
        }
        void LoadTrangThai()
        {
            cbx_trangthai.Items.Clear();
            cbx_trangthai.Items.Add("-- Chọn trạng thái --");
            cbx_trangthai.Items.Add("Đã Thanh Toán");
            cbx_trangthai.Items.Add("Chưa Thanh Toán");
            cbx_trangthai.Items.Add("Chờ Xử Lý");
            cbx_trangthai.SelectedIndex = 0; 
        }
        void LoadHoaDon()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaHoaDon, MaCanHo,
                                  (MaHoaDon + N' - ' + MaCanHo) AS HienThi
                           FROM HoaDon";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaHoaDon"] = "";
                    r["MaCanHo"] = "";
                    r["HienThi"] = "-Click-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_mahoadon.DataSource = tb;
                    cbx_mahoadon.DisplayMember = "HienThi";
                    cbx_mahoadon.ValueMember = "MaHoaDon";
                    cbx_mahoadon.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load hóa đơn: " + ex.Message);
            }
        }
        void LoadCanHo()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaCanHo, MaCanHo AS HienThi
                           FROM CanHo";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaCanHo"] = "";
                    r["HienThi"] = "-CLick-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_mch.DataSource = tb;
                    cbx_mch.DisplayMember = "HienThi";
                    cbx_mch.ValueMember = "MaCanHo";
                    cbx_mch.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load căn hộ: " + ex.Message);
            }
        }
        void LoadCongNo()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaCongNo, MaCanHo,
                                  (MaCongNo + N' - ' + MaCanHo) AS HienThi
                           FROM CongNo";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaCongNo"] = "";
                    r["MaCanHo"] = "";
                    r["HienThi"] = "-Click-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_mcn.DataSource = tb;
                    cbx_mcn.DisplayMember = "HienThi";
                    cbx_mcn.ValueMember = "MaCongNo";
                    cbx_mcn.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load công nợ: " + ex.Message);
            }
        }
        void LoadThanhToan()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaThanhToan, MaHoaDon, SoTien
                                   FROM ThanhToan";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSTT.DataSource = tb;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thanh toán: " + ex.Message);
            }
        }
        string DinhDangTienVN(object sotien)
        {
            if (sotien == null || sotien == DBNull.Value)
                return "";
            decimal tien;
            if (decimal.TryParse(sotien.ToString(), out tien))
            {
                return string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", tien);
            }
            return "";
        }
        decimal LaySoTienTuHoaDon(string maHoaDon)
        {
            decimal soTien = 0;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT TongTien FROM HoaDon WHERE MaHoaDon = N'" + maHoaDon + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        decimal.TryParse(rdr["TongTien"].ToString(), out soTien);
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy số tiền từ hóa đơn: " + ex.Message);
            }
            return soTien;
        }
        decimal LaySoTienTuCongNo(string maCongNo)
        {
            decimal soTien = 0;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT SoTienNo FROM CongNo WHERE MaCongNo = N'" + maCongNo + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        decimal.TryParse(rdr["SoTienNo"].ToString(), out soTien);
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy số tiền từ công nợ: " + ex.Message);
            }
            return soTien;
        }
        string LayPhuongThuc()
        {
            if (rdb_tm.Checked) return "Tiền mặt";
            if (rdb_ck.Checked) return "Chuyển khoản";
            if (rdb_vdt.Checked) return "Ví điện tử";
            return "";
        }
        bool KiemTraChonHoaDonHoacCongNo()
        {
            string maHD = "";
            string maCN = "";

            if (cbx_mahoadon.SelectedValue != null && cbx_mahoadon.SelectedValue.ToString() != "System.Data.DataRowView")
                maHD = cbx_mahoadon.SelectedValue.ToString().Trim();

            if (cbx_mcn.SelectedValue != null && cbx_mcn.SelectedValue.ToString() != "System.Data.DataRowView")
                maCN = cbx_mcn.SelectedValue.ToString().Trim();

            if (maHD == "" && maCN == "")
            {
                MessageBox.Show("Vui lòng chọn Mã hóa đơn hoặc Mã công nợ");
                return false;
            }

            if (maHD != "" && maCN != "")
            {
                MessageBox.Show("Chỉ được chọn 1 trong 2: Mã hóa đơn hoặc Mã công nợ");
                return false;
            }

            return true;
        }
        decimal ChuyenTienVeSo(string tienText)
        {
            if (string.IsNullOrWhiteSpace(tienText))
                return 0;

            string raw = tienText.Replace(".", "")
                                 .Replace(",", "")
                                 .Replace("đ", "")
                                 .Trim();

            decimal tien;
            decimal.TryParse(raw, out tien);
            return tien;
        }
        void CapNhatTrangThaiLienQuan(string maHD, string maCN, string trangThai, SqlConnection conn)
        {
            try
            {
                if (maHD != "")
                {
                    string sqlHD = "UPDATE HoaDon SET TrangThai = N'" + trangThai + "' WHERE MaHoaDon = N'" + maHD + "'";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn);
                    cmdHD.ExecuteNonQuery();
                }
                if (maCN != "")
                {
                    string sqlCN = "UPDATE CongNo SET TrangThai = N'" + trangThai + "' WHERE MaCongNo = N'" + maCN + "'";
                    SqlCommand cmdCN = new SqlCommand(sqlCN, conn);
                    cmdCN.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái liên quan: " + ex.Message);
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_ThanhToan_Load(object sender, EventArgs e)
        {
            dangLoadCombo = true;
            LoadCanHo();
            LoadTrangThai();
            BoChonPhuongThuc();
            LoadHoaDon();
            LoadCongNo();
            LoadThanhToan();
            dangLoadCombo = false;
            dtp_ngaythanhtoan.Format = DateTimePickerFormat.Custom;
            dtp_ngaythanhtoan.CustomFormat = " ";
            dtp_ngaythanhtoan.ShowCheckBox = true;
            dtp_ngaythanhtoan.Checked = false;
        }
        private void dgvDSTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDSTT.CurrentRow == null)
                return;
            DataGridViewRow row = dgvDSTT.CurrentRow;
            if (row.Cells["MaThanhToan"].Value == null)
                return;
            string maThanhToan = row.Cells["MaThanhToan"].Value.ToString();
            IDTT = maThanhToan;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaThanhToan, MaCanHo, MaHoaDon, MaCongNo,
                                  NgayThanhToan, SoTien, NguoiThu, PhuongThuc,
                                  NoiDung, TrangThai
                           FROM ThanhToan
                           WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        // ===== MÃ =====
                        txt_mthanhtoan.Text = rdr["MaThanhToan"].ToString();
                        string maHD = rdr["MaHoaDon"] != DBNull.Value ? rdr["MaHoaDon"].ToString() : "";
                        string maCN = rdr["MaCongNo"] != DBNull.Value ? rdr["MaCongNo"].ToString() : "";
                        string maCH = rdr["MaCanHo"].ToString();
                        // ===== COMBO =====
                        dangLoadCombo = true;
                        cbx_mahoadon.SelectedValue = maHD == "" ? "" : maHD;
                        cbx_mcn.SelectedValue = maCN == "" ? "" : maCN;
                        cbx_mch.SelectedValue = maCH;
                        if (maHD != "")
                        {
                            cbx_mahoadon.Enabled = true;
                            cbx_mcn.Enabled = false;
                        }
                        else if (maCN != "")
                        {
                            cbx_mcn.Enabled = true;
                            cbx_mahoadon.Enabled = false;
                        }
                        else
                        {
                            cbx_mahoadon.Enabled = true;
                            cbx_mcn.Enabled = true;
                        }
                        dangLoadCombo = false;
                        // ===== SỐ TIỀN =====
                        txt_sotien.Text = DinhDangTienVN(rdr["SoTien"]);
                        // ===== NGÀY =====
                        if (rdr["NgayThanhToan"] != DBNull.Value)
                        {
                            dtp_ngaythanhtoan.Checked = true;
                            dtp_ngaythanhtoan.CustomFormat = "dd/MM/yyyy";
                            dtp_ngaythanhtoan.Value = Convert.ToDateTime(rdr["NgayThanhToan"]);
                        }
                        else
                        {
                            dtp_ngaythanhtoan.Checked = false;
                            dtp_ngaythanhtoan.CustomFormat = " ";
                        }
                        // ===== NGƯỜI THU =====
                        txt_nguoithu.Text = rdr["NguoiThu"] != DBNull.Value ? rdr["NguoiThu"].ToString() : "";
                        // ===== NỘI DUNG =====
                        txt_noidung.Text = rdr["NoiDung"] != DBNull.Value ? rdr["NoiDung"].ToString() : "";
                        // ===== PHƯƠNG THỨC =====
                        rdb_tm.Checked = false;
                        rdb_ck.Checked = false;
                        rdb_vdt.Checked = false;
                        if (rdr["PhuongThuc"] != DBNull.Value)
                        {
                            string pt = rdr["PhuongThuc"].ToString().Trim();
                            if (pt == "Tiền mặt" || pt == "0")
                                rdb_tm.Checked = true;
                            else if (pt == "Chuyển khoản" || pt == "1")
                                rdb_ck.Checked = true;
                            else if (pt == "Ví điện tử" || pt == "2")
                                rdb_vdt.Checked = true;
                        }
                        // ===== TRẠNG THÁI =====
                        if (rdr["TrangThai"] != DBNull.Value)
                        {
                            string tt = rdr["TrangThai"].ToString().Trim();
                            cbx_trangthai.SelectedItem = tt;
                        }
                        else
                        {
                            cbx_trangthai.SelectedIndex = 0;
                        }
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CellClick: " + ex.Message);
            }
        }
        private void cbx_mahoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoadCombo) return;
            if (cbx_mahoadon.SelectedValue == null) return;
            if (cbx_mahoadon.SelectedValue.ToString() == "System.Data.DataRowView") return;
            string maHD = cbx_mahoadon.SelectedValue.ToString().Trim();
            if (maHD == "")
            {
                cbx_mcn.Enabled = true;
                cbx_mch.SelectedIndex = 0;
                txt_sotien.Clear();
                return;
            }
            dangLoadCombo = true;
            cbx_mcn.SelectedIndex = 0;
            cbx_mcn.Enabled = false;
            DataRowView drv = cbx_mahoadon.SelectedItem as DataRowView;
            if (drv != null)
            {
                string maCanHo = drv["MaCanHo"].ToString();
                cbx_mch.SelectedValue = maCanHo;
            }
            decimal soTien = LaySoTienTuHoaDon(maHD);
            txt_sotien.Text = DinhDangTienVN(soTien);
            BoChonPhuongThuc();
            dangLoadCombo = false;
        }
        private void txt_sotien_Leave(object sender, EventArgs e)
        {
            decimal tien;
            string raw = txt_sotien.Text.Replace(".", "")
                                        .Replace(",", "")
                                        .Replace("đ", "")
                                        .Trim();
            if (decimal.TryParse(raw, out tien))
            {
                txt_sotien.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0} đ", tien);
            }
        }
        private void dtp_ngaythanhtoan_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_ngaythanhtoan.Checked)
                dtp_ngaythanhtoan.CustomFormat = "dd/MM/yyyy";
            else
                dtp_ngaythanhtoan.CustomFormat = " ";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!KiemTraChonHoaDonHoacCongNo())
                return;
            string maHD = "";
            string maCN = "";
            string maCH = "";
            if (cbx_mahoadon.SelectedValue != null && cbx_mahoadon.SelectedValue.ToString() != "System.Data.DataRowView")
                maHD = cbx_mahoadon.SelectedValue.ToString().Trim();
            if (cbx_mcn.SelectedValue != null && cbx_mcn.SelectedValue.ToString() != "System.Data.DataRowView")
                maCN = cbx_mcn.SelectedValue.ToString().Trim();
            if (cbx_mch.SelectedValue != null && cbx_mch.SelectedValue.ToString() != "System.Data.DataRowView")
                maCH = cbx_mch.SelectedValue.ToString().Trim();
            if (cbx_trangthai.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                cbx_trangthai.Focus();
                return;
            }
            if (maCH == "")
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ");
                cbx_mch.Focus();
                return;
            }
            if (txt_mthanhtoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã thanh toán");
                txt_mthanhtoan.Focus();
                return;
            }
            if (txt_sotien.Text.Trim() == "")
            {
                MessageBox.Show("Số tiền không được để trống");
                txt_sotien.Focus();
                return;
            }
            string maThanhToan = txt_mthanhtoan.Text.Trim();
            string maHoaDon = cbx_mahoadon.SelectedValue.ToString().Trim();
            decimal soTien = ChuyenTienVeSo(txt_sotien.Text);
            string nguoiThu = txt_nguoithu.Text.Trim();
            string noiDung = txt_noidung.Text.Trim();
            string phuongThuc = LayPhuongThuc();
            string ngayThanhToan;
            if (dtp_ngaythanhtoan.Checked)
                ngayThanhToan = "'" + dtp_ngaythanhtoan.Value.ToString("yyyy-MM-dd") + "'";
            else
                ngayThanhToan = "NULL";
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string check = "SELECT COUNT(*) AS SoLuong FROM ThanhToan WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlDataReader rdrCheck = ketnoi.truyvan(check);
                    int dem = 0;
                    if (rdrCheck.Read())
                    {
                        dem = Convert.ToInt32(rdrCheck["SoLuong"]);
                    }
                    rdrCheck.Close();
                    if (dem > 0)
                    {
                        MessageBox.Show("Mã thanh toán đã tồn tại");
                        txt_mthanhtoan.Focus();
                        ketnoi.dongketnoi();
                        return;
                    }
                    string trangThai = cbx_trangthai.Text.Trim();
                    string sql = "INSERT INTO ThanhToan(MaThanhToan, MaCanHo, MaHoaDon, MaCongNo, NgayThanhToan, SoTien, PhuongThuc, NguoiThu, NoiDung, TrangThai) " +
                                    "VALUES (N'" + maThanhToan + "', N'" + maCH + "', " +
                                    (maHD == "" ? "NULL" : "N'" + maHD + "'") + ", " +
                                    (maCN == "" ? "NULL" : "N'" + maCN + "'") + ", " +
                                    ngayThanhToan + ", " + soTien + ", N'" + phuongThuc + "', N'" + nguoiThu + "', N'" + noiDung + "', N'" + trangThai + "')";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        CapNhatTrangThaiLienQuan(maHD, maCN, trangThai, ketnoi.conn);
                        MessageBox.Show("Thêm thanh toán thành công");
                        LoadThanhToan();
                        btn_lamoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thanh toán thất bại");
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm thanh toán: " + ex.Message);
            }
        }
        private void cbx_mcn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoadCombo) return;
            if (cbx_mcn.SelectedValue == null) return;
            if (cbx_mcn.SelectedValue.ToString() == "System.Data.DataRowView") return;
            string maCN = cbx_mcn.SelectedValue.ToString().Trim();
            if (maCN == "")
            {
                cbx_mahoadon.Enabled = true;
                cbx_mch.SelectedIndex = 0;
                txt_sotien.Clear();
                return;
            }
            dangLoadCombo = true;
            cbx_mahoadon.SelectedIndex = 0;
            cbx_mahoadon.Enabled = false;
            DataRowView drv = cbx_mcn.SelectedItem as DataRowView;
            if (drv != null)
            {
                string maCanHo = drv["MaCanHo"].ToString();
                cbx_mch.SelectedValue = maCanHo;
            }
            decimal soTien = LaySoTienTuCongNo(maCN);
            txt_sotien.Text = DinhDangTienVN(soTien);
            BoChonPhuongThuc();
            dangLoadCombo = false;
        }        
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_mthanhtoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã thanh toán cần cập nhật");
                txt_mthanhtoan.Focus();
                return;
            }
            if (!KiemTraChonHoaDonHoacCongNo())
                return;
            string maHD = "";
            string maCN = "";
            string maCH = "";
            if (cbx_mahoadon.SelectedValue != null && cbx_mahoadon.SelectedValue.ToString() != "System.Data.DataRowView")
                maHD = cbx_mahoadon.SelectedValue.ToString().Trim();
            if (cbx_mcn.SelectedValue != null && cbx_mcn.SelectedValue.ToString() != "System.Data.DataRowView")
                maCN = cbx_mcn.SelectedValue.ToString().Trim();
            if (cbx_mch.SelectedValue != null && cbx_mch.SelectedValue.ToString() != "System.Data.DataRowView")
                maCH = cbx_mch.SelectedValue.ToString().Trim();
            if (maCH == "")
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ");
                cbx_mch.Focus();
                return;
            }
            if (txt_sotien.Text.Trim() == "")
            {
                MessageBox.Show("Số tiền không được để trống");
                txt_sotien.Focus();
                return;
            }
            if (LayPhuongThuc() == "")
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán");
                return;
            }
            if (cbx_trangthai.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                cbx_trangthai.Focus();
                return;
            }
            string maThanhToan = txt_mthanhtoan.Text.Trim();
            decimal soTien = ChuyenTienVeSo(txt_sotien.Text);
            string nguoiThu = txt_nguoithu.Text.Trim();
            string noiDung = txt_noidung.Text.Trim();
            string phuongThuc = LayPhuongThuc();
            string trangThai = cbx_trangthai.Text.Trim();
            string ngayThanhToan;
            if (dtp_ngaythanhtoan.Checked)
                ngayThanhToan = "'" + dtp_ngaythanhtoan.Value.ToString("yyyy-MM-dd") + "'";
            else
                ngayThanhToan = "NULL";
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "UPDATE ThanhToan SET " +
                                 "MaCanHo = N'" + maCH + "', " +
                                 "MaHoaDon = " + (maHD == "" ? "NULL" : "N'" + maHD + "'") + ", " +
                                 "MaCongNo = " + (maCN == "" ? "NULL" : "N'" + maCN + "'") + ", " +
                                 "NgayThanhToan = " + ngayThanhToan + ", " +
                                 "SoTien = " + soTien + ", " +
                                 "PhuongThuc = N'" + phuongThuc + "', " +
                                 "NguoiThu = N'" + nguoiThu + "', " +
                                 "NoiDung = N'" + noiDung + "', " +
                                 "TrangThai = N'" + trangThai + "' " +
                                 "WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        CapNhatTrangThaiLienQuan(maHD, maCN, trangThai, ketnoi.conn);
                        MessageBox.Show("Cập nhật thanh toán thành công");
                        LoadThanhToan();
                        btn_lamoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thanh toán thất bại");
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thanh toán: " + ex.Message);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_mthanhtoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn thanh toán cần xóa");
                return;
            }
            DialogResult tl = MessageBox.Show(
                "Bạn có chắc muốn xóa thanh toán này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (tl != DialogResult.Yes)
                return;
            string maThanhToan = txt_mthanhtoan.Text.Trim();
            string maHD = "";
            string maCN = "";
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    // Lấy MaHoaDon và MaCongNo trước khi xóa
                    string sel = "SELECT MaHoaDon, MaCongNo FROM ThanhToan WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        maHD = rdr["MaHoaDon"] != DBNull.Value ? rdr["MaHoaDon"].ToString() : "";
                        maCN = rdr["MaCongNo"] != DBNull.Value ? rdr["MaCongNo"].ToString() : "";
                    }
                    rdr.Close();
                    // Xóa thanh toán
                    string sql = "DELETE FROM ThanhToan WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        // Sau khi xóa thì trả trạng thái liên quan về "Chưa Thanh Toán"
                        CapNhatTrangThaiLienQuan(maHD, maCN, "Chưa Thanh Toán", ketnoi.conn);
                        MessageBox.Show("Xóa thanh toán thành công");
                        LoadThanhToan();
                        btn_lamoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thanh toán thất bại");
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa thanh toán: " + ex.Message);
            }
        }
        private void btn_lamoi_Click(object sender, EventArgs e)
        {
            IDTT = "";
            txt_mthanhtoan.Clear();
            dangLoadCombo = true;
            cbx_mahoadon.SelectedIndex = 0;
            cbx_mcn.SelectedIndex = 0;
            cbx_mch.SelectedIndex = 0;
            dangLoadCombo = false;
            cbx_mahoadon.Enabled = true;
            cbx_mcn.Enabled = true;
            dtp_ngaythanhtoan.Checked = false;
            dtp_ngaythanhtoan.CustomFormat = " ";
            txt_sotien.Clear();
            txt_nguoithu.Clear();
            txt_noidung.Clear();
            BoChonPhuongThuc();
            cbx_trangthai.SelectedIndex = 0;
            txt_mthanhtoan.Focus();
        }
    }
}
