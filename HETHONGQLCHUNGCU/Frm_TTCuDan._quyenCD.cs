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
    public partial class Frm_TTCuDan : Form
    {
        public Frm_TTCuDan()
        {
            InitializeComponent();
        }

        private void Frm_TTCuDan_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string mcd = cls_chcecklogin.MaCuDan;
                    string sel = "select MaCuDan, HoTen, CCCD, TrangThai from CuDan where macudan ='"+mcd+"'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    dgv_dscc.DataSource = tb;
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
                MessageBox.Show("");
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Frm_CuDan frmCha = this.MdiParent as Frm_CuDan;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }

        private void dgv_dscc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_dscc.CurrentRow;
            string MaTaiKhoan = row.Cells["MaCuDan"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string mcd = cls_chcecklogin.MaCuDan;
                    string selSTr = "SELECT MaCuDan, HoTen, NgaySinh, GioiTinh, CCCD, SoDienThoai, Email, QueQuan, NgheNghiep, TrangThai FROM CuDan WHERE MaCuDan='"+mcd+"'";
                    SqlDataReader rdr = ketnoi.truyvan(selSTr);
                    if (rdr.Read())
                    {
                        txt_cd.Text = rdr["MaCuDan"].ToString();
                        txt_cd1.Text = rdr["HoTen"].ToString();
                        dtp_ngsinh.Value = Convert.ToDateTime(rdr["NgaySinh"].ToString());
                        string gioitinh = rdr["GioiTinh"].ToString().Trim();
                        rdb_nam.Checked = false;
                        rdb_nu.Checked = false;
                        if (rdb_nam.Checked = true)
                        {
                            gioitinh = "0";
                        }
                        else if (rdb_nu.Checked = true)
                        {
                            gioitinh = "1";
                        }
                        txt_madinhdanh.Text = rdr["CCCD"].ToString();
                        txt_emailttcd.Text = rdr["Email"].ToString() ;
                        txt_sdthoai.Text = rdr["SoDienThoai"].ToString();
                        txt_nghenghiep.Text = rdr["NgheNghiep"].ToString();
                        txt_quequan.Text = rdr["QueQuan"].ToString() ;
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
