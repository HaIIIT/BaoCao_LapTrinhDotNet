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
using System.Windows.Forms.DataVisualization.Charting;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_ThongKeTaiChinh : Form
    {
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        public Frm_ThongKeTaiChinh()
        {
            InitializeComponent();
        }
        public Frm_ThongKeTaiChinh(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        double LayTongTien(string sql, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            object kq = cmd.ExecuteScalar();
            return (kq != null && kq != DBNull.Value) ? Convert.ToDouble(kq) : 0;
        }
        void VeBieuDoTaiChinh()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                try
                {
                    int thangNay = DateTime.Now.Month;
                    int namNay = DateTime.Now.Year;
                    DateTime thangTruocDate = DateTime.Now.AddMonths(-1);
                    int thangTruoc = thangTruocDate.Month;
                    int namThangTruoc = thangTruocDate.Year;
                    // Tổng thu trong tháng này
                    string sqlThangNay = "SELECT SUM(TongTien) FROM HoaDon " +
                                         "WHERE TrangThai = N'Đã Thanh Toán' " +
                                         "AND Thang = " + thangNay + " AND Nam = " + namNay;
                    // Tổng thu tháng trước
                    string sqlThangTruoc = "SELECT SUM(TongTien) FROM HoaDon " +
                                           "WHERE TrangThai = N'Đã Thanh Toán' " +
                                           "AND Thang = " + thangTruoc + " AND Nam = " + namThangTruoc;
                    // Đã thu
                    string sqlDaThu = "SELECT SUM(TongTien) FROM HoaDon " +
                                      "WHERE TrangThai = N'Đã Thanh Toán'";
                    // Công nợ chưa thanh toán
                    string sqlChuaTT = "SELECT SUM(TongTien) FROM HoaDon " +
                                       "WHERE TrangThai = N'Chưa Thanh Toán'";
                    // Công nợ quá hạn
                    string sqlQuaHan = "SELECT SUM(TongTien) FROM HoaDon " +
                                       "WHERE TrangThai = N'Quá Hạn'";
                    // Tổng doanh thu
                    string sqlTongDT = "SELECT SUM(TongTien) FROM HoaDon";
                    double tongThangNay = LayTongTien(sqlThangNay, ketnoi.conn);
                    double tongThangTruoc = LayTongTien(sqlThangTruoc, ketnoi.conn);
                    double daThu = LayTongTien(sqlDaThu, ketnoi.conn);
                    double chuaTT = LayTongTien(sqlChuaTT, ketnoi.conn);
                    double quaHan = LayTongTien(sqlQuaHan, ketnoi.conn);
                    double tongDT = LayTongTien(sqlTongDT, ketnoi.conn);
                    // Label
                    lbl_tongthuthang.Text = tongThangNay.ToString("N0") + " VNĐ";
                    lblTongHienCo.Text = daThu.ToString("N0") + " VNĐ";
                    lblTongCongNo.Text = (chuaTT + quaHan).ToString("N0") + " VNĐ";
                    lblTongDoanhThu.Text = tongDT.ToString("N0") + " VNĐ";
                    // ================= chart1: so sánh tháng này và tháng trước =================
                    var s1 = chart1.Series["Series1"];
                    s1.Points.Clear();
                    s1.ChartType = SeriesChartType.Column;
                    s1.IsValueShownAsLabel = true;
                    s1.LabelFormat = "N0";
                    s1.Points.AddXY("Tháng trước", tongThangTruoc);
                    s1.Points[0].Color = Color.Gray;
                    s1.Points.AddXY("Tháng này", tongThangNay);
                    s1.Points[1].Color = Color.SeaGreen;
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                    chart1.ChartAreas[0].AxisX.Title = "So sánh thu";
                    chart1.ChartAreas[0].AxisY.Title = "Số tiền";
                    chart1.Legends[0].Enabled = false;
                    // ================= chart2: đã thu / chưa TT / quá hạn =================
                    var s2 = chart2.Series["Series1"];
                    s2.Points.Clear();
                    s2.ChartType = SeriesChartType.Doughnut;
                    s2.IsValueShownAsLabel = true;
                    s2.LabelFormat = "N0";
                    s2.Points.AddXY("Đã thu", daThu);
                    s2.Points.AddXY("Chưa TT", chuaTT);
                    s2.Points.AddXY("Quá hạn", quaHan);
                    s2.Points[0].Color = Color.SeaGreen;
                    s2.Points[1].Color = Color.Goldenrod;
                    s2.Points[2].Color = Color.Red;
                    // ================= chart3: 6 tháng gần nhất =================
                    var s3 = chart3.Series["Series1"];
                    s3.Points.Clear();
                    s3.ChartType = SeriesChartType.Line;
                    s3.BorderWidth = 3;
                    s3.IsValueShownAsLabel = true;
                    s3.LabelFormat = "N0";
                    s3.Color = Color.RoyalBlue;
                    for (int i = 5; i >= 0; i--)
                    {
                        DateTime t = DateTime.Now.AddMonths(-i);
                        string sql6Thang = "SELECT SUM(TongTien) FROM HoaDon " +
                                           "WHERE TrangThai = N'Đã Thanh Toán' " +
                                           "AND Thang = " + t.Month + " AND Nam = " + t.Year;
                        double val = LayTongTien(sql6Thang, ketnoi.conn);
                        s3.Points.AddXY("T" + t.Month + "/" + t.Year, val);
                    }
                    chart3.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                    chart3.ChartAreas[0].AxisX.Title = "6 tháng gần nhất";
                    chart3.ChartAreas[0].AxisY.Title = "Số tiền";
                    chart3.Legends[0].Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    ketnoi.dongketnoi();
                }
            }
            else
            {
                MessageBox.Show("Không thể kết nối CSDL");
            }
        }
        private void ancontrols()
        {
            pnl_title.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
        }
        private void hiencontrols()
        {
            pnl_title.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = true;
        }
        private void AnTatCaFormCon()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null && !frm.IsDisposed)
                {
                    frm.Close();
                }
            }
        }
        //----------------MenuStrip---------------------
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
        }
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                AnTatCaFormCon();
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                ancontrols();
                frmttcanhan.Show();
            }
            else
            {
                frmttcanhan.Activate();
            }
        }
        private void Frm_Thongtintaikhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmttcanhan = null;
            hiencontrols();
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                AnTatCaFormCon();
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                ancontrols();
                frmxacthuc.Show();
            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmxacthuc = null;
            hiencontrols();
        }
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Hide();
        }
        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(menu);
            cudan.Show();
            this.Close();   
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo(menu);
            canho.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoadon = new Frm_HoaDon(menu);
            hoadon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
            this.Close();
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congno = new Frm_CongNo(menu);
            congno.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hiện đang ở trang Thống Kê Tài Chính!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(menu);
            cskh.Show();
            this.Close();
        }
        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(menu);
            dkdv.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua btsc = new Frm_BaoTriSuaChua(menu);
            btsc.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baixe = new Frm_BaiXe(menu);
            baixe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong = new Frm_ChamCong(menu);
            chamcong.Show();
            this.Close();
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //-----------------------------------------
        private void Frm_ThongKeTaiChinh_Load(object sender, EventArgs e)
        {
            VeBieuDoTaiChinh();
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 4)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            }else if (quyen == 7)
            {
                //null
            }

        }
    }
}
