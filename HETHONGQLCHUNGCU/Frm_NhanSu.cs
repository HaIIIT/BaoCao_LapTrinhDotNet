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
    public partial class Frm_NhanSu : Form
    {
        string IDNS = "";
        public Frm_NhanSu()
        {
            InitializeComponent();
        }
        void LamMoi()
        {
            txtmns.Clear();
            txtht.Clear();
            txtcccd.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            txtdc.Clear();
            txtns.Clear();
            txtqq.Clear();
            txtlcb.Clear();

            cbxchucvu.SelectedIndex = -1;
            cbxmpb.SelectedIndex = -1;

            rdb_nam.Checked = false;
            rdb_nu.Checked = false;
            rdb_danglvc.Checked = false;
            rdb_nvc.Checked = false;

            dtpngsinh.Value = DateTime.Now;
            dtpngayvaolam.Value = DateTime.Now;
        }
        private void Frm_NhanSu_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaNhanSu, HoTen, CCCD, SoDienThoai, Email, DiaChi, ChucVu, MaPhongBan, TrangThai FROM NhanSu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgvdsns.DataSource = tb;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvdsns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvdsns.CurrentRow;
            IDNS = row.Cells["MaNhanSu"].Value.ToString();

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM NhanSu WHERE MaNhanSu = N'" + IDNS + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);

                    if (rdr.Read())
                    {
                        txtmns.Text = rdr["MaNhanSu"].ToString();
                        txtht.Text = rdr["HoTen"].ToString();
                        txtcccd.Text = rdr["CCCD"].ToString();

                        if (rdr["NgaySinh"] != DBNull.Value)
                            dtpngsinh.Value = Convert.ToDateTime(rdr["NgaySinh"]);

                        string gioitinh = rdr["GioiTinh"].ToString().Trim();
                        rdb_nam.Checked = gioitinh == "Nam";
                        rdb_nu.Checked = gioitinh == "Nữ";

                        txtsdt.Text = rdr["SoDienThoai"].ToString();
                        txtemail.Text = rdr["Email"].ToString();
                        txtdc.Text = rdr["DiaChi"].ToString();
                        txtns.Text = rdr["NoiSinh"].ToString();
                        txtqq.Text = rdr["QueQuan"].ToString();

                        cbxchucvu.Text = rdr["ChucVu"].ToString();
                        cbxmpb.Text = rdr["MaPhongBan"].ToString();

                        if (rdr["NgayVaoLam"] != DBNull.Value)
                            dtpngayvaolam.Value = Convert.ToDateTime(rdr["NgayVaoLam"]);

                        txtlcb.Text = rdr["LuongCoBan"].ToString();

                        string trangthai = rdr["TrangThai"].ToString().Trim();
                        rdb_danglvc.Checked = trangthai == "Đang làm" || trangthai == "Đang Làm Việc";
                        rdb_nvc.Checked = trangthai == "Nghỉ Việc" || trangthai == "Xin Nghỉ";
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
            if (txtmns.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã nhân sự");
                txtmns.Focus();
                return;
            }

            if (txtht.Text.Trim() == "")
            {
                MessageBox.Show("Nhập họ tên");
                txtht.Focus();
                return;
            }

            // CCCD
            if (txtcccd.Text.Trim() == "")
            {
                MessageBox.Show("Nhập CCCD");
                txtcccd.Focus();
                return;
            }

            if (!txtcccd.Text.All(char.IsDigit))
            {
                MessageBox.Show("CCCD chỉ được nhập số");
                txtcccd.Focus();
                return;
            }

            if (txtcccd.Text.Length >= 15)
            {
                MessageBox.Show("CCCD phải nhỏ hơn 15 ký tự");
                txtcccd.Focus();
                return;
            }

            // SĐT
            if (txtsdt.Text.Trim() == "")
            {
                MessageBox.Show("Nhập số điện thoại");
                txtsdt.Focus();
                return;
            }

            if (!txtsdt.Text.All(char.IsDigit))
            {
                MessageBox.Show("SĐT chỉ được nhập số");
                txtsdt.Focus();
                return;
            }

            if (txtsdt.Text.Length >= 12)
            {
                MessageBox.Show("SĐT phải nhỏ hơn 12 ký tự");
                txtsdt.Focus();
                return;
            }

            // EMAIL
            try
            {
                var mail = new System.Net.Mail.MailAddress(txtemail.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Email không đúng định dạng");
                txtemail.Focus();
                return;
            }

            // GIỚI TÍNH
            string gioitinh = rdb_nam.Checked ? "Nam" :
                              rdb_nu.Checked ? "Nữ" : "";

            if (gioitinh == "")
            {
                MessageBox.Show("Chọn giới tính");
                return;
            }

            // TRẠNG THÁI
            string trangthai = rdb_danglvc.Checked ? "Đang làm" :
                               rdb_nvc.Checked ? "Nghỉ việc" : "";

            if (trangthai == "")
            {
                MessageBox.Show("Chọn trạng thái");
                return;
            }

            // LƯƠNG
            decimal luong;
            if (!decimal.TryParse(txtlcb.Text.Trim(), out luong))
            {
                MessageBox.Show("Lương phải là số");
                txtlcb.Focus();
                return;
            }

            // ===== SQL =====
            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    // Check trùng mã
                    string check = "SELECT MaNhanSu FROM NhanSu WHERE MaNhanSu = N'" + txtmns.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);

                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã nhân sự đã tồn tại");
                        rdr.Close();
                        return;
                    }
                    rdr.Close();

                    string sql = "INSERT INTO NhanSu " +
                        "(MaNhanSu, HoTen, CCCD, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, NoiSinh, QueQuan, ChucVu, MaPhongBan, NgayVaoLam, LuongCoBan, TrangThai) " +
                        "VALUES (" +
                        "N'" + txtmns.Text.Trim() + "'," +
                        "N'" + txtht.Text.Trim() + "'," +
                        "N'" + txtcccd.Text.Trim() + "'," +
                        "'" + dtpngsinh.Value.ToString("yyyy-MM-dd") + "'," +
                        "N'" + gioitinh + "'," +
                        "N'" + txtsdt.Text.Trim() + "'," +
                        "N'" + txtemail.Text.Trim() + "'," +
                        "N'" + txtdc.Text.Trim() + "'," +
                        "N'" + txtns.Text.Trim() + "'," +
                        "N'" + txtqq.Text.Trim() + "'," +
                        "N'" + cbxchucvu.Text + "'," +
                        "N'" + cbxmpb.Text + "'," +
                        "'" + dtpngayvaolam.Value.ToString("yyyy-MM-dd") + "'," +
                        luong + "," +
                        "N'" + trangthai + "')";

                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Thêm Nhân Sự thành công", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // load lại grid
                        Frm_NhanSu_Load(sender, e);

                        // clear form
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Nhân Sự thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (IDNS == "")
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần sửa");
                return;
            }

            if (txtht.Text.Trim() == "")
            {
                MessageBox.Show("Nhập họ tên");
                txtht.Focus();
                return;
            }

            if (txtcccd.Text.Trim() == "")
            {
                MessageBox.Show("Nhập CCCD");
                txtcccd.Focus();
                return;
            }

            if (!txtcccd.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("CCCD chỉ được nhập số");
                txtcccd.Focus();
                return;
            }

            if (txtcccd.Text.Trim().Length >= 15)
            {
                MessageBox.Show("CCCD phải nhỏ hơn 15 ký tự");
                txtcccd.Focus();
                return;
            }

            if (txtsdt.Text.Trim() == "")
            {
                MessageBox.Show("Nhập số điện thoại");
                txtsdt.Focus();
                return;
            }

            if (!txtsdt.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("SĐT chỉ được nhập số");
                txtsdt.Focus();
                return;
            }

            if (txtsdt.Text.Trim().Length >= 12)
            {
                MessageBox.Show("SĐT phải nhỏ hơn 12 ký tự");
                txtsdt.Focus();
                return;
            }

            try
            {
                var mail = new System.Net.Mail.MailAddress(txtemail.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Email không đúng định dạng");
                txtemail.Focus();
                return;
            }

            string gioitinh = rdb_nam.Checked ? "Nam" :
                              rdb_nu.Checked ? "Nữ" : "";

            if (gioitinh == "")
            {
                MessageBox.Show("Chọn giới tính");
                return;
            }

            string trangthai = rdb_danglvc.Checked ? "Đang làm" :
                               rdb_nvc.Checked ? "Nghỉ việc" : "";

            if (trangthai == "")
            {
                MessageBox.Show("Chọn trạng thái");
                return;
            }

            decimal luong;
            if (!decimal.TryParse(txtlcb.Text.Trim(), out luong))
            {
                MessageBox.Show("Lương phải là số");
                txtlcb.Focus();
                return;
            }

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "UPDATE NhanSu SET " +
                                 "HoTen = N'" + txtht.Text.Trim() + "', " +
                                 "CCCD = N'" + txtcccd.Text.Trim() + "', " +
                                 "NgaySinh = '" + dtpngsinh.Value.ToString("yyyy-MM-dd") + "', " +
                                 "GioiTinh = N'" + gioitinh + "', " +
                                 "SoDienThoai = N'" + txtsdt.Text.Trim() + "', " +
                                 "Email = N'" + txtemail.Text.Trim() + "', " +
                                 "DiaChi = N'" + txtdc.Text.Trim() + "', " +
                                 "NoiSinh = N'" + txtns.Text.Trim() + "', " +
                                 "QueQuan = N'" + txtqq.Text.Trim() + "', " +
                                 "ChucVu = N'" + cbxchucvu.Text.Trim() + "', " +
                                 "MaPhongBan = N'" + cbxmpb.Text.Trim() + "', " +
                                 "NgayVaoLam = '" + dtpngayvaolam.Value.ToString("yyyy-MM-dd") + "', " +
                                 "LuongCoBan = " + luong + ", " +
                                 "TrangThai = N'" + trangthai + "' " +
                                 "WHERE MaNhanSu = N'" + IDNS + "'";

                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_NhanSu_Load(sender, e);
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDNS == "")
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần xóa");
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân sự này không?\nDữ liệu liên quan trong Phân công, Đánh giá, Chấm công, Tài khoản cũng sẽ bị xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes)
                return;

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql =
                        "DELETE FROM PhanCongNhiemVu WHERE MaNhanSu = N'" + IDNS + "'; " +
                        "DELETE FROM DanhGiaNhanSu WHERE MaNhanSu = N'" + IDNS + "'; " +
                        "DELETE FROM ChamCong WHERE MaNhanSu = N'" + IDNS + "'; " +
                        "DELETE FROM TaiKhoanNguoiDung WHERE MaNhanSu = N'" + IDNS + "'; " +
                        "DELETE FROM NhanSu WHERE MaNhanSu = N'" + IDNS + "';";
                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Xóa nhân sự thành công","Hệ Thống Quản Lý Chung Cư - Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Frm_NhanSu_Load(sender, e);
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
