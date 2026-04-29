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
    public partial class Frm_CCcs : Form
    {
        string IDCC = "";
        public Frm_CCcs()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        void load_cbx_mns()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaNhanSu FROM NhanSu";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                DataRow row = tb.NewRow();
                row["MaNhanSu"] = "-Click-";
                tb.Rows.InsertAt(row, 0);
                cbx_mns.DataSource = tb;
                cbx_mns.DisplayMember = "MaNhanSu";
                cbx_mns.ValueMember = "MaNhanSu";
                rdr.Close();
                ketnoi.dongketnoi();
            }
        }
        void load_dgv()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaChamCong,  MaNhanSu, NgayCham , TrangThai FROM ChamCong";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgvDSCC.DataSource = tb;
                ketnoi.dongketnoi();
            }
        }
        private void Frm_CCcs_Load(object sender, EventArgs e)
        {
            load_cbx_mns();
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaChamCong, MaNhanSu, NgayCham, TrangThai FROM ChamCong";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgvDSCC.DataSource = tb;
                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgvDSCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDSCC.CurrentRow == null)
                return;
            DataGridViewRow row = dgvDSCC.CurrentRow;
            IDCC = row.Cells["MaChamCong"].Value.ToString();
            string maChamCong = dgvDSCC.CurrentRow.Cells["MaChamCong"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM ChamCong WHERE MaChamCong = N'" + maChamCong + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        cbx_mns.SelectedValue = rdr["MaNhanSu"].ToString();
                        if (rdr["NgayCham"] != DBNull.Value)
                            dtp_nc.Value = Convert.ToDateTime(rdr["NgayCham"]);
                        if (rdr["GioVao"] != DBNull.Value)
                            txt_gv.Text = ((TimeSpan)rdr["GioVao"]).ToString(@"hh\:mm\:ss");
                        else
                            txt_gv.Text = "";
                        if (rdr["GioRa"] != DBNull.Value)
                            txt_gr.Text = ((TimeSpan)rdr["GioRa"]).ToString(@"hh\:mm\:ss");
                        else
                            txt_gr.Text = "";
                        txt_tt.Text = rdr["TrangThai"].ToString();
                        txt_sgl.Text = rdr["SoGioLam"].ToString();
                        txt_gc.Text = rdr["GhiChu"].ToString();
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
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {           
            cbx_mns.SelectedIndex = 0;
            dtp_nc.Value = DateTime.Now;
            txt_gv.Text = "";
            txt_gr.Text = "";
            txt_tt.Text = "";
            txt_sgl.Text = "";
            txt_gc.Text = "";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string gv = string.IsNullOrEmpty(txt_gv.Text) ? "NULL" : "'" + txt_gv.Text + "'";
                    string gr = string.IsNullOrEmpty(txt_gr.Text) ? "NULL" : "'" + txt_gr.Text + "'";
                    string sgl = string.IsNullOrEmpty(txt_sgl.Text) ? "NULL" : "'" + txt_sgl.Text + "'";
                    string sql = "INSERT INTO ChamCong (MaNhanSu, NgayCham, GioVao, GioRa, TrangThai, SoGioLam, GhiChu) VALUES (" +
                                 "N'" + cbx_mns.SelectedValue + "'," +
                                 "'" + dtp_nc.Value.ToString("yyyy-MM-dd") + "'," +
                                 gv + "," +
                                 gr + "," +
                                 "N'" + txt_tt.Text + "'," +
                                 sgl + "," +
                                 "N'" + txt_gc.Text + "')";
                    int ketqua = ketnoi.capnhat(sql);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Thêm chấm công thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_dgv();
                        btn_Lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm chấm công không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (IDCC == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string gv = string.IsNullOrEmpty(txt_gv.Text) ? "NULL" : "'" + txt_gv.Text.Trim() + "'";
                    string gr = string.IsNullOrEmpty(txt_gr.Text) ? "NULL" : "'" + txt_gr.Text.Trim() + "'";
                    string sgl = string.IsNullOrEmpty(txt_sgl.Text) ? "NULL" : "'" + txt_sgl.Text.Trim() + "'";
                    string sql = "UPDATE ChamCong SET " +
                                 "MaNhanSu = N'" + cbx_mns.SelectedValue.ToString().Trim() + "', " +
                                 "NgayCham = '" + dtp_nc.Value.ToString("yyyy-MM-dd") + "', " +
                                 "GioVao = " + gv + ", " +
                                 "GioRa = " + gr + ", " +
                                 "TrangThai = N'" + txt_tt.Text.Trim() + "', " +
                                 "SoGioLam = " + sgl + ", " +
                                 "GhiChu = N'" + txt_gc.Text.Trim() + "' " +
                                 "WHERE MaChamCong = " + IDCC;
                    int ketqua = ketnoi.capnhat(sql);
                    if(ketqua > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_dgv();
                        btn_Lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công", "Hệ Thống Quản Lý Chung Cư - Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (IDCC == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
                return;
            }
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.No)
                return;
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "DELETE FROM ChamCong WHERE MaChamCong = " + IDCC;
                    int ketqua = ketnoi.capnhat(sql);
                    if (ketqua > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_dgv();
                        btn_Lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Hệ Thống Quản Lý Chung Cư - Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
