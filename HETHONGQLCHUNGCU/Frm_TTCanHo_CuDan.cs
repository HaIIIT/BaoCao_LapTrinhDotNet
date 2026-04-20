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
    public partial class Frm_TTCanHo_CuDan : Form
    {
        public Frm_TTCanHo_CuDan()
        {
            InitializeComponent();
        }

        private void Frm_TTCanHo_CuDan_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string macd = cls_chcecklogin.MaCuDan;
                    string selStr = "SELECT DISTINCT ch.MaCanHo, ch.SoCan, ch.Tang, ch.TrangThai, ch.DienTich, ch.SoPhongNgu, ch.GhiChu " +
                                    "FROM CanHo ch " +
                                    "INNER JOIN HopDong hd ON ch.MaCanHo = hd.MaCanHo " +
                                    "WHERE hd.MaCuDan = '" + macd + "'";
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_thongtincanho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_thongtincanho.CurrentRow;
            string MaCanHo = row.Cells["MaCanHo"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string selStr = "SELECT * FROM CanHo WHERE MaCanHo = '" + MaCanHo + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        txt_mach.Text = rdr["MaCanHo"].ToString();
                        txt_socan.Text = rdr["SoCan"].ToString();
                        decimal dientich = 0;
                        decimal.TryParse(rdr["DienTich"].ToString(), out dientich);
                        upd_diemtich.Value = dientich;
                        decimal sophongngu = 0;
                        decimal.TryParse(rdr["SoPhongNgu"].ToString(), out sophongngu);
                        upd_phongngu.Value = sophongngu;
                        string noithat = rdr["NoiThat"].ToString().Trim();
                        rdb_co.Checked = false;
                        rdb_khong.Checked = false;
                        if (noithat == "0")
                        {
                            rdb_khong.Checked = true;
                        }
                        else if (noithat == "1")
                        {
                            rdb_co.Checked = true;
                        }
                        txt_sotang.Text = rdr["Tang"].ToString();
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
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
    }
}
