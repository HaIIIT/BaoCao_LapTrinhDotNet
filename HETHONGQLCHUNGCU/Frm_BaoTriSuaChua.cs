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
    public partial class Frm_BaoTriSuaChua : Form
    {
        private frm_btsc frmbtsc = null;
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        public Frm_BaoTriSuaChua()
        {
            InitializeComponent();
        }
        public Frm_BaoTriSuaChua(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI()
        {
            frmbtsc = new frm_btsc();
            frmbtsc.MdiParent = this;
            frmbtsc.StartPosition = FormStartPosition.Manual;
            frmbtsc.Location = new Point(175, 140);
            frmbtsc.FormBorderStyle = FormBorderStyle.None;
            frmbtsc.FormClosed += Frmbtsc_FormClosed;
            frmbtsc.Show();
        }
        private void ancontrols()
        {
            pnl_title.Visible = false;
            pnl_title2.Visible = false;
            dgv_ThongTinBt.Visible = false;
            grp_ThonTinBaoTri.Visible = false;
            grp_TraCuBaoTri.Visible = false;
        }
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql1 = "SELECT COUNT(*) FROM BaoTriSuaChua";
                    SqlDataReader rdr1 = ketnoi.truyvan(sql1);
                    if (rdr1.Read())
                        lbl_tong.Text = rdr1[0].ToString();
                    rdr1.Close();
                    string sql2 = "SELECT COUNT(*) FROM BaoTriSuaChua WHERE LoaiBaoTri = N'Bảo trì'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sql2);
                    if (rdr2.Read())
                        lbl_baotri.Text = rdr2[0].ToString();
                    rdr2.Close();
                    string sql3 = "SELECT COUNT(*) FROM BaoTriSuaChua WHERE LoaiBaoTri = N'Sửa Chữa'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sql3);
                    if (rdr3.Read())
                        lbl_sua.Text = rdr3[0].ToString();
                    rdr3.Close();
                    string sql4 = "SELECT COUNT(*) FROM BaoTriSuaChua WHERE TrangThai = N'Chờ Xử Lý'";
                    SqlDataReader rdr4 = ketnoi.truyvan(sql4);
                    if (rdr4.Read())
                        lbl_moi.Text = rdr4[0].ToString();
                    rdr4.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                                "Hệ Thống Quản Lý Chung Cư",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaBaoTri, MaCanHo, MaYeuCau, TieuDe, LoaiBaoTri, NgayYeuCau, " +
                        "NgayBatDau, NgayHoanThanh, TrangThai, GhiChu FROM BaoTriSuaChua WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mbt.Text.Trim()))
                    {
                        sel += " AND MaBaoTri LIKE N'%" + txt_mbt.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_mch.Text.Trim()))
                    {
                        sel += " AND MaCanHo LIKE N'%" + txt_mch.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_myc.Text.Trim()))
                    {
                        sel += " AND MaYeuCau LIKE N'%" + txt_myc.Text.Trim() + "%'";
                    }
                    if (cbx_tt.SelectedIndex > 0)
                    {
                        sel += " AND TrangThai = N'"+cbx_tt.Text.Trim()+"'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_ThongTinBt.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Điều hướng
        private void themthongtinbaotrotool_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void cậpNhậtThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void xóaThôngTinBảoTrìsửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmbtsc == null || frmbtsc.IsDisposed)
            {
                MDI();
                frmbtsc.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmbtsc.Activate();
            }
        }
        private void Frmbtsc_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_title.Visible = true;
            pnl_title2.Visible = true;
            dgv_ThongTinBt.Visible = true;
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
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
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                ancontrols();
            }
            else
            {
                frmttcanhan.Activate();
            }
        }
        private void Frm_Thongtintaikhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmttcanhan = null;
            // hiển thị controls
            pnl_title.Visible = true;
            pnl_title2.Visible = true;
            dgv_ThongTinBt.Visible = true;
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
        }
        private void quênMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                ancontrols();

            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmxacthuc = null;
            pnl_title.Visible = true;
            pnl_title2.Visible = true;
            dgv_ThongTinBt.Visible = true;
            grp_ThonTinBaoTri.Visible = true;
            grp_TraCuBaoTri.Visible = true;
        }
        //-----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
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
            Frm_HoaDon hoaDon = new Frm_HoaDon(menu);
            hoaDon.Show();
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
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(menu);
            thongKeTaiChinh.Show();
            this.Close();
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
            MessageBox.Show("Bạn đang ở trang Bảo trì - Sửa chữa!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(menu);
            baiXe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(menu);
            chamCong.Show();
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
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(menu);
            danhGiaNhanSu.Show();
            this.Close();
        }
        //-----------------------------------
        private void Frm_BaoTriSuaChua_Load(object sender, EventArgs e)
        {
            btn_load.Visible = false;
            thongke();
            //xử lý combobox
            cbx_tt.Items.Clear();
            cbx_tt.Items.Add("--Chọn Trạng Thái--");
            cbx_tt.Items.Add("Hoàn Thành");
            cbx_tt.Items.Add("Đang Thực hiện");
            cbx_tt.Items.Add("Chờ Xử Lý");
            cbx_tt.SelectedIndex = 0;
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 5)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc);
            }else if (quyen == 7){ }
                Connection ketnoi = new Connection();
            try
            {                
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaBaoTri, MaCanHo, MaYeuCau, TieuDe, LoaiBaoTri, NgayYeuCau, NgayBatDau, NgayHoanThanh, TrangThai, GhiChu FROM BaoTriSuaChua";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_ThongTinBt.DataSource = tb;
                    ketnoi.dongketnoi();
                }
                else
                {
                    MessageBox.Show("Khong the ket noi CSDL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (txt_mbt.Text.Trim() == "" && txt_mch.Text.Trim() == "" && txt_myc.Text.Trim() == ""&&cbx_tt.SelectedIndex==0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một tiêu chí tìm kiếm!",
                    "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                timkiem();
                btn_load.Visible = true;
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua_Load(sender, e);
            txt_mbt.Clear();
            txt_mch.Clear();
            txt_myc.Clear();
            cbx_tt.SelectedIndex = 0;
        }

    }
}
