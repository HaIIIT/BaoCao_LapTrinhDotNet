using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TTADMIN : Form
    {
        string IDTK = "";
        public Frm_TTADMIN()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }

        private void Frm_TTADMIN_Load(object sender, EventArgs e)
        {            
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT MaTaiKhoan, TenDangNhap, Quyen, TrangThai FROM TaiKhoanNguoiDung";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dstk1.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }           
        }
        private void dgv_dstk1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_dstk1.CurrentRow;
            IDTK = row.Cells["MaTaiKhoan"].Value.ToString();
            string MaTaiKhoan = row.Cells["MaTaiKhoan"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT tk.*, cd.Email AS EmailCuDan, nv.Email AS EmailNhanVien FROM TaiKhoanNguoiDung tk" +
                        " LEFT JOIN CuDan cd ON tk.MaCuDan = cd.MaCuDan" +
                        " LEFT JOIN NhanSu nv ON tk.MaNhanVien = nv.MaNhanSu" +
                        " WHERE tk.MaTaiKhoan = '" + MaTaiKhoan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        txt_mtk.Text = rdr["MaTaiKhoan"].ToString();
                        txt_tendn.Text = rdr["TenDangNhap"].ToString();
                        txt_mk.Text = rdr["MatKhau"].ToString();
                        if (rdr["Email"] != DBNull.Value && rdr["Email"].ToString() != "")
                        {
                            txt_email.Text = rdr["Email"].ToString();
                        }
                        else if (rdr["EmailCuDan"] != DBNull.Value && rdr["EmailCuDan"].ToString() != "")
                        {
                            txt_email.Text = rdr["EmailCuDan"].ToString();
                        }
                        else if (rdr["EmailNhanVien"] != DBNull.Value && rdr["EmailNhanVien"].ToString() != "")
                        {
                            txt_email.Text = rdr["EmailNhanVien"].ToString();
                        }
                        else
                        {
                            txt_email.Text = "";
                        }
                        decimal giatri = 0;
                        decimal.TryParse(rdr["Quyen"].ToString(), out giatri);
                        upd_quyen.Value = giatri;
                        if (rdr["TrangThai"].ToString() == "0")
                        {
                            rdb_dhd.Checked = true;
                        }
                        else
                        {
                            rdb_nhd.Checked = true;
                        }
                        dtp_ngaytao.Value = Convert.ToDateTime(rdr["NgayTao"].ToString());
                        txt_macudan.Text = rdr["MaCuDan"] == DBNull.Value ? "" :rdr["MaCuDan"].ToString();
                        txt_manhanvien.Text = rdr["MaNhanVien"] == DBNull.Value ? "" : rdr["MaNhanVien"].ToString();
                    }
                    rdr.Close();
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,"Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_email.Text = "";
            txt_mk.Text = "";
            txt_tendn.Text = "";
            txt_macudan.Text = "";
            txt_manhanvien.Text = "";
            upd_quyen.Value = 1;
            txt_mtk.Text = "";
            dtp_ngaytao.Value = DateTime.Now;
            rdb_dhd.Checked = false;
            rdb_nhd.Checked = false;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string selStr ="SELECT MaTaiKhoan FROM TaiKhoanNguoiDung WHERE MaTaiKhoan = '" + txt_mtk.Text + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã tài khoản đã tồn tại. Vui lòng chọn mã khác.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string maCuDan = string.IsNullOrWhiteSpace(txt_macudan.Text) ? "NULL" : "'" + txt_macudan.Text.Trim() + "'";
                        string maNhanVien = string.IsNullOrWhiteSpace(txt_manhanvien.Text) ? "NULL" : "'" + txt_manhanvien.Text.Trim() + "'";
                        int TrangThai = 0;
                        if (rdb_nhd.Checked)
                        {
                            TrangThai = 1;
                        }
                        string ins = "INSERT INTO TaiKhoanNguoiDung (MaTaiKhoan, TenDangNhap, MatKhau, Email, Quyen, TrangThai, NgayTao, MaCuDan, MaNhanVien) " +
                            "VALUES ('" + txt_mtk.Text + "'," +
                            "'" + txt_tendn.Text + "'," +
                            "'" + txt_mk.Text + "'," +
                            "'" + txt_email.Text + "'," +
                            "" + upd_quyen.Value + ", " +
                            TrangThai + "," +
                            "'" + dtp_ngaytao.Value.ToString("yyyy-MM-dd") + "'," +
                            maCuDan + "," +
                            maNhanVien + ")";
                        int kq = ketnoi.capnhat(ins);
                        if (kq > 0)
                        {
                            string hoten = "";
                            if (!string.IsNullOrWhiteSpace(txt_macudan.Text))
                            {
                                string sqlTen = "SELECT HoTen FROM CuDan WHERE MaCuDan = '" + txt_macudan.Text.Trim() + "'";
                                SqlDataReader rdrTen = ketnoi.truyvan(sqlTen);
                                if (rdrTen.Read())
                                {
                                    hoten = rdrTen["HoTen"].ToString();
                                }
                                rdrTen.Close();
                            }
                            else if (!string.IsNullOrWhiteSpace(txt_manhanvien.Text))
                            {
                                string sqlTen = "SELECT HoTen FROM NhanSu WHERE MaNhanSu = '" + txt_manhanvien.Text.Trim() + "'";
                                SqlDataReader rdrTen = ketnoi.truyvan(sqlTen);
                                if (rdrTen.Read())
                                {
                                    hoten = rdrTen["HoTen"].ToString();
                                }
                                rdrTen.Close();
                            }
                            if (hoten == "")
                            {
                                hoten = txt_tendn.Text.Trim();
                            }
                            string quyen = upd_quyen.Value.ToString();
                            if (quyen == "1")
                            {
                                quyen = "Admin";
                            }else if (quyen == "2")
                            {
                                quyen = "Nhân Viên";
                            }else if (quyen == "3")
                            {
                                quyen = "Trưởng BP Nhân Sự";
                            }else if (quyen == "4")
                            {
                                quyen = "Trưởng BP KH-TC";
                            }else if (quyen == "5")
                            {
                                quyen = "Trưởng BP QLDV-Ti";
                            }else if (quyen == "6")
                            {
                                quyen = "Cư Dân";
                            }else if (quyen == "7")
                            {
                                quyen = "Ban Quản Lý";
                            }
                            DialogResult rs = MessageBox.Show("Thêm tài khoản thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_TTADMIN_Load(sender, e);
                            if (rs == DialogResult.OK)
                            {
                                var fromAddress = new MailAddress("hethongquanlychungcu@gmail.com", "Hệ Thống Quản Lý Chung Cư");
                                var toAddress = new MailAddress(txt_email.Text);
                                const string frompass = "hgsi mdwb lbng qywi";
                                const string subjet = "Cấp Phát Tài Khoản";
                                string body = "Xin Chào, " + hoten +
                                            "\nTài Khoản của bạn đã được cấp phát thành công." +
                                            "\nMã tài khoản: " + txt_mtk.Text.Trim() + "\n" +
                                            "Tên đăng nhập: " + txt_tendn.Text.Trim() + "\n" +
                                            "Mật khẩu: " + txt_mk.Text.Trim() + "\n" +
                                            "Quyền: " + quyen +
                                            "\n------------------------" +
                                            "\nHệ Thống Quản Lý Chung Cư" +
                                            "\nEmail hỗ trợ: support@hethong.com" +
                                            "\nĐây là email tự động, vui lòng không trả lời về mail này!";
                                var smtp = new SmtpClient()
                                {
                                    Host = "smtp.gmail.com",
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = true,
                                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                                    Timeout = 20000
                                };
                                using (var message = new MailMessage(fromAddress, toAddress)
                                {
                                    Subject = subjet,
                                    Body = body
                                })
                                {
                                    smtp.Send(message);
                                }
                                MessageBox.Show("Tài khoản đã được gửi qua email: " + txt_email.Text, "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thêm tài khoản thất bại. Vui lòng thử lại.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_macudan_Leave(object sender, EventArgs e)
        {
            if (txt_macudan.Text.Trim() == "")
            {
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT Email FROM CuDan WHERE MaCuDan = '" + txt_macudan.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_email.Text = rdr["Email"] == DBNull.Value ? "" : rdr["Email"].ToString();
                    }
                    else
                    {
                        txt_email.Text = "";
                        MessageBox.Show("Không tìm thấy mã cư dân này.",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_manhanvien_Leave(object sender, EventArgs e)
        {
            if (txt_manhanvien.Text.Trim() == "")
            {
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT Email FROM NhanSu WHERE MaNhanSu = '" + txt_manhanvien.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_email.Text = rdr["Email"] == DBNull.Value ? "" : rdr["Email"].ToString();
                    }
                    else
                    {
                        txt_email.Text = "";
                        MessageBox.Show("Không tìm thấy mã nhân viên này.",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string selStr = "SELECT MaTaiKhoan FROM TaiKhoanNguoiDung WHERE MaTaiKhoan = '" + txt_mtk.Text + "' AND " +
                    "MaTaiKhoan <> '" + IDTK + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã tài khoản đã tồn tại. Vui lòng chọn mã khác.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string upStr = "UPDATE TaiKhoanNguoiDung SET " +
                        "MaTaiKhoan = '" + txt_mtk.Text + "'," +
                        "TenDangNhap = '" + txt_tendn.Text + "'," +
                        "MatKhau = '" + txt_mk.Text + "'," +
                        "Email = '" + txt_email.Text + "'," +
                        "Quyen = " + upd_quyen.Value + "," +
                        "TrangThai = " + (rdb_nhd.Checked ? 1 : 0) + "," +
                        "MaCuDan = " + (string.IsNullOrWhiteSpace(txt_macudan.Text) ? "NULL" : "'" + txt_macudan.Text.Trim() + "'") + "," +
                        "MaNhanVien = " + (string.IsNullOrWhiteSpace(txt_manhanvien.Text) ? "NULL" : "'" + txt_manhanvien.Text.Trim() + "'") +
                        " WHERE MaTaiKhoan = '" + IDTK + "'";
                        int ketqua = ketnoi.capnhat(upStr);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Cập nhật tài khoản thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_TTADMIN_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật tài khoản thất bại. Vui lòng thử lại.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản: "
                +"\nMã Tài Khoản:"+ txt_mtk.Text.Trim() + " - "
                +"\nTên tài Khoản:"+ txt_tendn.Text.Trim() + "?"
                , "Hệ Thống Quản Lý Chung Cư - Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Connection ketnoi = new Connection();
                try
                {
                    if (ketnoi.moketnoi())
                    {
                        string delStr ="DELETE FROM TaiKhoanNguoiDung WHERE MaTaiKhoan ='" + txt_mtk.Text.Trim() + "'";
                        int ketqua = ketnoi.capnhat(delStr);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_TTADMIN_Load(sender, e);
                            btn_reset_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xóa tài khoản thất bại. Vui lòng thử lại.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ketnoi.dongketnoi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message,
                        "Hệ Thống Quản Lý Chung Cư - Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_dstk1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_dstk1.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "Đang Hoạt Động";
                    } else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Ngưng Hoạt Động";
                    }
                }
            } else if (dgv_dstk1.Columns[e.ColumnIndex].Name == "Quyen")
            {
                if (e.Value != null) {
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = "Admin";
                    } else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Nhân Sự";
                    } else if (e.Value.ToString() == "3"){
                        e.Value = "Trưởng Bộ Phận Nhân Sự";
                    }else if(e.Value.ToString() == "4")
                    {
                        e.Value = "Trưởng Phòng Kế Hoạch - Tài Chính";
                    }else if (e.Value.ToString() == "5")
                    {
                        e.Value = "Trưởng Phòng Dịch Vụ - Tiện Ích";
                    }else if( e.Value.ToString() == "6")
                    {
                        e.Value = "Cư Dân";
                    }else if (e.Value.ToString() == "7")
                    {
                        e.Value = "Ban Quản Lý";
                    }
                }
            }
        }
    }
}

