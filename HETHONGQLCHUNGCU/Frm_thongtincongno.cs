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
    public partial class Frm_thongtincongno : Form
    {
        string IDCN = "";
        public Frm_thongtincongno()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        //xây dựng hàm load cbx
        void load_canho()
        {
            Connection kn = new Connection();
            if (kn.moketnoi())
            {
                string sql = "SELECT MaCanHo FROM CanHo";
                SqlDataReader dr = kn.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(dr);
                DataRow r = tb.NewRow();
                r["MaCanHo"] = "-Click-";
                tb.Rows.InsertAt(r, 0);
                cbx_mch.DataSource = tb;
                cbx_mch.DisplayMember = "MaCanHo";
                cbx_mch.ValueMember = "MaCanHo";
                cbx_mch.SelectedIndex = 0;
                dr.Close();
                kn.dongketnoi();
            }
        }
        void load_hoadon()
        {
            Connection kn = new Connection();
            if (kn.moketnoi())
            {
                string sql = "SELECT MaHoaDon, MaCanHo, TongTien, HanThanhToan, " +
                             "(MaHoaDon + ' - ' + MaCanHo) AS HienThi " +
                             "FROM HoaDon " +
                             "WHERE HanThanhToan < GETDATE() AND TrangThai <> N'Đã Thanh Toán'";
                SqlDataReader dr = kn.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(dr);
                DataRow r = tb.NewRow();
                r["MaHoaDon"] = "";
                r["MaCanHo"] = "";
                r["TongTien"] = 0;
                r["HanThanhToan"] = DateTime.Now; 
                r["HienThi"] = "-Click-";
                tb.Rows.InsertAt(r, 0);
                cbx_mhd.DataSource = tb;
                cbx_mhd.DisplayMember = "HienThi";
                cbx_mhd.ValueMember = "MaHoaDon";
                cbx_mhd.SelectedIndex = 0;
                dr.Close();
                kn.dongketnoi();
            }
        }
        string laytrangthai()
        {
            if (rdb_dtt.Checked) return "Đã Tất Toán";
            if (rdb_ctt.Checked) return "Chưa Thanh Toán";
            if (rdb_quahan.Checked) return "Quá Hạn";
            return "";
        }
        //--------------------------------
        private void Frm_thongtincongno_Load(object sender, EventArgs e)
        {
            load_canho();
            load_hoadon();
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaCongNo,MaCanHo,MaHoaDon, TrangThai FROM CongNo";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                dgv_ttcongno.DataSource = tb;
                rdr.Close();
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("'khong the ket noi CSDL");
            }
        }
        private void dgv_ttcongno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgv_ttcongno.Rows[e.RowIndex];
            IDCN = row.Cells["MaCongNo"].Value.ToString();

            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CongNo WHERE MaCongNo = N'" + IDCN + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mcn.Text = rdr["MaCongNo"].ToString();
                        cbx_mch.SelectedValue = rdr["MaCanHo"].ToString();
                        cbx_mhd.SelectedValue = rdr["MaHoaDon"].ToString();
                        txt_sotien.Text = Convert.ToDecimal(rdr["SoTienNo"]).ToString("N0", new CultureInfo("vi-VN"));
                        if (rdr["NgayPhatSinh"] != DBNull.Value)
                            dtp_ngayps.Value = Convert.ToDateTime(rdr["NgayPhatSinh"]);
                        if (rdr["HanNo"] != DBNull.Value)
                            dtp_hanno.Value = Convert.ToDateTime(rdr["HanNo"]);
                        string tt = rdr["TrangThai"].ToString();
                        rdb_dtt.Checked = false;
                        rdb_ctt.Checked = false;
                        rdb_quahan.Checked = false;
                        if (tt == "Đã Tất Toán")
                            rdb_dtt.Checked = true;
                        else if (tt == "Chưa Thanh Toán")
                            rdb_ctt.Checked = true;
                        else if (tt == "Quá Hạn")
                            rdb_quahan.Checked = true;
                        txt_ghichu.Text = rdr["GhiChu"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void cbx_mhd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_mhd.SelectedIndex == 0)
                return;
            if (cbx_mhd.SelectedValue == null || cbx_mhd.SelectedValue.ToString() == "")
                return;
            Connection kn = new Connection();
            if (kn.moketnoi())
            {
                string sql = "SELECT * FROM HoaDon WHERE MaHoaDon = N'" + cbx_mhd.SelectedValue.ToString() + "'";
                SqlDataReader dr = kn.truyvan(sql);
                if (dr.Read())
                {
                    cbx_mch.SelectedValue = dr["MaCanHo"].ToString();
                    txt_sotien.Text = Convert.ToDecimal(dr["TongTien"]).ToString("N0", new CultureInfo("vi-VN"));
                    DateTime han = Convert.ToDateTime(dr["HanThanhToan"]);
                    dtp_ngayps.Value = han.AddDays(1);
                    dtp_hanno.Value = dtp_ngayps.Value.AddDays(30);
                    rdb_quahan.Checked = true;
                }
                dr.Close();
                kn.dongketnoi();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txt_mcn.Clear();
            txt_sotien.Clear();
            txt_ghichu.Clear();
            cbx_mch.SelectedIndex = 0;
            cbx_mhd.SelectedIndex = 0;
            dtp_hanno.Value = DateTime.Now;
            dtp_ngayps.Value= DateTime.Now;
            rdb_ctt.Checked = false;
            rdb_dtt.Checked = false;
            rdb_quahan.Checked = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool hople = true;
            if (txt_mcn.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã công nợ");
                txt_mcn.Focus();
                return;
            }
            if (cbx_mch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ");
                cbx_mch.Focus();
                return;
            }
            if (cbx_mhd.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn");
                cbx_mhd.Focus();
                return;
            }
            if (txt_sotien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền nợ");
                txt_sotien.Focus();
                return;
            }
            if (laytrangthai() == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string check = "SELECT * FROM CongNo WHERE MaCongNo = '" + txt_mcn.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        hople = false;
                        MessageBox.Show("Mã công nợ đã tồn tại");
                        txt_mcn.Focus();
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string sotien = txt_sotien.Text.Replace(".", "").Replace(",", "").Replace("đ", "").Replace(" ", "");
                        string ins = "INSERT INTO CongNo(MaCongNo, MaCanHo, MaHoaDon, SoTienNo, NgayPhatSinh, HanNo, TrangThai, GhiChu) VALUES(" +
                                     "N'" + txt_mcn.Text.Trim() + "'," +
                                     "N'" + cbx_mch.SelectedValue.ToString() + "'," +
                                     "N'" + cbx_mhd.SelectedValue.ToString() + "'," +
                                     sotien + "," +
                                     "N'" + dtp_ngayps.Value.ToString("yyyy-MM-dd") + "'," +
                                     "N'" + dtp_hanno.Value.ToString("yyyy-MM-dd") + "'," +
                                     "N'" + laytrangthai() + "'," +
                                     "N'" + txt_ghichu.Text.Trim() + "')";
                        int ketqua=ketnoi.capnhat(ins);
                        if (ketqua > 0)
                        {
                            string trangthaiHD = "Chưa Thanh Toán";
                            if (laytrangthai() == "Đã Tất Toán")
                                trangthaiHD = "Đã Thanh Toán";
                            else if (laytrangthai() == "Quá Hạn")
                                trangthaiHD = "Quá Hạn";
                            string uphd = "UPDATE HoaDon SET TrangThai = N'" + trangthaiHD + "' " +
                                            "WHERE MaHoaDon = N'" + cbx_mhd.SelectedValue.ToString() + "'";
                            ketnoi.capnhat(uphd);
                            MessageBox.Show("Thêm công nợ thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincongno_Load(sender, e);
                            btn_lammoi_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm công nợ không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm Mới", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối CSDL!", "Hệ Thống Quản Lý Chung Cư - Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (IDCN == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
                return;
            }
            if (txt_mcn.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã công nợ");
                txt_mcn.Focus();
                return;
            }
            if (cbx_mch.SelectedIndex == 0 || cbx_mch.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã căn hộ");
                cbx_mch.Focus();
                return;
            }
            if (cbx_mhd.SelectedIndex == 0 || cbx_mhd.SelectedValue == null || cbx_mhd.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn");
                cbx_mhd.Focus();
                return;
            }
            if (txt_sotien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền nợ");
                txt_sotien.Focus();
                return;
            }
            if (laytrangthai() == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string check = "SELECT * FROM CongNo WHERE MaCongNo = N'" + txt_mcn.Text.Trim() + "' AND MaCongNo <> N'" + IDCN + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        hople = false;
                        MessageBox.Show("Mã công nợ đã tồn tại");
                        txt_mcn.Focus();
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string sotien = txt_sotien.Text.Replace(".", "").Replace(",", "").Replace("đ", "").Replace(" ", "");
                        string up = "UPDATE CongNo SET " +
                                    "MaCongNo = N'" + txt_mcn.Text.Trim() + "'," +
                                    "MaCanHo = N'" + cbx_mch.SelectedValue.ToString() + "'," +
                                    "MaHoaDon = N'" + cbx_mhd.SelectedValue.ToString() + "'," +
                                    "SoTienNo = " + sotien + "," +
                                    "NgayPhatSinh = '" + dtp_ngayps.Value.ToString("yyyy-MM-dd") + "'," +
                                    "HanNo = '" + dtp_hanno.Value.ToString("yyyy-MM-dd") + "'," +
                                    "TrangThai = N'" + laytrangthai() + "'," +
                                    "GhiChu = N'" + txt_ghichu.Text.Trim() + "' " +
                                    "WHERE MaCongNo = N'" + IDCN + "'";
                        ketnoi.capnhat(up);
                        string trangthaiHD = "Chưa Thanh Toán";
                        if (laytrangthai() == "Đã Tất Toán")
                            trangthaiHD = "Đã Thanh Toán";
                        else if (laytrangthai() == "Quá Hạn")
                            trangthaiHD = "Quá Hạn";
                        string uphd = "UPDATE HoaDon SET TrangThai = N'" + trangthaiHD + "' " +
                                        "WHERE MaHoaDon = N'" + cbx_mhd.SelectedValue.ToString() + "'";
                        int ketqua =ketnoi.capnhat(uphd);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Cập nhật công nợ thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincongno_Load(sender, e);
                            btn_lammoi_Click(sender, e);
                            IDCN = "";
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật công nợ không thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối CSDL!", "Hệ Thống Quản Lý Chung Cư - Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDCN == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.No)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string del = "DELETE FROM CongNo WHERE MaCongNo = N'" + IDCN + "'";
                    int ketqua = ketnoi.capnhat(del);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Xóa công nợ thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_thongtincongno_Load(sender, e);
                        btn_lammoi_Click(sender, e);
                        IDCN = "";
                    }
                    else
                    {
                        MessageBox.Show("Xóa công nợ không thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
