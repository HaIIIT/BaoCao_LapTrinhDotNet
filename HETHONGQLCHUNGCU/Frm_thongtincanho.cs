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
    public partial class Frm_thongtincanho : Form
    {
        string IDCH = "";
        public Frm_thongtincanho()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        string TaoMaCanHoTuDong()
        {
            Connection ketnoi = new Connection();
            string maMoi = "CH001";
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT TOP 1 MaCanHo FROM CanHo ORDER BY MaCanHo DESC";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        string maCuoi = rdr["MaCanHo"].ToString(); // ví dụ CH009
                        int so = int.Parse(maCuoi.Substring(2)) + 1;
                        maMoi = "CH" + so.ToString("D3");
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã căn hộ: " + ex.Message);
            }
            return maMoi;
        }
        void tinhgia()
        {
            decimal dientich = upd_diemtich.Value;
            decimal giaban = 0;
            decimal giathue = 0;
            decimal sophongngu = 1;
            if (dientich >= 25 && dientich <= 35)
            {
                giaban = dientich * 35000000;
                giathue = 7000000;
                sophongngu = 1;
            }
            else if (dientich >= 50 && dientich <= 75)
            {
                giaban = dientich * 55000000;
                giathue = 20000000;
                sophongngu = 2;
            }
            else if (dientich >= 80 && dientich <= 119)
            {
                giaban = dientich * 75000000;
                giathue = 30000000;
                sophongngu = 3;
            }
            else if (dientich >= 120)
            {
                giaban = dientich * 120000000;
                giathue = 55000000;
                sophongngu = 4;
            }
            txt_giaban.Text=giaban.ToString("N0");
            txt_giathue.Text = giathue.ToString("N0");
            upd_phongngu.Value = Convert.ToDecimal(sophongngu);
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_thongtincanho_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaCanHo, SoCan, TrangThai FROM CanHo";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgv_dscanho.DataSource = tb;
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_mch.Text = TaoMaCanHoTuDong();
        }
        private void dgv_dscanho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_dscanho.CurrentRow;
            IDCH = row.Cells["MaCanHo"].Value.ToString();
            string MaCanHo = row.Cells["MaCanHo"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr="SELECT * FROM CanHo WHERE MaCanHo = '"+MaCanHo+"'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read()) 
                    {
                        txt_mch.Text = rdr["MaCanHo"].ToString();
                        txt_socan.Text = rdr["SoCan"].ToString();
                        decimal dientich = 0;
                        decimal.TryParse(rdr["DienTich"].ToString(), out dientich);
                        upd_diemtich.Value= dientich;
                        decimal sophongngu = 0;
                        decimal.TryParse(rdr["SoPhongNgu"].ToString(), out sophongngu);
                        upd_phongngu.Value= sophongngu;
                        string noithat = rdr["NoiThat"].ToString().Trim();
                        rdb_co.Checked = false;
                        rdb_khong.Checked = false;
                        if (noithat == "0")
                        {
                            rdb_khong.Checked = true;
                        }else if(noithat == "1")
                        {
                            rdb_co.Checked = true;
                        }
                        txt_giaban.Text = Convert.ToDecimal(rdr["GiaBan"]).ToString("N0");
                        txt_giathue.Text = Convert.ToDecimal(rdr["GiaThue"]).ToString("N0");
                        decimal sotang = 0;
                        decimal.TryParse(rdr["Tang"].ToString(), out sotang);
                        upd_tang.Value= sotang;
                        if (rdr["TrangThai"].ToString() == "Trống")
                        {
                            rdb_trong.Checked = true;
                        }
                        else if (rdr["TrangThai"].ToString() == "Đã Cho Thuê")
                        {
                            rdb_chothue.Checked = true;
                        }
                        else if (rdr["TrangThai"].ToString() == "Đã Bán")
                        {
                            rdb_daban.Checked = true;
                        }
                        else if (rdr["TrangThai"].ToString() == "Đang Sửa Chữa")
                        {
                            rdb_suachua.Checked = true;
                        }
                        txt_ghichu.Text = rdr["GhiChu"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_lamlai_Click(object sender, EventArgs e)
        {
            txt_mch.Text = TaoMaCanHoTuDong();
            txt_socan.Text = "A-";
            txt_giaban.Clear();
            txt_giathue.Clear();
            upd_diemtich.Value = upd_diemtich.Minimum;
            upd_phongngu.Value = upd_phongngu.Minimum;
            rdb_co.Checked = false;
            rdb_khong.Checked = false;
            rdb_trong.Checked = false;
            rdb_daban.Checked=false;
            rdb_chothue.Checked = false;
            rdb_suachua.Checked=false;
            txt_ghichu.Clear();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    
                    decimal dientich = upd_diemtich.Value;
                    decimal giaban = 0;
                    decimal giathue = 0;
                    decimal sophongngu = 1;
                    if (dientich >= 25 && dientich <= 35)
                    {
                        giaban = dientich * 35000000;
                        giathue = 7000000;
                        sophongngu = 1;
                    }
                    else if (dientich >= 50 && dientich <= 75)
                    {
                        giaban = dientich * 55000000;
                        giathue = 20000000;
                        sophongngu = 2;
                    }
                    else if (dientich >= 80 && dientich <= 119)
                    {
                        giaban = dientich * 75000000;
                        giathue = 30000000;
                        sophongngu = 3;
                    }
                    else if (dientich >= 120)
                    {
                        giaban = dientich * 120000000;
                        giathue = 55000000;
                        sophongngu = 4;
                    }
                    bool hople = true;
                    string sel="SELECT MaCanHo FROM CanHo WHERE MaCanHo ='"+txt_mch.Text.Trim()+ "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã Căn Hộ: "+txt_mch.Text+" Đã Tồn Tại!", "Hệ Thống Quản Lý Chung Cư - Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }rdr.Close();
                    if (hople)
                    {                        
                        string macanho = TaoMaCanHoTuDong();
                        string socan = txt_socan.Text.Trim();
                        decimal sopn = upd_phongngu.Value;
                        string noithat = rdb_co.Checked ? "1" : "0";
                        string trangthai = rdb_trong.Checked ? "Trống" :
                                           rdb_daban.Checked ? "Đã Bán" :
                                           rdb_chothue.Checked ? "Đã Cho Thuê" :
                                           "Đang Sửa Chữa";
                        string ins = "INSERT INTO CanHo(MaCanHo, SoCan, DienTich, SoPhongNgu, GiaBan, GiaThue, Tang,  NoiThat, TrangThai, GhiChu) " +
                            "VALUES ('"+macanho+"',"+
                            "'"+socan+"',"+
                            upd_diemtich.Value+","+
                            sopn+","+
                            giaban.ToString().Replace(",", ".") + ","+
                            giathue.ToString().Replace(",", ".") + ","+
                            upd_tang.Value+","+
                            "'"+noithat+"',"+
                            "N'"+trangthai+"',"+
                            "N'"+txt_ghichu.Text.Trim()+"')";
                        int ketqua = ketnoi.capnhat(ins);
                        if(ketqua > 0)
                        {
                            MessageBox.Show("Thêm căn hộ thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincanho_Load(sender, e);
                            txt_mch.Text = TaoMaCanHoTuDong();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không Thể Kết Nối Cơ Sở Dữ Liệu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void upd_diemtich_ValueChanged(object sender, EventArgs e)
        {
            tinhgia();
        }
        private void txt_socan_Leave(object sender, EventArgs e)
        {
            if (!txt_socan.Text.StartsWith("A-"))
            {
                txt_socan.Text="A-"+txt_socan.Text.Trim();
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
                    string sel = "SELECT MaCanHo FROM CanHo WHERE MaCanHo='" + txt_mch.Text.Trim() + "' AND " +
                        "MaCanHo <> '" + IDCH + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã căn hộ đã tồn tại. Vui lòng nhập mã khác.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    rdr.Close();
                    if (hople)
                    {
                        decimal giaban = Convert.ToDecimal(txt_giaban.Text.Replace(",", ""));
                        decimal giathue = Convert.ToDecimal(txt_giathue.Text.Replace(",", ""));
                        string trangthai = rdb_trong.Checked ? "Trống" :
                        rdb_daban.Checked ? "Đã Bán" :
                        rdb_chothue.Checked ? "Đã Cho Thuê" :
                        "Đang Sửa Chữa";
                        string upStr = "UPDATE CanHo SET " +
                            "MaCanHo='" + txt_mch.Text + "'," +
                            "SoCan='" + txt_socan.Text + "'," +
                            "Tang=" + upd_tang.Value + "," +
                            "DienTich=" + upd_diemtich.Value + "," +
                            "SoPhongNgu=" + upd_phongngu.Value + "," +
                            "NoiThat=" + (rdb_co.Checked ? 1 : 0) + "," +
                            "GiaBan=" + giaban.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," +
                            "GiaThue=" + giathue.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," +
                            "TrangThai=N'" +trangthai+"',"+
                            "GhiChu='"+txt_ghichu.Text+"'"+
                            " WHERE MaCanHo='"+IDCH+"'";
                        int ketqua = ketnoi.capnhat(upStr);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Cập nhật căn hộ thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincanho_Load(sender, e);
                        }
                        else 
                        { MessageBox.Show("Cập nhật căn hộ thất bại!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
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
            DialogResult rs = MessageBox.Show(
                    "Bạn có chắc muốn xóa căn hộ này?", "Hệ Thống Quản Lý Chung Cư - Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) 
            {
                Connection ketnoi = new Connection();
                try
                {
                    if (ketnoi.moketnoi())
                    {
                        string delStr = "DELETE FROM CanHo WHERE MaCanHo='" + IDCH + "'";
                        int ketqua = ketnoi.capnhat(delStr);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Xóa căn hộ thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincanho_Load(sender, e);
                        }
                        else 
                        {
                            MessageBox.Show("Xóa căn hộ không thành công!",
                            "Hệ Thống Quản Lý Chung Cư - Thông Báo",
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
}
