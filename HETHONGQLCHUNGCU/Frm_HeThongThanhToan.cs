using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_HeThongThanhToan : Form
    {
        public Frm_HeThongThanhToan()
        {
            InitializeComponent();
        }
        string maHD = "";
        string maCN = "";
        string maCH = "";
        decimal soTien = 0;
        public Frm_HeThongThanhToan(string _maHD, string _maCN, string _maCH, decimal _soTien)
        {
            InitializeComponent();

            maHD = _maHD;
            maCN = _maCN;
            maCH = _maCH;
            soTien = _soTien;
        }
        private void Frm_HeThongThanhToan_Load(object sender, EventArgs e)
        {
            txt_mahd.Text = maHD;
            txt_macanho.Text = maCH;
            txt_sotien.Text = soTien.ToString("N0");
            txt_magiaodich.Text = "GD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txt_noidung.Text = "Thanh toán hóa đơn " + maHD;
            pic_qr.Visible = false;
            txt_ngaythanhtoan.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txt_mahd.ReadOnly = true;
            txt_macanho.ReadOnly = true;
            txt_sotien.ReadOnly = true;
            txt_magiaodich.ReadOnly = true;
            txt_ngaythanhtoan.ReadOnly = true;
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (maHD == "" && maCN == "")
            {
                MessageBox.Show("Không có dữ liệu để thanh toán!");
                return;
            }
            string phuongThuc = "";
            if (rdb_chuyenkhoan.Checked)
                phuongThuc = "Chuyển Khoản";
            else if (rdb_vidientu.Checked)
                phuongThuc = "Ví Điện Tử";
            else if (rdb_thenganhang.Checked)
                phuongThuc = "Thẻ Ngân Hàng";
            else if (rdb_qrcode.Checked)
                phuongThuc = "QR Code";
            if (phuongThuc == "")
            {
                MessageBox.Show("Chọn phương thức thanh toán!");
                return;
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sqlTT =
                        "UPDATE ThanhToan SET " +
                        "NgayThanhToan = GETDATE(), " +
                        "PhuongThuc = N'" + phuongThuc + "', " +
                        "TrangThai = N'Đã Thanh Toán', " +
                        "NguoiThu = N'Hệ Thống', " +
                        "NoiDung = N'Mã GD: " + txt_magiaodich.Text + "' " +
                        "WHERE MaHoaDon = N'" + maHD + "' OR MaCongNo = N'" + maCN + "'";
                    ketnoi.capnhat(sqlTT);
                    if (maHD != "")
                    {
                        string sqlHD =
                            "UPDATE HoaDon SET " +
                            "TrangThai = N'Đã Thanh Toán', " +
                            "GhiChu = N'Mã GD: " + txt_magiaodich.Text + "' " +
                            "WHERE MaHoaDon = N'" + maHD + "'";
                        ketnoi.capnhat(sqlHD);
                    }
                    if (maCN != "")
                    {
                        string sqlCN =
                            "UPDATE CongNo SET " +
                            "TrangThai = N'Đã Thanh Toán', " +
                            "GhiChu = N'Mã GD: " + txt_magiaodich.Text + "' " +
                            "WHERE MaCongNo = N'" + maCN + "'";
                        ketnoi.capnhat(sqlCN);
                    }
                    ketnoi.dongketnoi();
                    MessageBox.Show("Thanh toán thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rdb_qrcode_CheckedChanged(object sender, EventArgs e)
        {
            pic_qr.Visible = true;
            pic_qr.Image = Image.FromFile(Application.StartupPath + @"\qr_code.png");

            txt_noidung.Text = "Thanh toan " + txt_mahd.Text;
        }

        private void rdb_chuyenkhoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_chuyenkhoan.Checked)
            {
                pic_qr.Visible = false;
                txt_noidung.Text = "Chuyen khoan " + txt_mahd.Text;
            }
        }

        private void rdb_vidientu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_vidientu.Checked)
            {
                pic_qr.Visible = false;
                txt_noidung.Text = "Vi dien tu " + txt_mahd.Text;
            }
        }

        private void rdb_thenganhang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_thenganhang.Checked)
            {
                pic_qr.Visible = false;
                txt_noidung.Text = "The ngan hang " + txt_mahd.Text;
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
