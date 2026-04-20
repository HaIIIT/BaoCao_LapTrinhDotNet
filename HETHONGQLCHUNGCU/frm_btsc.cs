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
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_btsc_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            //mở kết nối
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT * FROM BaoTriSuaChua";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                
                dgv_ttbt.DataSource = tb;

                //đóng kết nối
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }

        private void dgv_ttbt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_ttbt.CurrentRow;
            string MaBaoTri = row.Cells["MaBaoTri"].Value.ToString();
            //tao ket noi
            Connection ketnoi = new Connection();
            //moketnoi
            if (ketnoi.moketnoi())
            {
                //truy van 
                string selStr = "SELECT MaBaoTri, MaCanHo, MaYeuCau, TieuDe, LoaiBaoTri,TrangThai,MoTa,NgayYeuCau,NgayBatDau,NgayKetThuc,ChiPhi,GhiChu FROM BaoTriSuaChua WHERE MaBaoTri = '" + MaBaoTri + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {

                    txt_mbt.Text = rdr["MaBaoTri"].ToString();
                    txt_mch.Text = rdr["MaCanHo"].ToString();
                    txt_myc.Text = rdr["MaYeuCau"].ToString();
                    txt_td.Text = rdr["TieuDe"].ToString();
                    txt_mt.Text = rdr["MoTa"].ToString();
                    txt_gc.Text = rdr["GhiChu"].ToString();
                    txt_lbt.Text = rdr["LoaiBaoTri"].ToString();
                    txt_tt.Text = rdr["TrangThai"].ToString();
                    dtp_nyc.Value = Convert.ToDateTime(rdr["ngayyeucau"].ToString());
                    dtp_nbd.Value = Convert.ToDateTime(rdr["ngaybatdau"].ToString());
                    dtp_nkt.Value = Convert.ToDateTime(rdr["ngayketthuc"].ToString());
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
                string selStr = "SELECT MaBaoTri FROM BaoTriSuaChua WHERE MaThanhToan='" + txt_mbt.Text + "'";
                SqlDataReader rdr = ketnoi.truyvan(selStr);
                if (rdr.Read())
                {
                    MessageBox.Show("Mã bảo trì đã tồn tại");


                }
                rdr.Close();
                ///b3.2 cập nhật - Insert

                string ins = "INSERT INTO BaoTriSuaChua (MaBaoTri, MaCanHo,MaYeuCau,TieuDe,LoaiBaoTri,TrangThai,MoTa,NgayYeuCau,NgayBatDau,NgayKetThuc,ChiPhi,GhiChu) " +
                                  "VALUES('" + txt_mbt.Text + "'," +
                                  "N'" + txt_mch.Text + "'," +
                                  "'" + txt_myc.Text + "'," +
                                  txt_td + "," +
                                  "'" + txt_mt.Text + "'," +
                                  "N'" + txt_cp.Text + "'," +
                                  "N'" + txt_gc.Text + "'," +
                                   "'" + txt_lbt.Text + "'," +
                                  "N'" + txt_tt.Text + "'," +
                                  "'" + dtp_nyc.Value.ToString("yyyy-MM-dd") + "'," +
                                  "'" + dtp_nbd.Value.ToString("yyyy-MM-dd") + "'," +
                                  "'" + dtp_nkt.Value.ToString("yyyy-MM-dd") + "',";                                    
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
                string sel = "SELECT MaBaoTri FROM BaoTriSuaChua " +
                             "WHERE MaBaoTri='" + txt_mbt.Text + "'";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                if (rdr.Read())
                {
                    hople = false;
                    MessageBox.Show("Mã bảo trì đã tồn tại");
                }
                rdr.Close();
                string updStr = "UPDATE BaoTriSuaChua SET " +
                       "MaCanHo = N'" + txt_mch.Text + "', " +
                       "MaYeuCau = '" + txt_myc.Text + "', " +
                       "TieuDe = N'" + txt_td.Text + "', " +
                       "LoaiBaoTri = N'" + txt_lbt.Text + "', " +
                       "TrangThai = N'" + txt_tt.Text + "', " +
                       "MoTa = N'" + txt_mt.Text + "', " +
                       "ChiPhi = '" + txt_cp.Text + "', " +
                       "GhiChu = N'" + txt_gc.Text + "', " +
                       "NgayYeuCau = '" + dtp_nyc.Value.ToString("yyyy-MM-dd") + "', " +
                       "NgayBatDau = '" + dtp_nbd.Value.ToString("yyyy-MM-dd") + "', " +
                       "NgayKetThuc = '" + dtp_nkt.Value.ToString("yyyy-MM-dd") + "' " +
                       "WHERE MaBaoTri = '" + txt_mbt.Text + "'";
                int kq = ketnoi.capnhat(updStr);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công thông tin bảo trì");

                }
                else
                {
                    MessageBox.Show("không thể chỉnh sửa thông tin bảo trì");
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
            DialogResult rs = MessageBox.Show("Bạn muốn xóa mã bảo trì với thông tin sau:" +
                                            "\n\tMaBaoTri: " + txt_mbt.Text +
                                            "\n\tMaCanHo: " + txt_mch.Text, "Xóa thanh toán",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Connection ketnoi = new Connection();
                //moketnoi
                if (ketnoi.moketnoi())
                {

                    string delStr = "DELETE FROM BaoTriSuaChua WHERE MaBaoTri='" + txt_mbt.Text + "'";
                    int kq = ketnoi.capnhat(delStr);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thông tin bảo trì có mã căn hộ là: " + txt_mbt.Text + " Thành công!");

                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin bảo trì có mã căn hộ là: " + txt_mbt.Text + " Không thành công!");
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