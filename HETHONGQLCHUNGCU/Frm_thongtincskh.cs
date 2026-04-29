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
    public partial class Frm_thongtincskh : Form
    {
        string IDYC = "";
        public Frm_thongtincskh()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void load_macudan()
        {
            Connection kn = new Connection();
            if (kn.moketnoi())
            {
                string sql = "SELECT MaCuDan FROM CuDan";
                SqlDataReader dr = kn.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(dr);
                // thêm dòng đầu
                DataRow r = tb.NewRow();
                r["MaCuDan"] = "-Chọn-";
                tb.Rows.InsertAt(r, 0);
                cbx_cd.DataSource = tb;
                cbx_cd.DisplayMember = "MaCuDan";
                cbx_cd.ValueMember = "MaCuDan";
                cbx_cd.SelectedIndex = 0;
                dr.Close();
                kn.dongketnoi();
            }
        }
        
        void load_dgv()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaYeuCau, MaCuDan, TieuDe FROM CSKH";
                if (cls_chcecklogin.Quyen == 6)
                {
                    sql += " WHERE MaCuDan = N'" + cls_chcecklogin.MaCuDan + "'";
                }
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgv_ttcskh.DataSource = tb;
                ketnoi.dongketnoi();
            }
        }
        void phanquyen_formcon()
        {
            if (cls_chcecklogin.Quyen == 6) 
            {
                cbx_cd.SelectedValue = cls_chcecklogin.MaCuDan;
                cbx_cd.Enabled = false;
                btn_add.Enabled = true;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                rdb_cxl.Enabled = false;
                rdb_dxl.Enabled = false;
                rdb_dht.Enabled = false;
                rdb_tc.Enabled = false;
            }
            else
            {
                cbx_cd.Enabled = true;
                btn_add.Enabled = true;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                rdb_cxl.Enabled = true;
                rdb_dxl.Enabled = true;
                rdb_dht.Enabled = true;
                rdb_tc.Enabled = true;
            }
        }
        string lay_loaiyc()
        {
            if (rdb_kn.Checked) return "Khiếu Nại";
            if (rdb_gopy.Checked) return "Góp Ý";
            if (rdb_ht.Checked) return "Hỗ Trợ";
            if (rdb_pa.Checked) return "Phản Ánh";
            return "";
        }

        string lay_mucdouutien()
        {
            if (rdb_thap.Checked) return "Thấp";
            if (rdb_bth.Checked) return "Bình Thường";
            if (rdb_cao.Checked) return "Cao";
            if (rdb_kc.Checked) return "Khẩn Cấp";
            return "";
        }

        string lay_trangthai()
        {
            if (rdb_cxl.Checked) return "Chờ Xử Lý";
            if (rdb_dxl.Checked) return "Đang Xử Lý";
            if (rdb_dht.Checked) return "Đã Hoàn Tất";
            if (rdb_tc.Checked) return "Từ Chối";
            return "";
        }

        void reset_radio()
        {
            rdb_kn.Checked = false;
            rdb_gopy.Checked = false;
            rdb_ht.Checked = false;
            rdb_pa.Checked = false;
            rdb_thap.Checked = false;
            rdb_bth.Checked = false;
            rdb_cao.Checked = false;
            rdb_kc.Checked = false;
            rdb_cxl.Checked = false;
            rdb_dxl.Checked = false;
            rdb_dht.Checked = false;
            rdb_tc.Checked = false;
        }
        void lammoi()
        {
            IDYC = "";
            txt_myc.Clear();
            txt_td.Clear();
            txt_noidung.Clear();
            reset_radio();
            dtp_ngaygui.Value = DateTime.Now;
            if (cls_chcecklogin.Quyen == 6)
            {
                cbx_cd.SelectedValue = cls_chcecklogin.MaCuDan;
                cbx_cd.Enabled = false;
            }
            else
            {
                cbx_cd.SelectedIndex = 0;
            }
            phanquyen_formcon();
        }
        private void Frm_thongtincskh_Load(object sender, EventArgs e)
        {
            load_macudan();
            dtp_ngaygui.Value = DateTime.Now;
            load_dgv();
            phanquyen_formcon();
        }
        private void dgv_ttcskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv_ttcskh.CurrentRow;
            IDYC = row.Cells["MaYeuCau"].Value.ToString();
            string MaYeuCau = row.Cells["MaYeuCau"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT MaYeuCau, MaCuDan, TieuDe, NoiDung, LoaiYeuCau, MucDoUuTien, NgayGui, TrangThai " +
                                    "FROM CSKH WHERE MaYeuCau = N'" + MaYeuCau + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        txt_myc.Text = rdr["MaYeuCau"].ToString();
                        cbx_cd.Text = rdr["MaCuDan"].ToString();
                        txt_td.Text = rdr["TieuDe"].ToString();
                        txt_noidung.Text = rdr["NoiDung"].ToString();
                        if (rdr["NgayGui"] != DBNull.Value)
                            dtp_ngaygui.Value = Convert.ToDateTime(rdr["NgayGui"]);
                        reset_radio();
                        string loaiyeucau = rdr["LoaiYeuCau"].ToString().Trim();
                        if (loaiyeucau == "Khiếu Nại") rdb_kn.Checked = true;
                        else if (loaiyeucau == "Góp Ý") rdb_gopy.Checked = true;
                        else if (loaiyeucau == "Hỗ Trợ") rdb_ht.Checked = true;
                        else if (loaiyeucau == "Phản Ánh") rdb_pa.Checked = true;
                        string mucdouutien = rdr["MucDoUuTien"].ToString().Trim();
                        if (mucdouutien == "Thấp") rdb_thap.Checked = true;
                        else if (mucdouutien == "Bình Thường") rdb_bth.Checked = true;
                        else if (mucdouutien == "Cao") rdb_cao.Checked = true;
                        else if (mucdouutien == "Khẩn Cấp") rdb_kc.Checked = true;
                        string trangthai = rdr["TrangThai"].ToString().Trim();
                        if (trangthai == "Chờ Xử Lý") rdb_cxl.Checked = true;
                        else if (trangthai == "Đang Xử Lý") rdb_dxl.Checked = true;
                        else if (trangthai == "Đã Hoàn Tất") rdb_dht.Checked = true;
                        else if (trangthai == "Từ Chối") rdb_tc.Checked = true;
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CellClick: " + ex.Message);
            }
            phanquyen_formcon();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool hople = true;

            if (txt_myc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã yêu cầu");
                txt_myc.Focus();
                return;
            }
            if (cls_chcecklogin.Quyen != 6)
            {
                if (cbx_cd.SelectedIndex == 0 || cbx_cd.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng chọn mã cư dân");
                    cbx_cd.Focus();
                    return;
                }
            }
            if (txt_td.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tiêu đề");
                txt_td.Focus();
                return;
            }
            if (txt_noidung.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung");
                txt_noidung.Focus();
                return;
            }
            string loaiyc = lay_loaiyc();
            if (loaiyc == "")
            {
                MessageBox.Show("Vui lòng chọn loại yêu cầu");
                return;
            }
            string mucdo = lay_mucdouutien();
            if (mucdo == "")
            {
                MessageBox.Show("Vui lòng chọn mức độ ưu tiên");
                return;
            }
            string trangthai = lay_trangthai();
            if (trangthai == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }
            string macd = "";
            if (cls_chcecklogin.Quyen == 6)
                macd = cls_chcecklogin.MaCuDan;
            else
                macd = cbx_cd.Text.Trim();
            Connection kn = new Connection();
            try
            {
                if (kn.moketnoi())
                {
                    string check = "SELECT * FROM CSKH WHERE MaYeuCau = N'" + txt_myc.Text.Trim() + "'";
                    SqlDataReader dr = kn.truyvan(check);
                    if (dr.Read())
                    {
                        hople = false;
                        MessageBox.Show("Mã yêu cầu đã tồn tại");
                        txt_myc.Focus();
                    }
                    dr.Close();
                    if (hople)
                    {
                        string ins = "INSERT INTO CSKH(MaYeuCau, MaCuDan, TieuDe, NoiDung, LoaiYeuCau, MucDoUuTien, NgayGui, TrangThai) VALUES(" +
                                     "N'" + txt_myc.Text.Trim() + "'," +
                                     "N'" + cbx_cd.Text.Trim() + "'," +
                                     "N'" + txt_td.Text.Trim() + "'," +
                                     "N'" + txt_noidung.Text.Trim() + "'," +
                                     "N'" + loaiyc + "'," +
                                     "N'" + mucdo + "'," +
                                     "'" + dtp_ngaygui.Value.ToString("yyyy-MM-dd") + "'," +
                                     "N'" + trangthai + "')";
                        int ketqau=kn.capnhat(ins);
                        if (ketqau > 0)
                        {
                            string td = txt_td.Text.Trim().ToLower();
                            if (td.Contains("Sửa Chữa") || td.Contains("Bảo Crì"))
                            {
                                string checkBTSC = "SELECT * FROM BaoTriSuaChua WHERE MaYeuCau = N'" + txt_myc.Text.Trim() + "'";
                                SqlDataReader drBTSC = kn.truyvan(checkBTSC);
                                bool chuaCoBTSC = true;
                                if (drBTSC.Read())
                                {
                                    chuaCoBTSC = false;
                                }
                                drBTSC.Close();
                                if (chuaCoBTSC)
                                {
                                    string insBTSC = "INSERT INTO BaoTriSuaChua(MaYeuCau, NoiDungSuaChua, TrangThai) VALUES(" +
                                                     "N'" + txt_myc.Text.Trim() + "'," +
                                                     "N'" + txt_noidung.Text.Trim() + "'," +
                                                     "N'Chờ Xử Lý')";
                                    kn.capnhat(insBTSC);
                                }
                            }
                            MessageBox.Show("Thêm yêu cầu thành công", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincskh_Load(sender, e);
                            btn_lammoi_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm yêu cầu không thành công", "Hệ Thống Quản Lý Chung Cư - Lỗi Thêm yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                        }
                    }
                    kn.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (IDYC == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần cập nhật");
                return;
            }
            if (txt_myc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã yêu cầu");
                txt_myc.Focus();
                return;
            }
            if (cls_chcecklogin.Quyen != 6)
            {
                if (cbx_cd.SelectedIndex == 0 || cbx_cd.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng chọn mã cư dân");
                    cbx_cd.Focus();
                    return;
                }
            }
            if (txt_td.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tiêu đề");
                txt_td.Focus();
                return;
            }
            if (txt_noidung.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung");
                txt_noidung.Focus();
                return;
            }
            string loaiyc = lay_loaiyc();
            if (loaiyc == "")
            {
                MessageBox.Show("Vui lòng chọn loại yêu cầu");
                return;
            }
            string mucdo = lay_mucdouutien();
            if (mucdo == "")
            {
                MessageBox.Show("Vui lòng chọn mức độ ưu tiên");
                return;
            }
            string trangthai = lay_trangthai();
            if (trangthai == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
                return;
            }
            string macd = "";
            if (cls_chcecklogin.Quyen == 6)
                macd = cls_chcecklogin.MaCuDan;
            else
                macd = cbx_cd.Text.Trim();
            Connection kn = new Connection();
            try
            {
                if (kn.moketnoi())
                {
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        string checkOwner = "SELECT TrangThai, MaCuDan FROM CSKH WHERE MaYeuCau = N'" + IDYC + "'";
                        SqlDataReader drOwner = kn.truyvan(checkOwner);
                        if (drOwner.Read())
                        {
                            string tt = drOwner["TrangThai"].ToString();
                            string macdDB = drOwner["MaCuDan"].ToString();
                            if (macdDB != cls_chcecklogin.MaCuDan)
                            {
                                MessageBox.Show("Bạn không có quyền sửa yêu cầu của người khác");
                                drOwner.Close();
                                kn.dongketnoi();
                                return;
                            }
                            if (tt != "Chờ Xử Lý")
                            {
                                MessageBox.Show("Cư dân chỉ được sửa khi yêu cầu đang Chờ Xử Lý","Hệ Thống Quản Lý Chung Cư - Lỗi Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                drOwner.Close();
                                kn.dongketnoi();
                                return;
                            }
                        }
                        drOwner.Close();
                    }
                    bool hople = true;
                    string check = "SELECT * FROM CSKH WHERE MaYeuCau = N'" + txt_myc.Text.Trim() + "' AND MaYeuCau <> N'" + IDYC + "'";
                    SqlDataReader dr = kn.truyvan(check);
                    if (dr.Read())
                    {
                        hople = false;
                        MessageBox.Show("Mã yêu cầu đã tồn tại");
                        txt_myc.Focus();
                    }
                    dr.Close();
                    if (hople)
                    {
                        string up = "UPDATE CSKH SET " +
                                    "MaYeuCau = N'" + txt_myc.Text.Trim() + "'," +
                                    "MaCuDan = N'" + cbx_cd.Text.Trim() + "'," +
                                    "TieuDe = N'" + txt_td.Text.Trim() + "'," +
                                    "NoiDung = N'" + txt_noidung.Text.Trim() + "'," +
                                    "LoaiYeuCau = N'" + loaiyc + "'," +
                                    "MucDoUuTien = N'" + mucdo + "'," +
                                    "NgayGui = '" + dtp_ngaygui.Value.ToString("yyyy-MM-dd") + "'," +
                                    "TrangThai = N'" + trangthai + "' " +
                                    "WHERE MaYeuCau = N'" + IDYC + "'";
                        int ketqau=kn.capnhat(up);
                        if (ketqau > 0)
                        {
                            string td = txt_td.Text.Trim().ToLower();
                            if (td.Contains("Sửa Chữa") || td.Contains("Bảo Trì"))
                            {
                                string checkBTSC = "SELECT * FROM BaoTriSuaChua WHERE MaYeuCau = N'" + IDYC + "'";
                                SqlDataReader drBTSC = kn.truyvan(checkBTSC);
                                bool daCo = false;
                                if (drBTSC.Read())
                                {
                                    daCo = true;
                                }
                                drBTSC.Close();
                                if (daCo)
                                {
                                    string upBTSC = "UPDATE BaoTriSuaChua SET " +
                                                    "MaYeuCau = N'" + txt_myc.Text.Trim() + "'," +
                                                    "NoiDungSuaChua = N'" + txt_noidung.Text.Trim() + "'," +
                                                    "TrangThai = N'" + trangthai + "' " +
                                                    "WHERE MaYeuCau = N'" + IDYC + "'";
                                    kn.capnhat(upBTSC);
                                }
                                else
                                {
                                    string insBTSC = "INSERT INTO BaoTriSuaChua(MaYeuCau, NoiDungSuaChua, TrangThai) VALUES(" +
                                                     "N'" + txt_myc.Text.Trim() + "'," +
                                                     "N'" + txt_noidung.Text.Trim() + "'," +
                                                     "N'" + trangthai + "')";
                                    kn.capnhat(insBTSC);
                                }
                            }
                            else
                            {
                                string delBTSC = "DELETE FROM BaoTriSuaChua WHERE MaYeuCau = N'" + IDYC + "'";
                                kn.capnhat(delBTSC);
                            }
                            MessageBox.Show("Cập nhật yêu cầu thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_thongtincskh_Load(sender, e);
                            btn_lammoi_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật yêu cầu không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    kn.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (IDYC == "")
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xóa");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.No)
                return;
            Connection kn = new Connection();
            try
            {
                if (kn.moketnoi())
                {
                    if (cls_chcecklogin.Quyen == 6)
                    {
                        string checkOwner = "SELECT TrangThai, MaCuDan FROM CSKH WHERE MaYeuCau = N'" + IDYC + "'";
                        SqlDataReader drOwner = kn.truyvan(checkOwner);
                        if (drOwner.Read())
                        {
                            string tt = drOwner["TrangThai"].ToString();
                            string macdDB = drOwner["MaCuDan"].ToString();
                            if (macdDB != cls_chcecklogin.MaCuDan)
                            {
                                MessageBox.Show("Bạn không có quyền xóa yêu cầu của người khác", "Hệ Thống Quản Lý Chung Cư - Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                drOwner.Close();
                                kn.dongketnoi();
                                return;
                            }
                            if (tt != "Chờ Xử Lý")
                            {
                                MessageBox.Show("Cư dân chỉ được xóa khi yêu cầu đang Chờ Xử Lý", "Hệ Thống Quản Lý Chung Cư - Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                drOwner.Close();
                                kn.dongketnoi();
                                return;
                            }
                        }
                        drOwner.Close();
                    }
                    string delBTSC = "DELETE FROM BaoTriSuaChua WHERE MaYeuCau = N'" + IDYC + "'";
                    kn.capnhat(delBTSC);
                    string delCSKH = "DELETE FROM CSKH WHERE MaYeuCau = N'" + IDYC + "'";
                    int ketqua=kn.capnhat(delCSKH);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Xóa yêu cầu thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_thongtincskh_Load(sender, e);
                        kn.dongketnoi();
                        btn_lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa yêu cầu không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            IDYC = "";
            txt_myc.Clear();
            txt_td.Clear();
            txt_noidung.Clear();
            cbx_cd.SelectedIndex = 0;
            rdb_kn.Checked = false;
            rdb_gopy.Checked = false;
            rdb_ht.Checked = false;
            rdb_pa.Checked = false;
            rdb_thap.Checked = false;
            rdb_bth.Checked = false;
            rdb_cao.Checked = false;
            rdb_kc.Checked = false;
            rdb_cxl.Checked = false;
            rdb_dxl.Checked = false;
            rdb_dht.Checked = false;
            rdb_tc.Checked = false;
            dtp_ngaygui.Value = DateTime.Now;
        }
    }
}
