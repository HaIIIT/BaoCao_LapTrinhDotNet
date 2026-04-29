using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TTHD_CUDAN : Form
    {
        string maHD = "";
        string maCH = "";
        decimal soTien = 0;
        public Frm_TTHD_CUDAN()
        {
            InitializeComponent();
        }
        private void Frm_TTHD_CUDAN_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            //mở kết nối
            try
            {
                if (ketnoi.moketnoi())
                {
                    string maCuDan = cls_chcecklogin.MaCuDan;
                    string sel = "SELECT hd.MaHoaDon, hd.MaCanHo, hd.MaCTHD " +
                                 "FROM HoaDon hd " +
                                 "INNER JOIN HopDong h ON hd.MaCanHo = h.MaCanHo " +
                                 "WHERE h.MaCuDan = N'" + maCuDan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSHD.DataSource = tb;
                    //đóng kết nối
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Khong the ket noi CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Frm_HoaDon frmCha = this.MdiParent as Frm_HoaDon;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDSHD.CurrentRow == null) return;

            DataGridViewRow row = dgvDSHD.CurrentRow;
            if (row.Cells["MaHoaDon"].Value == null) return;

            string MaHoaDon = row.Cells["MaHoaDon"].Value.ToString();

            Connection ketnoi = new Connection();

            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM HoaDon WHERE MaHoaDon = N'" + MaHoaDon + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);    
                    if (rdr.Read())
                    {
                        maHD = rdr["MaHoaDon"].ToString();
                        maCH = rdr["MaCanHo"].ToString();
                        if (rdr["TongTien"] != DBNull.Value)
                            soTien = Convert.ToDecimal(rdr["TongTien"]);
                        else
                            soTien = 0;
                        txt_mhd.Text = rdr["MaHoaDon"].ToString();
                        txt_mch.Text = rdr["MaCanHo"].ToString();
                        txt_mcthd.Text = rdr["MaCTHD"].ToString();
                        txt_thang.Text = rdr["Thang"].ToString();
                        txt_nam.Text = rdr["Nam"].ToString();
                        if (rdr["NgayLap"] != DBNull.Value)
                            txt_ngaylap.Text = Convert.ToDateTime(rdr["NgayLap"]).ToString("dd/MM/yyyy");
                        if (rdr["HanThanhToan"] != DBNull.Value)
                            txt_hanthanhtoan.Text = Convert.ToDateTime(rdr["HanThanhToan"]).ToString("dd/MM/yyyy");
                        txt_tongtien.Text = soTien.ToString("#,##0", new System.Globalization.CultureInfo("vi-VN"));
                        string trangthai = rdr["TrangThai"].ToString().Trim();
                        if (trangthai == "Đã Thanh Toán")
                        {
                            rdb_dtt.Checked = true;
                            btn_thanhtoan.Visible = false;
                        }
                        else if (trangthai == "Chưa Thanh Toán")
                        {
                            rdb_chuatt.Checked = true;
                            btn_thanhtoan.Visible = true;
                        }
                        else
                        {
                            rdb_cxl.Checked = true;
                            btn_thanhtoan.Visible = false;
                        }
                        txt_ghichu.Text = rdr["GhiChu"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (maHD == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán!");
                return;
            }

            Frm_TTThanhToan_CuDan frm =
                new Frm_TTThanhToan_CuDan(maHD, "", maCH, soTien);

            frm.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
