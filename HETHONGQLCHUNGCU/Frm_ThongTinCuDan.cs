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
    public partial class Frm_ThongTinCuDan : Form
    {
        string IDCD = "";
        public Frm_ThongTinCuDan()
        {
            InitializeComponent();
        }
        public void settrangthaibutton(bool them, bool  sua, bool xoa)
        {
            btn_add.Enabled = them;
            btn_update.Enabled = sua;
            btn_delete.Enabled = xoa;
        }
        private void lbl_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_ThongTinCuDan_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if(ketnoi.moketnoi())
                {
                    string sql = "SELECT MaCuDan, HoTen, TrangThai FROM CuDan";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    rdr.Close();
                    dgv_dscudan.DataSource = dt;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_dscudan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_dscudan.CurrentRow;
            string MaCuDan = row.Cells["MaCuDan"].Value.ToString();
            IDCD = row.Cells["MaCuDan"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CuDan WHERE MaCuDan = '" + MaCuDan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mcd.Text = rdr["MaCuDan"].ToString();
                        txt_hoten.Text = rdr["HoTen"].ToString();                       
                        dtp_ngaysinh.Value = Convert.ToDateTime(rdr["NgaySinh"].ToString());
                        string gioiTinh = rdr["GioiTinh"].ToString().Trim();
                        rdb_nam.Checked = false;
                        rdb_nu.Checked = false;
                        if (gioiTinh == "0")
                        {
                            rdb_nam.Checked = true;
                        }
                        else if (gioiTinh == "1")
                        {
                            rdb_nu.Checked = true;
                        }
                        txt_cccd.Text = rdr["CCCD"].ToString();
                        txt_sdt.Text = rdr["SoDienThoai"].ToString();
                        txt_email.Text = rdr["Email"].ToString();
                        txt_quequan.Text = rdr["QueQuan"].ToString();
                        txt_nghenghiep.Text = rdr["NgheNghiep"].ToString();                       
                        if (rdr["TrangThai"].ToString() == "Cư Trú")
                        {
                            rdb_cutru.Checked = true;
                        }
                        else if (rdr["TrangThai"].ToString() == "Tạm Vắng")
                        {
                            rdb_tamvang.Checked = true;
                        }
                        else if (rdr["TrangThai"].ToString() == "Tạm Trú")
                        {
                            rdb_tamtru.Checked = true;
                        }
                        rdr.Close();
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            txt_mcd.Clear();
            txt_hoten.Clear();
            dtp_ngaysinh.Value = DateTime.Now;
            rdb_nam.Checked = false;
            rdb_nu.Checked = false;
            txt_cccd.Clear();
            txt_sdt.Clear();
            txt_email.Clear();
            txt_quequan.Clear();
            txt_nghenghiep.Clear();
            rdb_cutru.Checked = false;
            rdb_tamtru.Checked = false;
            rdb_tamvang.Checked = false;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hole = true;
                    string sel ="SELECT MaCuDan FROM CuDan WHERE MaCuDan ='"+txt_mcd.Text.Trim()+"'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read()) {
                        MessageBox.Show("MÃ Cư Dân Này Đã Tồn Tại!", "Hệ Thống Quản Lý Chung Cư - Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hole = false;
                    }
                    rdr.Close();
                    if (hole)
                    {
                        string sql = "INSERT INTO CuDan (MaCuDan, HoTen, NgaySinh, GioiTinh, CCCD, SoDienThoai, Email, QueQuan, NgheNghiep, TrangThai) VALUES (@MaCuDan, @HoTen, @NgaySinh, @GioiTinh, @CCCD, @SoDienThoai, @Email, @QueQuan, @NgheNghiep, @TrangThai)";
                        SqlCommand cmd = ketnoi.TaoLenh(sql);
                        cmd.Parameters.AddWithValue("@MaCuDan", txt_mcd.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txt_hoten.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh.Value);
                        string gioiTinh = rdb_nam.Checked ? "0" : rdb_nu.Checked ? "1" : "";
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", txt_cccd.Text);
                        cmd.Parameters.AddWithValue("@SoDienThoai", txt_sdt.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@QueQuan", txt_quequan.Text);
                        cmd.Parameters.AddWithValue("@NgheNghiep", txt_nghenghiep.Text);
                        string trangThai = rdb_cutru.Checked ? "Cư Trú" : rdb_tamvang.Checked ? "Tạm Vắng" : rdb_tamtru.Checked ? "Tạm Trú" : "";
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        int ketqua = cmd.ExecuteNonQuery();
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Thêm cư dân thành công!", "Hệ Thống Quản Lý Chung Cư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_ThongTinCuDan_Load(sender, e); // Tải lại dữ liệu sau khi thêm
                        }
                        else
                        {
                            MessageBox.Show("Thêm cư dân thất bại!", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ketnoi.dongketnoi();
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
        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    bool hople = true;
                    string sel = "SELECT MaCuDan FROM CuDan WHERE MaCuDan='" + txt_mcd.Text.Trim() + "' AND MaCuDan<>'" + IDCD + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        MessageBox.Show("Mã CuDan đã tồn tại. Vui lòng chọn mã khác.", "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hople = false;
                    }
                    rdr.Close();                    
                    if (hople)
                    {
                        int gioitinh = 0;
                        if (rdb_nam.Checked)
                            gioitinh = 0;
                        else if (rdb_nu.Checked)
                            gioitinh = 1;
                        string trangthai = "";
                        if (rdb_cutru.Checked)
                            trangthai = "Cư Trú";
                        else if (rdb_tamtru.Checked)
                            trangthai = "Tạm Trú";
                        else if (rdb_tamvang.Checked)
                            trangthai = "Tạm Vắng";
                        string upStr = @"UPDATE CuDan SET
                                    MaCuDan=@MaCuDan,
                                    HoTen=@HoTen,
                                    NgaySinh=@NgaySinh,
                                    GioiTinh=@GioiTinh,
                                    SoDienThoai=@SDT,
                                    Email=@Email,
                                    CCCD=@CCCD,
                                    QueQuan=@QueQuan,
                                    NgheNghiep=@NgheNghiep,
                                    TrangThai=@TrangThai 
                                    WHERE MaCuDan =@MaCuDan";
                        SqlCommand cmd = new SqlCommand(upStr, ketnoi.conn);
                        cmd.Parameters.AddWithValue("@MaCuDan", txt_mcd.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txt_hoten.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtp_ngaysinh.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                        cmd.Parameters.AddWithValue("@CCCD", txt_cccd.Text);
                        cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@QueQuan", txt_quequan.Text);
                        cmd.Parameters.AddWithValue("@NgheNghiep", txt_nghenghiep.Text);
                        cmd.Parameters.AddWithValue("@MaCuDanCu", IDCD);
                        cmd.Parameters.AddWithValue("@TrangThai", trangthai);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập Nhật Thông Tin Thành Công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IDCD = txt_mcd.Text;
                        Frm_ThongTinCuDan_Load(sender, e);
                    }
                    ketnoi.dongketnoi();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn Có Chắc Muốn Xóa Thông Tin Cư Dân:"
                + "\n" + txt_mcd.Text
                + "\n" + txt_hoten.Text, "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rs == DialogResult.Yes) 
            { 
                Connection ketnoi = new Connection();
                try
                {
                    if (ketnoi.moketnoi())
                    {
                        string deltk = "DELETE FROM TaiKhoanNguoiDung WHERE MaCuDan ='" + txt_mcd.Text.Trim() + "'";
                        string delStr="DELETE FROM CuDan WHERE MaCuDan ='"+txt_mcd.Text.Trim()+"'";
                        ketnoi.capnhat(deltk);
                        int ketqua = ketnoi.capnhat(delStr);
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Xóa Thông Tin Cư Dân Có Mã Số:"+txt_mcd.Text.Trim()+" Thành Công!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Frm_ThongTinCuDan_Load(sender, e);
                            btn_load_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thông Tin Cư Dân Có Mã Số:" + txt_mcd.Text.Trim() + " Thất Bại!",
                                "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ketnoi.dongketnoi();
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Kết Nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
