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
    public partial class Frm_Thongtintaikhoan : Form
    {
        public Frm_Thongtintaikhoan()
        {
            InitializeComponent();
        }
        //xậy dựng hàm load thông tin cư dân
        private void loadthongtincudan()
        {
                Connection ketnoi = new Connection();
            try
            {
                if(ketnoi.moketnoi())
                {
                    string macd = cls_chcecklogin.MaCuDan;
                    string sel ="SELECT cd.MacuDan, cd.HoTen, cd.GioiTinh, cd.NgaySinh, cd.NoiSinh, cd.QueQuan, cd.CCCD, cd.Email, cd.SoDienThoai, cd.TrangThai," +
                    "ch.MaCanHo, ch.Tang, ch.SoCan, ch.TrangThai AS TrangThaiCanHo FROM CuDan cd " +
                    "LEFT JOIN HopDong cdcn ON cd.MaCuDan = cdcn.MaCuDan " +
                    "LEFT JOIN CanHo ch ON cdcn.MaCanHo = ch.MaCanHo " +
                    "WHERE cd.MaCuDan = '" + macd + "'";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        txt_mdd.Text = rdr["MaCuDan"].ToString();
                        txt_hoten.Text = rdr["HoTen"].ToString();
                        txt_ngaysinh.Text = rdr["NgaySinh"].ToString();
                        txt_noisinh.Text = rdr["NoiSinh"].ToString();
                        txt_diachi.Text = rdr["QueQuan"].ToString();
                        txt_cccd.Text = rdr["CCCD"].ToString();
                        txt_email.Text = rdr["Email"].ToString();
                        txt_sdt.Text = rdr["SoDienThoai"].ToString();
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
                        if (rdr["GioiTinh"].ToString() == "0")
                        {
                            rdb_nam.Checked = true;
                        }
                        else if (rdr["GioiTinh"].ToString() == "1")
                        {
                            rdb_Nu.Checked = true;
                        }
                        txt_MaCanHo.Text = rdr["MaCanHo"].ToString();
                        txt_Tang.Text = rdr["Tang"].ToString();
                        txt_SoCan.Text = rdr["SoCan"].ToString();
                        txt_TrangThaiCanHo.Text = rdr["TrangThaiCanHo"].ToString();
                        rdr.Close();
                    }
                }
                ketnoi.dongketnoi();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void loadthongtinhansu()
        {
            txt_TrangThaiCanHo.Visible = false;
            lbl_trangthai.Visible = false;
            gpb_ttcanho.Text= "Thông Tin Phòng Ban - Chức Vụ";
            lbl_socan.Text = "Chức Vụ:";
            lbl_mch.Text = "Mã Nhân Sự:";
            lbl_tang.Text = "Phòng Ban:";
            txt_Tang.Location = new Point(450, 34);
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string mans = cls_chcecklogin.MaNhanVien;
                    string selStr = "SELECT ns.MaNhanSu, ns.HoTen, ns.GioiTinh, ns.NgaySinh, ns.NoiSinh, ns.QueQuan," +
                        "ns.CCCD, ns.Email, ns.SoDienThoai, ns.ChucVu, ns.TrangThai, pb.MaPhongBan, pb.TenPhongBan FROM NhanSu ns" +
                        " LEFT JOIN PhongBan pb ON ns.MaPhongBan = pb.MaPhongBan" +
                        " WHERE ns.MaNhanSu='" + mans + "'";
                    SqlDataReader rdr = ketnoi.truyvan(selStr);
                    if (rdr.Read())
                    {
                        txt_mdd.Text = rdr["MaNhanSu"].ToString();
                        txt_hoten.Text = rdr["HoTen"].ToString();
                        txt_ngaysinh.Text = rdr["NgaySinh"].ToString();
                        txt_noisinh.Text = rdr["NoiSinh"].ToString();
                        txt_diachi.Text = rdr["QueQuan"].ToString();
                        txt_cccd.Text = rdr["CCCD"].ToString();
                        txt_email.Text = rdr["Email"].ToString();
                        txt_sdt.Text = rdr["SoDienThoai"].ToString();
                        txt_trangthai.Text = rdr["TrangThai"].ToString();
                        if (rdr["GioiTinh"].ToString() == "0")
                        {
                            rdb_nam.Checked = true;
                        }
                        else if (rdr["GioiTinh"].ToString() == "1")
                        {
                            rdb_Nu.Checked = true;
                        }
                        txt_MaCanHo.Text = rdr["MaPhongBan"].ToString();
                        txt_Tang.Text = rdr["TenPhongBan"].ToString();
                        txt_SoCan.Text = rdr["ChucVu"].ToString();
                        rdr.Close();
                    }
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Thongtintaikhoan_Load(object sender, EventArgs e)
        {
            if (cls_chcecklogin.Quyen == 6)
            {
                loadthongtincudan();
            }
            else
            {
                loadthongtinhansu();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
