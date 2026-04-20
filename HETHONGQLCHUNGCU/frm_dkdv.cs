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
    public partial class frm_dkdv : Form
    {
        public frm_dkdv()
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

        private void frm_dkdv_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT * FROM DangKyDichVu";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();               
               dgv_ttdv.DataSource = tb;

                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgv_ttdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_ttdv.CurrentRow;
            string MaDangKy = row.Cells["MaDangKy"].Value.ToString();
            //tao ket noi
            Connection ketnoi = new Connection();
            //moketnoi
            if (ketnoi.moketnoi())
            {
                //truy van 
                string selStr = "SELECT MaDangKy, MaCanHo, MaDichVu, NgayDangKy,SoLuong,TrangThai,GhiChu FROM DangKyDichVu WHERE MaDangKy = '" + MaDangKy + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {

                    txt_mdk.Text = rdr["MaDangKy"].ToString();
                    txt_mch.Text = rdr["MaCanHo"].ToString();
                    txt_mdv.Text = rdr["MaDichVu"].ToString();
                    dtp_ndk.Value = Convert.ToDateTime(rdr["NgayDangKy"].ToString());
                    txt_sl.Text = rdr["SoLuong"].ToString();
                    txt_gc.Text = rdr["GhiChu"].ToString();
                    txt_tt.Text = rdr["TrangThai"].ToString();
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                bool hopLe = true;
                ///b3. cập nhật
                ///b3.1 validation
                string selStr = "SELECT MaDangKy FROM DangKyDichVu WHERE MaDangKy='" + txt_mdk.Text + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {
                    MessageBox.Show("Mã đăng ký đã tồn tại");


                }
                rdr.Close();
                ///b3.2 cập nhật - Insert

                string ins = "INSERT INTO BaoTriSuaChua (MaDangKy,MaCanHo,MaDichVu,NgayDangKy,TrangThai,SoLuong,GhiChu) " +
                                  "VALUES('" + txt_mdk.Text + "'," +
                                  "N'" + txt_mch.Text + "'," +
                                  "'" + txt_mdv.Text + "'," +
                                  dtp_ndk.Value.ToString("yyyy-MM-dd") + "," +
                                  "'" + txt_tt.Text + "'," +
                                  "'" + txt_sl.Text + "'," +
                                  "N'" + txt_gc.Text + "',";
                int kq = ketnoi.capnhat(ins);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm Mã Bảo Trì Thành Công ");
                }
                else
                {
                    MessageBox.Show("Thêm Mã Bảo Trì Không Thành Công ");
                }
            }
            ketnoi.dongketnoi();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();

            //mở kết nối
            if (ketnoi.moketnoi())
            {
                bool hople = true;

                //cập nhật - UPDATE
                //validation
                string sel = "SELECT MaDangKy FROM DangKyDichVu " +
                             "WHERE MaDangKy='" + txt_mdk.Text + "'";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                if (rdr.Read())
                {
                    hople = false;
                    MessageBox.Show("Mã bảo trì đã tồn tại");
                }
                rdr.Close();
                string updStr = "UPDATE DangKyDichVu SET " +
                       "MaCanHo = N'" + txt_mch.Text + "', " +
                       "MaDangky = '" + txt_mdk.Text + "', " +
                       "MsDichVu = N'" + txt_mdv.Text + "', " +
                       "TrangThai = N'" + txt_tt.Text + "', " +
                       "SoLuong = N'" + txt_sl.Text + "', " +
                       "NgayDangKy = '" + dtp_ndk.Value.ToString("yyyy-MM-dd") + "', " +
                       "GhiChu = N'" + txt_gc.Text + "', ";
                int kq = ketnoi.capnhat(updStr);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công thông tin dịch vụ ");

                }
                else
                {
                    MessageBox.Show("không thể chỉnh sửa thông tin dịch vụ");
                }
                //dong ket noi
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Không thể kết nối csdl!!");
            }
        
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn muốn xóa mã đăng ký với thông tin sau:" +
                                           "\n\tMaDangKy: " + txt_mdk.Text +
                                           "\n\tMaCanHo: " + txt_mch.Text, "Xóa thanh toán",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Connection ketnoi = new Connection();
                //moketnoi
                if (ketnoi.moketnoi())
                {

                    string delStr = "DELETE FROM DangKyDichVu WHERE MaDangKy='" + txt_mdk.Text + "'";
                    int kq = ketnoi.capnhat(delStr);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thông tin đăng ký có mã căn hộ là: " + txt_mdk.Text + " Thành công!");

                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin đăng ký có mã căn hộ là: " + txt_mdk.Text + " Không thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("500! - Không thể kết nối CSDL");
                }
            }
            else
            {
                return;
            }
        }
    }
}
