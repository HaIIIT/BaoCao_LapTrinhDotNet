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
    public partial class frm_btsc : Form
    {
        string IDSC = "";
        public frm_btsc()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void load_mayeucau(string maycHienTai = "")
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaYeuCau, (MaYeuCau + N' - ' + ISNULL(TieuDe, N'')) AS HienThi " +
                                 "FROM CSKH " +
                                 "WHERE ((TieuDe LIKE N'%Sửa Chữa%' OR TieuDe LIKE N'%Bảo Trì%') " +
                                 "AND TrangThai = N'Đang Xử Lý')";
                    if (maycHienTai != "")
                    {
                        sel += " OR MaYeuCau = N'" + maycHienTai + "'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaYeuCau"] = "";
                    r["HienThi"] = "--Chọn yêu cầu--";
                    tb.Rows.InsertAt(r, 0);
                    cbx_myc.DataSource = tb;
                    cbx_myc.DisplayMember = "HienThi";
                    cbx_myc.ValueMember = "MaYeuCau";
                    cbx_myc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load mã yêu cầu: " + ex.Message);
            }
            finally
            {
                ketnoi.dongketnoi();
            }
        }
        private void frm_btsc_Load(object sender, EventArgs e)
        {
            //xử lý combobox
            cbx_tt.Items.Clear();
            cbx_tt.Items.Add("--Chọn Trạng Thái--");
            cbx_tt.Items.Add("Hoàn Thành");
            cbx_tt.Items.Add("Đang Thực hiện");
            cbx_tt.Items.Add("Chờ Xử Lý");
            cbx_tt.SelectedIndex = 0;
            cbx_lbt.Items.Clear();
            cbx_lbt.Items.Add("--Chọn Loại Bảo Trì--");
            cbx_lbt.Items.Add("Bảo Trì");
            cbx_lbt.Items.Add("Sửa Chữa");
            cbx_lbt.SelectedIndex = 0;
            load_mayeucau();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaBaoTri, MaCanHo, MaYeuCau, LoaiBaoTri, TrangThai FROM BaoTriSuaChua";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_bt.DataSource = tb;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Khong the ket noi CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_bt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_bt.CurrentRow;
            string MaBaoTri = row.Cells["MaBaoTri"].Value.ToString();
            IDSC = row.Cells["MaBaoTri"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel ="SELECT * FROM BaoTriSuaChua WHERE MaBaoTri='"+MaBaoTri+"'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        string mayc = rdr["MaYeuCau"].ToString();
                        load_mayeucau(mayc);
                        txt_mbt.Text = rdr["MaBaoTri"].ToString();
                        txt_mch.Text = rdr["MaCanHo"].ToString();
                        cbx_myc.SelectedValue = mayc;
                        txt_td.Text = rdr["TieuDe"].ToString();
                        cbx_lbt.SelectedItem = rdr["LoaiBaoTri"].ToString();
                        cbx_tt.SelectedItem = rdr["TrangThai"].ToString();
                        txt_mt.Text = rdr["MoTa"].ToString();
                        dtp_ngayyc.Value = Convert.ToDateTime(rdr["NgayYeuCau"]);
                        dtp_ngaybd.Value = Convert.ToDateTime(rdr["NgayBatDau"]);
                        dtp_ngaykt.Value = Convert.ToDateTime(rdr["NgayHoanThanh"]);
                        txt_cp.Text = Convert.ToDecimal(rdr["ChiPhi"]).ToString("#,##0", new System.Globalization.CultureInfo("vi-VN"));
                        txt_ghichu.Text = rdr["GhiChu"].ToString();
                    }
                    rdr.Close();
                }
                else 
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                string mabt = txt_mbt.Text.Trim();
                string mach = txt_mch.Text.Trim();
                string mayc = cbx_myc.SelectedValue.ToString();
                string tieude = txt_td.Text.Trim();
                string loaibt = cbx_lbt.Text.Trim();
                string trangthai = cbx_tt.Text.Trim();
                string mota = txt_mt.Text.Trim();
                string ghichu = txt_ghichu.Text.Trim();
                decimal chiphi;
                if (mabt == "")
                {
                    MessageBox.Show("Vui lòng nhập mã bảo trì!");
                    txt_mbt.Focus();
                    return;
                }
                if (mach == "")
                {
                    MessageBox.Show("Vui lòng nhập mã căn hộ!");
                    txt_mch.Focus();
                    return;
                }
                if (tieude == "")
                {
                    MessageBox.Show("Vui lòng nhập tiêu đề!");
                    txt_td.Focus();
                    return;
                }
                if (cbx_lbt.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại bảo trì!");
                    cbx_lbt.Focus();
                    return;
                }
                if (cbx_tt.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!");
                    cbx_tt.Focus();
                    return;
                }
                if (txt_cp.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập chi phí!");
                    txt_cp.Focus();
                    return;
                }
                if (!decimal.TryParse(txt_cp.Text.Replace(".", "").Replace(",", ""), out chiphi))
                {
                    MessageBox.Show("Chi phí không hợp lệ!");
                    txt_cp.Focus();
                    return;
                }
                if (dtp_ngaybd.Value.Date < dtp_ngayyc.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày yêu cầu!");
                    dtp_ngaybd.Focus();
                    return;
                }
                if (dtp_ngaykt.Value.Date < dtp_ngaybd.Value.Date)
                {
                    MessageBox.Show("Ngày hoàn thành không được nhỏ hơn ngày bắt đầu!");
                    dtp_ngaykt.Focus();
                    return;
                }
                if (cbx_myc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mã yêu cầu!");
                    return;
                }
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string check = "SELECT MaBaoTri FROM BaoTriSuaChua WHERE MaBaoTri = N'" + mabt + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã bảo trì - sửa chữa đã tồn tại!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string ins = "INSERT INTO BaoTriSuaChua(MaBaoTri, MaCanHo, MaYeuCau, TieuDe, LoaiBaoTri, TrangThai, MoTa, NgayYeuCau, NgayBatDau, NgayHoanThanh, ChiPhi, GhiChu) " +
                            "VALUES (N'" + mabt + "', N'" + mach + "', N'" + mayc + "', N'" + tieude + "', N'" + loaibt + "', N'" + trangthai + "', N'" + mota + "', " +
                            "'" + dtp_ngayyc.Value.ToString("yyyy-MM-dd") + "', " +
                            "'" + dtp_ngaybd.Value.ToString("yyyy-MM-dd") + "', " +
                            "'" + dtp_ngaykt.Value.ToString("yyyy-MM-dd") + "', " +
                            chiphi + ", N'" + ghichu + "')";
                        int ketqua = ketnoi.capnhat(ins);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Thêm bảo trì / sửa chữa thành công!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            string myc = cbx_myc.SelectedValue.ToString();
                            string tt = cbx_tt.Text.Trim();
                            string tt_cskh = "";
                            if (tt == "Hoàn Thành")
                            {
                                tt_cskh = "Hoàn Thành";
                            }
                            else if (tt == "Đang Thực hiện")
                            {
                                tt_cskh = "Đang Xử Lý";
                            }
                            if (tt_cskh != "")
                            {
                                string up = "UPDATE CSKH SET TrangThai = N'" + tt_cskh + "' WHERE MaYeuCau = N'" + mayc + "'";
                                ketnoi.capnhat(up);
                            }
                            IDSC = txt_mbt.Text.Trim();
                            frm_btsc_Load(sender, e);
                            btn_Lamlai_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm bảo trì / sửa chữa không thành công!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
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
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txt_cp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cp.Text)) return;
            string text = txt_cp.Text.Replace(".", "");
            if (decimal.TryParse(text, out decimal value))
            {
                txt_cp.Text = value.ToString("#,##0", new System.Globalization.CultureInfo("vi-VN"));
                txt_cp.SelectionStart = txt_cp.Text.Length;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                string mabt = txt_mbt.Text.Trim();
                string mach = txt_mch.Text.Trim();
                string mayc = cbx_myc.SelectedValue != null ? cbx_myc.SelectedValue.ToString() : "";
                string tieude = txt_td.Text.Trim();
                string loaibt = cbx_lbt.Text.Trim();
                string trangthai = cbx_tt.Text.Trim();
                string mota = txt_mt.Text.Trim();
                string ghichu = txt_ghichu.Text.Trim();
                decimal chiphi;
                if (IDSC == "")
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần cập nhật!",
                        "Hệ Thống Quản Lý Chung Cư - Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (mabt == "")
                {
                    MessageBox.Show("Vui lòng nhập mã bảo trì!");
                    txt_mbt.Focus();
                    return;
                }
                if (mach == "")
                {
                    MessageBox.Show("Vui lòng nhập mã căn hộ!");
                    txt_mch.Focus();
                    return;
                }
                if (mayc == "")
                {
                    MessageBox.Show("Vui lòng chọn mã yêu cầu!");
                    cbx_myc.Focus();
                    return;
                }
                if (tieude == "")
                {
                    MessageBox.Show("Vui lòng nhập tiêu đề!");
                    txt_td.Focus();
                    return;
                }
                if (cbx_lbt.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại bảo trì!");
                    cbx_lbt.Focus();
                    return;
                }
                if (cbx_tt.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!");
                    cbx_tt.Focus();
                    return;
                }
                if (txt_cp.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập chi phí!");
                    txt_cp.Focus();
                    return;
                }
                if (!decimal.TryParse(txt_cp.Text.Replace(".", "").Replace(",", ""), out chiphi))
                {
                    MessageBox.Show("Chi phí không hợp lệ!");
                    txt_cp.Focus();
                    return;
                }
                if (dtp_ngaybd.Value.Date < dtp_ngayyc.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày yêu cầu!");
                    dtp_ngaybd.Focus();
                    return;
                }
                if (dtp_ngaykt.Value.Date < dtp_ngaybd.Value.Date)
                {
                    MessageBox.Show("Ngày hoàn thành không được nhỏ hơn ngày bắt đầu!");
                    dtp_ngaykt.Focus();
                    return;
                }
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string check = "SELECT MaBaoTri FROM BaoTriSuaChua WHERE MaBaoTri = N'" + mabt + "' AND MaBaoTri <> N'" + IDSC + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã bảo trì - sửa chữa đã tồn tại!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string up = "UPDATE BaoTriSuaChua SET " +
                                    "MaBaoTri = N'" + mabt + "', " +
                                    "MaCanHo = N'" + mach + "', " +
                                    "MaYeuCau = N'" + mayc + "', " +
                                    "TieuDe = N'" + tieude + "', " +
                                    "LoaiBaoTri = N'" + loaibt + "', " +
                                    "TrangThai = N'" + trangthai + "', " +
                                    "MoTa = N'" + mota + "', " +
                                    "NgayYeuCau = '" + dtp_ngayyc.Value.ToString("yyyy-MM-dd") + "', " +
                                    "NgayBatDau = '" + dtp_ngaybd.Value.ToString("yyyy-MM-dd") + "', " +
                                    "NgayHoanThanh = '" + dtp_ngaykt.Value.ToString("yyyy-MM-dd") + "', " +
                                    "ChiPhi = " + chiphi + ", " +
                                    "GhiChu = N'" + ghichu + "' " +
                                    "WHERE MaBaoTri = N'" + IDSC + "'";
                        int ketqua = ketnoi.capnhat(up);
                        if (ketqua > 0)
                        {
                            string tt_cskh = "";
                            if (trangthai == "Hoàn Thành")
                            {
                                tt_cskh = "Hoàn Thành";
                            }
                            else if (trangthai == "Đang Thực hiện")
                            {
                                tt_cskh = "Đang Xử Lý";
                            }
                            if (tt_cskh != "")
                            {
                                string up_cskh = "UPDATE CSKH SET TrangThai = N'" + tt_cskh + "' WHERE MaYeuCau = N'" + mayc + "'";
                                ketnoi.capnhat(up_cskh);
                            }
                            MessageBox.Show("Cập nhật bảo trì / sửa chữa thành công!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            IDSC = mabt;
                            frm_btsc_Load(sender, e);
                            btn_Lamlai_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (IDSC == "")
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần xóa!",
                        "Hệ Thống Quản Lý Chung Cư - Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa bản ghi này không?",
                    "Hệ Thống Quản Lý Chung Cư - Xác Nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (ketnoi.moketnoi())
                {
                    string mayc = "";
                    // lấy mã yêu cầu trước khi xóa
                    string sel = "SELECT MaYeuCau FROM BaoTriSuaChua WHERE MaBaoTri = N'" + IDSC + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        mayc = rdr["MaYeuCau"].ToString();
                    }
                    rdr.Close();
                    string del = "DELETE FROM BaoTriSuaChua WHERE MaBaoTri = N'" + IDSC + "'";
                    int ketqua = ketnoi.capnhat(del);
                    if (ketqua > 0)
                    {
                        // cập nhật lại trạng thái yêu cầu ở bảng CSKH
                        if (mayc != "")
                        {
                            string up_cskh = "UPDATE CSKH SET TrangThai = N'Đang Xử Lý' WHERE MaYeuCau = N'" + mayc + "'";
                            ketnoi.capnhat(up_cskh);
                        }
                        MessageBox.Show("Xóa bảo trì / sửa chữa thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        IDSC = "";
                        btn_Lamlai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Lamlai_Click(object sender, EventArgs e)
        {
            txt_mbt.Clear();
            txt_mch.Clear();
            txt_td.Clear();
            txt_mt.Clear();
            txt_cp.Clear();
            txt_ghichu.Clear();
            cbx_lbt.SelectedIndex = 0;
            cbx_tt.SelectedIndex = 0;
            load_mayeucau();
            cbx_myc.SelectedIndex = 0;
            dtp_ngayyc.Value = DateTime.Now;
            dtp_ngaybd.Value = DateTime.Now;
            dtp_ngaykt.Value = DateTime.Now;
            IDSC = "";
            frm_btsc_Load(sender, e);
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
