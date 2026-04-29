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
    public partial class Frm_HD : Form
    {
        string IDHD = "";
        public Frm_HD()
        {
            InitializeComponent();
        }
        void load_cbx_canho()
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
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        void load_cbx_cthdong()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaCTHD FROM ChiTietHoaDon";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaCTHD"] = "";
                row["MaCTHD"] = "-Click-";
                tb.Rows.InsertAt(row, 0);
                cbx_cthd.DataSource = tb;
                cbx_cthd.DisplayMember = "MaCTHD";
                cbx_cthd.ValueMember = "MaCTHD";
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        //làm mới
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txt_mhd.Clear();
            cbx_mch.SelectedIndex = 0;
            cbx_cthd.SelectedIndex = 0;
            cbx_thang.SelectedIndex = 0;
            txt_nam.Clear();
            txt_tongtien.Clear();
            txt_ghichu.Clear();
            rdb_chuatt.Checked = true;
            rdb_cxl.Checked = false;
            rdb_dtt.Checked = false;
        }
        //thoát
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void Frm_HD_Load(object sender, EventArgs e)
        {
            rdb_chuatt.Checked = true;
            load_cbx_canho();
            load_cbx_cthdong();
            cbx_thang.Items.Clear();
            cbx_thang.Items.Add("--Chọn Tháng--");
            cbx_thang.Items.Add("Tháng 1");
            cbx_thang.Items.Add("Tháng 2");
            cbx_thang.Items.Add("Tháng 3");
            cbx_thang.Items.Add("Tháng 4");
            cbx_thang.Items.Add("Tháng 5");
            cbx_thang.Items.Add("Tháng 6");
            cbx_thang.Items.Add("Tháng 7");
            cbx_thang.Items.Add("Tháng 8");
            cbx_thang.Items.Add("Tháng 9");
            cbx_thang.Items.Add("Tháng 10");
            cbx_thang.Items.Add("Tháng 11");
            cbx_thang.Items.Add("Tháng 12");
            cbx_thang.SelectedIndex = 0;

            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaCTHD, MaHoaDon, MaCanHo FROM HoaDon";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    rdr.Close();
                    dgvDSHD.DataSource = dt;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvDSHD.CurrentRow;
            string MaHoaDon = row.Cells["MaHoaDon"].Value.ToString();
            IDHD = row.Cells["MaHoaDon"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM HoaDon WHERE MaHoaDon='" + MaHoaDon + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mhd.Text = rdr["MaHoaDon"].ToString();
                        cbx_mch.SelectedValue = rdr["MaCanHo"].ToString();
                        cbx_cthd.SelectedValue = rdr["MaCTHD"].ToString();
                        cbx_thang.SelectedItem ="Tháng "+ rdr["Thang"].ToString();
                        txt_nam.Text = rdr["Nam"].ToString();
                        dtp_ngaylap.Value = Convert.ToDateTime(rdr["NgayLap"]);
                        dtp_hanthanhtoan.Value = Convert.ToDateTime(rdr["HanThanhToan"]);
                        string trangthai = rdr["TrangThai"].ToString().Trim();
                        if (trangthai == "Đã Thanh Toán")
                        {
                            rdb_dtt.Checked = true;
                        }
                        else if (trangthai == "Chưa Thanh Toán")
                        {
                            rdb_chuatt.Checked = true;
                        }
                        else if (trangthai == "Chờ Xử Lý")
                        {
                            rdb_cxl.Checked = true;
                        }
                        txt_tongtien.Text = Convert.ToDecimal(rdr["TongTien"]).ToString("#,##0", new System.Globalization.CultureInfo("vi-VN"));
                        txt_ghichu.Text = rdr["GhiChu"].ToString();
                    }rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cbx_cthd.SelectedIndex == 0 || cbx_cthd.SelectedValue == null || cbx_cthd.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn mã chi tiết hóa đơn!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbx_mch.SelectedIndex == 0 || cbx_mch.SelectedValue == null || cbx_mch.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ!","Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbx_thang.SelectedIndex == 0 || cbx_thang.SelectedIndex == null || cbx_thang.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn tháng!","Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string selStr ="SELECT MaHoaDon FROM HoaDon WHERE MaHoaDon='"+txt_mhd.Text.Trim()+"'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read()) 
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }rdr.Close();
                    if (hople)
                    {
                        string mamcthd = cbx_cthd.SelectedValue.ToString();
                        string mach = cbx_mch.SelectedValue.ToString();
                        string thang = cbx_thang.SelectedIndex.ToString();                        
                        DateTime ngayLap = dtp_ngaylap.Value;
                        DateTime han = dtp_hanthanhtoan.Value;                        
                        if (han<ngayLap)
                        {
                            MessageBox.Show("Hạn Thanh Toán Phải Lớn Hơn Hoặc Bằng Ngày Lập", "Hệ Thống Quản Lý Chung Cư - Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string ngaylap = dtp_ngaylap.Value.ToString("yyyy-MM-dd");
                        string hantt = dtp_hanthanhtoan.Value.ToString("yyyy-MM-dd");
                        string trangthai = rdb_dtt.Checked ? "Đã Thanh Toán" : rdb_chuatt.Checked ? "Chưa Thanh Toán" : "Chờ Xử Lý" ;
                        string tongtien = txt_tongtien.Text.Replace(".", "");
                        string insStr = "INSERT INTO HoaDon(MaHoaDon, MaCanHo, MaCTHD, Thang, Nam, NgayLap, HanThanhToan, TrangThai, TongTien, GhiChu) VALUES(" +
                                "N'" + txt_mhd.Text.Trim() + "'," +
                                "N'" + mach + "'," +
                                "N'" + mamcthd + "'," +
                                thang + "," +
                                txt_nam.Text.Trim() + "," +
                                "'" + ngaylap + "'," +
                                "'" + hantt + "'," +
                                "N'" + trangthai + "'," +
                                tongtien + "," +
                                "N'" + txt_ghichu.Text.Trim() + "')";
                        int ketqua = ketnoi.capnhat(insStr);
                        if(ketqua > 0)
                        {
                            MessageBox.Show("Thêm hóa đơn thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IDHD = txt_mhd.Text.Trim();
                            Frm_HD_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm hóa đơn không thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không Thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_tongtien_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tongtien.Text)) return;
            string text = txt_tongtien.Text.Replace(".", "");
            if (decimal.TryParse(text, out decimal value))
            {
                txt_tongtien.Text = value.ToString("#,##0", new System.Globalization.CultureInfo("vi-VN"));
                txt_tongtien.SelectionStart = txt_tongtien.Text.Length;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cbx_cthd.SelectedIndex <= 0 || cbx_cthd.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã chi tiết hóa đơn!");
                return;
            }
            if (cbx_mch.SelectedIndex <= 0 || cbx_mch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ!");
                return;
            }
            if (cbx_thang.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn tháng!");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string mamcthd = cbx_cthd.SelectedValue.ToString();
                    string mach = cbx_mch.SelectedValue.ToString();
                    string thang = cbx_thang.SelectedIndex.ToString();
                    DateTime ngayLap = dtp_ngaylap.Value;
                    DateTime han = dtp_hanthanhtoan.Value;
                    if (han < ngayLap)
                    {
                        MessageBox.Show("Hạn thanh toán phải >= ngày lập!");
                        return;
                    }
                    string ngaylap = ngayLap.ToString("yyyy-MM-dd");
                    string hantt = han.ToString("yyyy-MM-dd");
                    string trangthai = "";
                    if (rdb_dtt.Checked) trangthai = "Đã Thanh Toán";
                    else if (rdb_chuatt.Checked) trangthai = "Chưa Thanh Toán";
                    else trangthai = "Chờ Xử Lý";
                    string tongtien = txt_tongtien.Text.Replace(".", "").Trim();
                    string upStr = "UPDATE HoaDon SET " +
                        "MaCanHo = N'" + mach + "'," +
                        "MaCTHD = N'" + mamcthd + "'," +
                        "Thang = " + thang + "," +
                        "Nam = " + txt_nam.Text.Trim() + "," +
                        "NgayLap = '" + ngaylap + "'," +
                        "HanThanhToan = '" + hantt + "'," +
                        "TrangThai = N'" + trangthai + "'," +
                        "TongTien = " + tongtien + "," +
                        "GhiChu = N'" + txt_ghichu.Text.Trim() + "' " +
                        "WHERE MaHoaDon = N'" + IDHD + "'";
                    int kq = ketnoi.capnhat(upStr);
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_HD_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hóa đơn không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string delStr = "DELETE FROM HoaDon WHERE MaHoaDon = N'" + IDHD + "'";
                    int kq = ketnoi.capnhat(delStr);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IDHD = "";
                        Frm_HD_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
