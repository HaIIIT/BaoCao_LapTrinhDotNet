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
using static System.Net.WebRequestMethods;

namespace HETHONGQLCHUNGCU
{
    public partial class frm_dgns : Form
    {
        string IDDG = "";
        public frm_dgns()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void TinhTongVaXepLoai()
        {
            double dtp, dhs, dtd;
            if (!double.TryParse(txt_dtp.Text.Trim(), out dtp) ||
                !double.TryParse(txt_dhx.Text.Trim(), out dhs) ||
                !double.TryParse(txt_dtd.Text.Trim(), out dtd))
            {
                txt_tongd.Clear();
                cbx_xl.SelectedIndex = 0;
                return;
            }
            if (dtp < 0 || dtp > 10 || dhs < 0 || dhs > 10 || dtd < 0 || dtd > 10)
            {
                txt_tongd.Clear();
                cbx_xl.SelectedIndex = 0;
                return;
            }
            double tong = dtp + dhs + dtd;
            txt_tongd.Text = tong.ToString();
            if (tong <= 10) cbx_xl.Text = "Cảnh Báo";
            else if (tong <= 15) cbx_xl.Text = "Trung Bình";
            else if (tong <= 20) cbx_xl.Text = "Khá";
            else if (tong <= 27) cbx_xl.Text = "Giỏi";
            else cbx_xl.Text = "Xuất Sắc";
        }
        private bool LayDiemVaXepLoai(out int dtp, out int dhs, out int dtd, out int tongdiem, out string xeploai)
        {
            dtp = 0;
            dhs = 0;
            dtd = 0;
            tongdiem = 0;
            xeploai = "";
            if (txt_dtp.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm tác phong");
                txt_dtp.Focus();
                return false;
            }
            if (txt_dhx.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm hiệu suất");
                txt_dhx.Focus();
                return false;
            }
            if (txt_dtd.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm thái độ");
                txt_dtd.Focus();
                return false;
            }
            if (!int.TryParse(txt_dtp.Text.Trim(), out dtp))
            {
                MessageBox.Show("Điểm tác phong phải là số");
                txt_dtp.Focus();
                return false;
            }
            if (!int.TryParse(txt_dhx.Text.Trim(), out dhs))
            {
                MessageBox.Show("Điểm hiệu suất phải là số");
                txt_dhx.Focus();
                return false;
            }
            if (!int.TryParse(txt_dtd.Text.Trim(), out dtd))
            {
                MessageBox.Show("Điểm thái độ phải là số");
                txt_dtd.Focus();
                return false;
            }
            if (dtp < 0 || dtp > 10 || dhs < 0 || dhs > 10 || dtd < 0 || dtd > 10)
            {
                MessageBox.Show("Mỗi điểm phải nằm trong khoảng 0 đến 10");
                return false;
            }
            tongdiem = dtp + dhs + dtd;
            if (tongdiem >= 0 && tongdiem <= 10)
                xeploai = "Cảnh Báo";
            else if (tongdiem >= 11 && tongdiem <= 15)
                xeploai = "Trung Bình";
            else if (tongdiem >= 16 && tongdiem <= 20)
                xeploai = "Khá";
            else if (tongdiem >= 21 && tongdiem <= 27)
                xeploai = "Giỏi";
            else if (tongdiem >= 28 && tongdiem <= 30)
                xeploai = "Xuất Sắc";

            txt_tongd.Text = tongdiem.ToString();
            cbx_xl.Text = xeploai;

            return true;
        }
        private void Diem_TextChanged(object sender, EventArgs e)
        {
            TinhTongVaXepLoai();
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
                    cbx_ns.DataSource = tb;
                    cbx_ns.DisplayMember = "HienThi";
                    cbx_ns.ValueMember = "MaNhanSu";
                    cbx_ns.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân sự: " + ex.Message);
            }
        }
        private void frm_dgns_Load(object sender, EventArgs e)
        {
            cbx_xl.Items.Clear();
            cbx_xl.Items.Add("--Chọn Xếp Loại--");
            cbx_xl.Items.Add("Xuất Sắc");
            cbx_xl.Items.Add("Giỏi");
            cbx_xl.Items.Add("Khá");
            cbx_xl.Items.Add("Trung Bình");
            cbx_xl.Items.Add("Cảnh Báo");
            cbx_xl.SelectedIndex = 0;
            load_cbx_mns();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaDanhGia, MaNhanSU, KyDanhGia FROM DanhGiaNhanSu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dgvdsdg.DataSource = dt;
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
                MessageBox.Show("Lỗi: "+ex.Message);
            }
            txt_dtp.TextChanged -= Diem_TextChanged;
            txt_dhx.TextChanged -= Diem_TextChanged;
            txt_dtd.TextChanged -= Diem_TextChanged;
            txt_dtp.TextChanged += Diem_TextChanged;
            txt_dhx.TextChanged += Diem_TextChanged;
            txt_dtd.TextChanged += Diem_TextChanged;
        }

        private void dgvdsdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvdsdg.CurrentRow;
            IDDG = row.Cells["MaDanhGia"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM DanhGiaNhanSu WHERE MaDanhGia = N'" + IDDG + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        txt_mdg.Text = rdr["MaDanhGia"].ToString();
                        cbx_ns.SelectedValue = rdr["MaNhanSu"].ToString();
                        txt_kydg.Text = rdr["KyDanhGia"].ToString();
                        if (rdr["NgayDanhGia"] != DBNull.Value)
                            dtp_ngdg.Value = Convert.ToDateTime(rdr["NgayDanhGia"]);
                        txt_nx.Text = rdr["NhanXet"].ToString();
                        txt_dtp.Text = rdr["DiemTacPhong"].ToString();
                        txt_dhx.Text = rdr["DiemHieuSuat"].ToString();
                        txt_dtd.Text = rdr["DiemThaiDo"].ToString();
                        txt_tongd.Text = rdr["TongDiem"].ToString();
                        string xl = rdr["XepLoai"].ToString();
                        cbx_xl.SelectedItem = xl;
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
            if (txt_mdg.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đánh giá");
                txt_mdg.Focus();
                return;
            }
            if (cbx_ns.SelectedIndex <= 0 || cbx_ns.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự");
                cbx_ns.Focus();
                return;
            }
            if (txt_kydg.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập kỳ đánh giá");
                txt_kydg.Focus();
                return;
            }
            if (txt_dtp.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm tác phong");
                txt_dtp.Focus();
                return;
            }
            if (txt_dhx.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm hiệu suất");
                txt_dhx.Focus();
                return;
            }
            if (txt_dtd.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập điểm thái độ");
                txt_dtd.Focus();
                return;
            }
            int dtp, dhs, dtd, tongdiem;
            if (!int.TryParse(txt_dtp.Text.Trim(), out dtp))
            {
                MessageBox.Show("Điểm tác phong phải là số");
                txt_dtp.Focus();
                return;
            }
            if (!int.TryParse(txt_dhx.Text.Trim(), out dhs))
            {
                MessageBox.Show("Điểm hiệu suất phải là số");
                txt_dhx.Focus();
                return;
            }
            if (!int.TryParse(txt_dtd.Text.Trim(), out dtd))
            {
                MessageBox.Show("Điểm thái độ phải là số");
                txt_dtd.Focus();
                return;
            }
            if (dtp < 0 || dtp > 10 || dhs < 0 || dhs > 10 || dtd < 0 || dtd > 10)
            {
                MessageBox.Show("Mỗi điểm phải nằm trong khoảng từ 0 đến 10");
                return;
            }
            tongdiem = dtp + dhs + dtd;
            txt_tongd.Text = tongdiem.ToString();
            string xeploai = "";
            if (tongdiem >= 0 && tongdiem <= 10)
                xeploai = "Cảnh Báo";
            else if (tongdiem >= 11 && tongdiem <= 15)
                xeploai = "Trung Bình";
            else if (tongdiem >= 16 && tongdiem <= 20)
                xeploai = "Khá";
            else if (tongdiem >= 21 && tongdiem <= 27)
                xeploai = "Giỏi";
            else if (tongdiem >= 28 && tongdiem <= 30)
                xeploai = "Xuất Sắc";
            cbx_xl.Text = xeploai;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string check = "SELECT MaDanhGia FROM DanhGiaNhanSu WHERE MaDanhGia = N'" + txt_mdg.Text.Trim() + "'";
                    SqlDataReader rdr = ketnoi.truyvan(check);
                    if (rdr.Read())
                    {
                        rdr.Close();
                        ketnoi.dongketnoi();
                        MessageBox.Show("Mã đánh giá đã tồn tại");
                        txt_mdg.Focus();
                        return;
                    }
                    rdr.Close();
                    string sql = "INSERT INTO DanhGiaNhanSu(MaDanhGia, MaNhanSu, KyDanhGia, NgayDanhGia, NhanXet, DiemTacPhong, DiemHieuSuat, DiemThaiDo, TongDiem, XepLoai) " +
                                 "VALUES(N'" + txt_mdg.Text.Trim() + "', N'" + cbx_ns.SelectedValue.ToString() + "', N'" + txt_kydg.Text.Trim() +
                                 "', '" + dtp_ngdg.Value.ToString("yyyy-MM-dd") + "', N'" + txt_nx.Text.Trim() +
                                 "', " + dtp + ", " + dhs + ", " + dtd + ", " + tongdiem + ", N'" + xeploai + "')";
                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Thêm đánh giá thành công","Hệ Thống Quản Lý Chung Cư - Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frm_dgns_Load(sender, e);
                        btn_lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }
        private void txt_dtp_TextChanged(object sender, EventArgs e)
        {
            TinhTongVaXepLoai();
        }
        private void txt_dhx_TextChanged(object sender, EventArgs e)
        {
            TinhTongVaXepLoai();
        }
        private void txt_dtd_TextChanged(object sender, EventArgs e)
        {
            TinhTongVaXepLoai();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (IDDG == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật");
                return;
            }
            if (txt_mdg.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã đánh giá");
                txt_mdg.Focus();
                return;
            }
            if (cbx_ns.SelectedIndex <= 0 || cbx_ns.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự");
                cbx_ns.Focus();
                return;
            }
            if (txt_kydg.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập kỳ đánh giá");
                txt_kydg.Focus();
                return;
            }
            int dtp, dhs, dtd, tongdiem;
            string xeploai;

            if (!LayDiemVaXepLoai(out dtp, out dhs, out dtd, out tongdiem, out xeploai))
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "UPDATE DanhGiaNhanSu SET " +
                                 "MaNhanSu = N'" + cbx_ns.SelectedValue.ToString() + "', " +
                                 "KyDanhGia = N'" + txt_kydg.Text.Trim() + "', " +
                                 "NgayDanhGia = '" + dtp_ngdg.Value.ToString("yyyy-MM-dd") + "', " +
                                 "NhanXet = N'" + txt_nx.Text.Trim() + "', " +
                                 "DiemTacPhong = " + dtp + ", " +
                                 "DiemHieuSuat = " + dhs + ", " +
                                 "DiemThaiDo = " + dtd + ", " +
                                 "TongDiem = " + tongdiem + ", " +
                                 "XepLoai = N'" + xeploai + "' " +
                                 "WHERE MaDanhGia = N'" + IDDG + "'";
                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        frm_dgns_Load(sender, e);
                        btn_lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Cập Nhật dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDDG == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa đánh giá này không?",
                "Hệ Thống Quản Lý Chung Cư - Xác Nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (kq != DialogResult.Yes)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "DELETE FROM DanhGiaNhanSu WHERE MaDanhGia = N'" + IDDG + "'";
                    if (ketnoi.capnhat(sql) > 0)
                    {
                        MessageBox.Show("Xóa thành công",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        frm_dgns_Load(sender, e);
                        btn_lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Hệ Thống Quản Lý Chung Cư - Lỗi Xóa dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            IDDG = "";
            txt_mdg.Clear();
            cbx_ns.SelectedIndex = 0;
            txt_kydg.Clear();
            dtp_ngdg.Value = DateTime.Now;
            txt_nx.Clear();
            txt_dtp.Clear();
            txt_dhx.Clear();
            txt_dtd.Clear();
            txt_tongd.Clear();
            cbx_xl.SelectedIndex = 0;
            txt_mdg.Enabled = true;
            frm_dgns_Load(sender, e);
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
