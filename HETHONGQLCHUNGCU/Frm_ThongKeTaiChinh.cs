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
        public Frm_ThongKeTaiChinh()
        {
            InitializeComponent();
        }
        public Frm_ThongKeTaiChinh(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
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

        private void Frm_ThongKeTaiChinh_Load(object sender, EventArgs e)
        {
            LoadThongKeTaiChinh();
        }
        //-----------------------------------------
        void LoadThongKeTaiChinh()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                try
                {
                    // 1. Tính toán xong...
                    string sqlDT = "SELECT SUM(TongTien) FROM HoaDon";
                    SqlCommand cmdDT = new SqlCommand(sqlDT, ketnoi.conn);
                    object resultDT = cmdDT.ExecuteScalar();
                    double tongDT = (resultDT != DBNull.Value) ? Convert.ToDouble(resultDT) : 0;

                    string sqlHC = "SELECT SUM(TongTien) FROM HoaDon WHERE TrangThai = N'Đã thanh toán'";
                    SqlCommand cmdHC = new SqlCommand(sqlHC, ketnoi.conn);
                    object resultHC = cmdHC.ExecuteScalar();
                    double tongHC = (resultHC != DBNull.Value) ? Convert.ToDouble(resultHC) : 0;

                    string sqlCN = "SELECT SUM(TongTien) FROM HoaDon WHERE TrangThai = N'Chưa thanh toán'";
                    SqlCommand cmdCN = new SqlCommand(sqlCN, ketnoi.conn);
                    object resultCN = cmdCN.ExecuteScalar();
                    double tongCN = (resultCN != DBNull.Value) ? Convert.ToDouble(resultCN) : 0;

                    // 2. ...THÌ PHẢI GÁN VÀO LABEL NGAY TẠI ĐÂY (Trong dấu ngoặc của hàm)
                    lblTongDoanhThu.Text = tongDT.ToString("N0") + " VNĐ";
                    lblTongHienCo.Text = tongHC.ToString("N0") + " VNĐ";
                    lblTongCongNo.Text = tongCN.ToString("N0") + " VNĐ";

                    // 3. Sau đó vẽ biểu đồ (Cũng nằm trong này luôn)
                    cht_ThongKeTaiChinh.Series["Series1"].Points.Clear();
                    cht_ThongKeTaiChinh.Series["Series1"].Points.AddXY("Doanh thu", tongDT);
                    cht_ThongKeTaiChinh.Series["Series1"].Points.AddXY("Hiện có", tongHC);
                    cht_ThongKeTaiChinh.Series["Series1"].Points.AddXY("Công nợ", tongCN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ketnoi.dongketnoi();
                }
            }
        }

    }
}
