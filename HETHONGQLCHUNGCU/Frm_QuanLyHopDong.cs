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
    public partial class Frm_QuanLyHopDong : Form
    {
        string IDHD = "";
        public Frm_QuanLyHopDong()
        {
            InitializeComponent();
        }
        void load_cbx_cudan()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaCuDan FROM CuDan";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaCuDan"] = "";
                row["MaCuDan"] = "-Click-";
                tb.Rows.InsertAt(row, 0);
                cbx_cd.DataSource = tb;                
                cbx_cd.DisplayMember = "MaCuDan";   
                cbx_cd.ValueMember = "MaCuDan";   
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        void load_cbx_canho()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaCanHo FROM CanHo WHERE TrangThai = N'Trống'";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaCanHo"] = "";
                row["MaCanHo"] = "-Click-";
                tb.Rows.InsertAt(row, 0);
                cbx_ch.DataSource = tb;
                cbx_ch.DisplayMember = "MaCanHo"; 
                cbx_ch.ValueMember = "MaCanHo";
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        private void Frm_QuanLyHopDong_Load(object sender, EventArgs e)
        {
            load_cbx_canho();
            load_cbx_cudan();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT MaHopDong, MaCuDan , MaCanHo, LoaiHopDong FROM HopDong";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgv_dshopdong.DataSource = tb;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dtp_ngbd.ShowCheckBox = true;
            dtp_ngkt.ShowCheckBox = true;
            dtp_ngban.ShowCheckBox = true;
        }
        private void dgv_dshopdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_dshopdong.CurrentRow;
            IDHD = row.Cells["MaHopDong"].Value.ToString();
            string MaHopDong = row.Cells["MaHopDong"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaHopDong, MaCuDan , MaCanHo, VaiTro, NgayBatDau, " +
                        "NgayKetThuc, NgayBan, LaChuHo, LoaiHopDong FROM HopDong WHERE MaHopDong ='"+MaHopDong+"'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mahd.Text = rdr["MaHopDong"].ToString();
                        cbx_cd.SelectedValue = rdr["MaCuDan"].ToString();
                        cbx_ch.SelectedValue = rdr["MaCanHo"].ToString();
                        string loaihopdong = rdr["LoaiHopDong"].ToString().Trim();
                        if (loaihopdong == "0")
                        {
                            rdb_thue.Checked = true;
                        }
                        else if (loaihopdong == "1") { 
                        rdb_ban.Checked = true;
                        }
                        txt_vaitro.Text = rdr["VaiTro"].ToString();
                        dtp_ngbd.Value = rdr["NgayBatDau"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rdr["NgayBatDau"]);
                        dtp_ngkt.Value = rdr["NgayKetThuc"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rdr["NgayKetThuc"]);
                        dtp_ngban.Value = rdr["NgayBan"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rdr["NgayBan"]);
                        if (rdr["NgayBatDau"] != DBNull.Value && rdr["NgayKetThuc"] != DBNull.Value)
                        {
                            dtp_ngban.Visible = false;
                            lbl_ngban.Visible = false;
                            dtp_ngbd.Visible = true;
                            lbl_ngbd.Visible = true;
                            dtp_ngkt.Visible = true;
                            lbl_ngkt.Visible = true;
                        }
                        else if (rdr["NgayBan"] != DBNull.Value)
                        {
                            dtp_ngban.Visible = true;
                            lbl_ngban.Visible = true;
                            dtp_ngbd.Visible = false;
                            lbl_ngbd.Visible = false;
                            dtp_ngkt.Visible = false;
                            lbl_ngkt.Visible = false;
                        }
                        else
                        {
                            dtp_ngban.Visible = true;
                            lbl_ngban.Visible = true;
                            dtp_ngbd.Visible = true;
                            lbl_ngbd.Visible = true;
                            dtp_ngkt.Visible = true;
                            lbl_ngkt.Visible = true;
                        }
                        string chuho = rdr["LaChuHo"].ToString().Trim();
                        if (chuho == "1")
                        {
                            rdb_lachuho.Checked = true;
                        }
                        rdr.Close();
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_lamlai_Click(object sender, EventArgs e)
        {
            txt_mahd.Clear();
            cbx_cd.SelectedIndex = 0;
            cbx_ch.SelectedIndex = 0;
            txt_vaitro.Clear();
            rdb_lachuho.Checked=false;
            dtp_ngban.Value=DateTime.Now;   
            dtp_ngbd.Value=DateTime.Now;
            dtp_ngkt.Value=DateTime.Now;
            dtp_ngban.Visible = true; lbl_ngban.Visible = true;
            dtp_ngbd.Visible = true; lbl_ngban.Visible=true;
            dtp_ngkt.Visible = true; lbl_ngkt.Visible = true;
            rdb_thue.Checked=false;
            rdb_ban.Checked=false;
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cbx_cd.SelectedIndex == 0 || cbx_cd.SelectedValue == null || cbx_cd.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn cư dân!");
                return;
            }
            if (cbx_ch.SelectedIndex == 0 || cbx_ch.SelectedValue == null || cbx_ch.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn căn hộ!");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string selStr ="SELECT MaHopDong FROM HopDong WHERE MaHopDong='"+txt_mahd.Text.Trim()+"'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã hợp đồng đã tồn tại!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }rdr.Close();
                    if (hople)
                    {
                        string macd = cbx_cd.SelectedValue.ToString();
                        string mach = cbx_ch.SelectedValue.ToString();
                        string loaihopdong = rdb_thue.Checked ? "0" :"1";
                        string lachuho = rdb_lachuho.Checked ? "1" :"0";
                        string ngayBatDau = dtp_ngbd.Checked ? "'" + dtp_ngbd.Value.ToString("yyyy-MM-dd") + "'"  : "NULL";
                        string ngayKetThuc = dtp_ngkt.Checked ? "'" + dtp_ngkt.Value.ToString("yyyy-MM-dd") + "'" : "NULL";
                        string ngayBan = dtp_ngban.Checked ? "'" + dtp_ngban.Value.ToString("yyyy-MM-dd") + "'" : "NULL";                       
                        string sql = "INSERT INTO HopDong(MaHopDong, MaCuDan, MaCanHo, LoaiHopDong, VaiTro, NgayBatDau, NgayKetThuc, NgayBan, LaChuHo)" +
                                "VALUES ('" + txt_mahd.Text.Trim() + "'," +
                                "'" + macd + "'," +
                                "'" + mach + "'," +
                                loaihopdong + "," +
                                "'" + txt_vaitro.Text.Trim() + "'," +
                                ngayBatDau + "," +
                                ngayKetThuc + "," +
                                ngayBan + "," +
                                lachuho + ")";
                        int ketqua = ketnoi.capnhat(sql);
                        if(ketqua > 0)
                        {
                            string trangThaiCanHo = rdb_thue.Checked ? "Đã Cho Thuê" : "Đã Bán";
                            string upCanHo = "UPDATE CanHo SET TrangThai = N'" + trangThaiCanHo + "' " +
                                             "WHERE MaCanHo = '" + mach + "'";
                            ketnoi.capnhat(upCanHo);
                            MessageBox.Show("Thêm hợp đồng thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm hợp đồng không thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo",
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
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cbx_cd.SelectedIndex == 0 || cbx_cd.SelectedValue == null || cbx_cd.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn cư dân!");
                return;
            }
            if (cbx_ch.SelectedIndex == 0 || cbx_ch.SelectedValue == null || cbx_ch.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn căn hộ!");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string selStr = "SELECT MaHopDong FROM HopDong " +
                                    "WHERE MaHopDong='" + txt_mahd.Text.Trim() + "' " +
                                    "AND MaHopDong<>'" + IDHD + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã hợp đồng đã tồn tại!", "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();
                    if (hople)
                    {
                        string maCanHoCu = "";
                        string selCanHoCu = "SELECT MaCanHo FROM HopDong WHERE MaHopDong='" + IDHD + "'";
                        SqlDataReader rdr1 = ketnoi.truyvan(selCanHoCu);
                        if (rdr1.Read())
                        {
                            maCanHoCu = rdr1["MaCanHo"].ToString().Trim();
                        }
                        rdr1.Close();
                        string macd = cbx_cd.SelectedValue.ToString();
                        string mach = cbx_ch.SelectedValue.ToString();
                        string loaihopdong = rdb_thue.Checked ? "0" : "1";
                        string lachuho = rdb_lachuho.Checked ? "1" : "0";
                        string ngayBatDau = dtp_ngbd.Checked ? "'" + dtp_ngbd.Value.ToString("yyyy-MM-dd") + "'" : "NULL";
                        string ngayKetThuc = dtp_ngkt.Checked ? "'" + dtp_ngkt.Value.ToString("yyyy-MM-dd") + "'" : "NULL";
                        string ngayBan = dtp_ngban.Checked ? "'" + dtp_ngban.Value.ToString("yyyy-MM-dd") + "'" : "NULL";
                        string upStr = "UPDATE HopDong SET " +
                                       "MaHopDong='" + txt_mahd.Text.Trim() + "'," +
                                       "MaCuDan='" + macd + "'," +
                                       "MaCanHo='" + mach + "'," +
                                       "LoaiHopDong=" + loaihopdong + "," +
                                       "VaiTro=N'" + txt_vaitro.Text.Trim() + "'," +
                                       "NgayBatDau=" + ngayBatDau + "," +
                                       "NgayKetThuc=" + ngayKetThuc + "," +
                                       "NgayBan=" + ngayBan + "," +
                                       "LaChuHo=" + lachuho + " " +
                                       "WHERE MaHopDong='" + IDHD + "'";
                        int kq = ketnoi.capnhat(upStr);
                        if (kq > 0)
                        {
                            string trangThaiCanHoMoi = rdb_thue.Checked ? "Đã Cho Thuê" : "Đã Bán";
                            // cập nhật căn hộ mới
                            string upCanHoMoi = "UPDATE CanHo SET TrangThai=N'" + trangThaiCanHoMoi + "' " +
                                                "WHERE MaCanHo='" + mach + "'";
                            ketnoi.capnhat(upCanHoMoi);
                            // nếu đổi sang căn hộ khác thì trả trạng thái căn cũ về trống
                            if (maCanHoCu != "" && maCanHoCu != mach)
                            {
                                string upCanHoCu = "UPDATE CanHo SET TrangThai=N'Trống' " +
                                                   "WHERE MaCanHo='" + maCanHoCu + "'";
                                ketnoi.capnhat(upCanHoCu);
                            }
                            MessageBox.Show("Cập nhật hợp đồng thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IDHD = txt_mahd.Text.Trim();
                            Frm_QuanLyHopDong_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL!", "Hệ Thống Quản Lý Chung Cư - Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                    "Bạn có chắc muốn xóa hợp đồng này?", "Hệ Thống Quản Lý Chung Cư - Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string maCanHo = "";
                    string selCanHo = "SELECT MaCanHo FROM HopDong WHERE MaHopDong='" + IDHD + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selCanHo);
                    if (rdr.Read())
                    {
                        maCanHo = rdr["MaCanHo"].ToString().Trim();
                    }
                    rdr.Close();
                    string delStr = "DELETE FROM HopDong WHERE MaHopDong='" + IDHD + "'";
                    int kq = ketnoi.capnhat(delStr);
                    if (kq > 0)
                    {
                        if (maCanHo != "")
                        {
                            string checkStr = "SELECT COUNT(*) FROM HopDong WHERE MaCanHo='" + maCanHo + "'";
                            SqlDataReader rdrCheck = ketnoi.truyvan(checkStr);
                            if (rdrCheck.Read())
                            {
                                int soHopDongConLai = Convert.ToInt32(rdrCheck[0]);
                                if (soHopDongConLai == 0)
                                {
                                    string upCanHo = "UPDATE CanHo SET TrangThai=N'Trống' WHERE MaCanHo='" + maCanHo + "'";
                                    ketnoi.capnhat(upCanHo);
                                }
                            }
                            rdrCheck.Close();
                        }
                        MessageBox.Show("Xóa hợp đồng thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_QuanLyHopDong_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL!",
                        "Hệ Thống Quản Lý Chung Cư - Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
