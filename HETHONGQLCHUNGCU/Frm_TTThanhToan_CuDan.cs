using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TTThanhToan_CuDan : Form
    {
        public Frm_TTThanhToan_CuDan()
        {
            InitializeComponent();
        }
        string maHD = "";
        string maCN = "";
        string maCH = "";
        decimal soTien = 0;

        public Frm_TTThanhToan_CuDan(string _maHD, string _maCN, string _maCH, decimal _soTien)
        {
            InitializeComponent();
            maHD = _maHD;
            maCN = _maCN;
            maCH = _maCH;
            soTien = _soTien;
        }
        void LoadThangThanhToan()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT DISTINCT 
                           RIGHT('0' + CAST(MONTH(NgayThanhToan) AS VARCHAR(2)), 2) + '/' + 
                           CAST(YEAR(NgayThanhToan) AS VARCHAR(4)) AS ThangTT
                           FROM ThanhToan
                           WHERE NgayThanhToan IS NOT NULL
                           ORDER BY ThangTT";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["ThangTT"] = "-Click-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_thangtt.DataSource = tb;
                    cbx_thangtt.DisplayMember = "ThangTT";
                    cbx_thangtt.ValueMember = "ThangTT";
                    cbx_thangtt.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load tháng thanh toán: " + ex.Message);
            }
        }
        void LoadMaHoaDonTraCuu()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT DISTINCT MaHoaDon
                           FROM ThanhToan
                           WHERE MaHoaDon IS NOT NULL";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaHoaDon"] = "-Click-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_mahd_tracuu.DataSource = tb;
                    cbx_mahd_tracuu.DisplayMember = "MaHoaDon";
                    cbx_mahd_tracuu.ValueMember = "MaHoaDon";
                    cbx_mahd_tracuu.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load mã hóa đơn: " + ex.Message);
            }
        }
        void LoadMaCongNoTraCuu()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT DISTINCT MaCongNo
                           FROM ThanhToan
                           WHERE MaCongNo IS NOT NULL";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    DataRow r = tb.NewRow();
                    r["MaCongNo"] = "-Click-";
                    tb.Rows.InsertAt(r, 0);
                    cbx_macn_tracuu.DataSource = tb;
                    cbx_macn_tracuu.DisplayMember = "MaCongNo";
                    cbx_macn_tracuu.ValueMember = "MaCongNo";
                    cbx_macn_tracuu.SelectedIndex = 0;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load mã công nợ: " + ex.Message);
            }
        }
        void LoadThanhToanTheoCuDan()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string maCuDan = cls_chcecklogin.MaCuDan;
                    string sql = @"SELECT tt.MaThanhToan, tt.MaHoaDon, tt.MaCongNo, tt.MaCanHo,
                                    tt.SoTien, tt.NoiDung, tt.TrangThai
                                    FROM ThanhToan tt
                                    INNER JOIN HopDong hd ON tt.MaCanHo = hd.MaCanHo
                                    WHERE hd.MaCuDan = N'" + maCuDan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dstt.DataSource = tb;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thanh toán theo cư dân: " + ex.Message);
            }
        }
        void TraCuuThanhToan()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaThanhToan, MaHoaDon, MaCongNo, MaCanHo,
                            SoTien, NoiDung, TrangThai, NgayThanhToan
                            FROM ThanhToan
                            WHERE 1=1";
                    if (cbx_thangtt.SelectedValue != null)
                    {
                        string thangNam = cbx_thangtt.SelectedValue.ToString().Trim();
                        if (thangNam != "" && thangNam != "-Click-")
                        {
                            string[] tach = thangNam.Split('/');
                            if (tach.Length == 2)
                            {
                                string thang = tach[0];
                                string nam = tach[1];
                                sql += " AND MONTH(NgayThanhToan) = " + int.Parse(thang);
                                sql += " AND YEAR(NgayThanhToan) = " + int.Parse(nam);
                            }
                        }
                    }
                    if (cbx_mahd_tracuu.SelectedValue != null)
                    {
                        string maHD = cbx_mahd_tracuu.SelectedValue.ToString().Trim();
                        if (maHD != "" && maHD != "-Click-")
                        {
                            sql += " AND MaHoaDon = N'" + maHD + "'";
                        }
                    }
                    if (cbx_macn_tracuu.SelectedValue != null)
                    {
                        string maCN = cbx_macn_tracuu.SelectedValue.ToString().Trim();
                        if (maCN != "" && maCN != "-Click-")
                        {
                            sql += " AND MaCongNo = N'" + maCN + "'";
                        }
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dstt.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu thanh toán: " + ex.Message);
            }
        }
        private void Frm_TTThanhToan_CuDan_Load(object sender, EventArgs e)
        {
            LoadThanhToanTheoCuDan();
            LoadThangThanhToan();
            LoadMaHoaDonTraCuu();
            LoadMaCongNoTraCuu();
            TraCuuThanhToan();
        }
        private void dgv_dstt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_dstt.CurrentRow == null)
                return;
            DataGridViewRow row = dgv_dstt.CurrentRow;
            if (row.Cells["MaThanhToan"].Value == null)
                return;
            string maThanhToan = row.Cells["MaThanhToan"].Value.ToString();
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = @"SELECT MaThanhToan, MaHoaDon, MaCongNo, MaCanHo,
                                  SoTien, NoiDung, TrangThai
                           FROM ThanhToan
                           WHERE MaThanhToan = N'" + maThanhToan + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sql);
                    if (rdr.Read())
                    {
                        // gán biến
                        maHD = rdr["MaHoaDon"] == DBNull.Value ? "" : rdr["MaHoaDon"].ToString();
                        maCN = rdr["MaCongNo"] == DBNull.Value ? "" : rdr["MaCongNo"].ToString();
                        maCH = rdr["MaCanHo"] == DBNull.Value ? "" : rdr["MaCanHo"].ToString();
                        decimal tien = 0;
                        if (decimal.TryParse(rdr["SoTien"].ToString(), out tien))
                            soTien = tien;
                        // đổ lên UI
                        txt_mtt.Text = rdr["MaThanhToan"].ToString();
                        txt_sotien.Text = soTien.ToString("N0", new CultureInfo("vi-VN")) + " đ";
                        txt_tt.Text = rdr["TrangThai"].ToString();
                        txt_nd.Text = rdr["NoiDung"].ToString();
                        // xử lý nút
                        if (txt_tt.Text.Trim() == "Đã Thanh Toán")
                            btn_thanhtoan.Visible = false;
                        else
                            btn_thanhtoan.Visible = true;
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
        bool dangLoc = false;
        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (!dangLoc)
            {
                TraCuuThanhToan();
                btn_tracuu.Text = "Load";
                dangLoc = true;
            }
            else
            {
                cbx_thangtt.SelectedIndex = 0;
                cbx_mahd_tracuu.SelectedIndex = 0;
                cbx_macn_tracuu.SelectedIndex = 0;
                Frm_TTThanhToan_CuDan_Load(sender, e);
                btn_tracuu.Text = "Tra Cứu";
                dangLoc = false;
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Frm_TT frmCha = this.MdiParent as Frm_TT;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (maHD == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần thanh toán!");
                return;
            }
            if (soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            Frm_HeThongThanhToan frm =
                new Frm_HeThongThanhToan(maHD, maCN, maCH, soTien);
            frm.ShowDialog();
            LoadThanhToanTheoCuDan();
        }
    }
}
