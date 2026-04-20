using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }
        //phanquyen       
        private void setquyen()
        {
            // 1. Admin
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 1)
            {
                Frm_Admin admin = new Frm_Admin();
                admin.Show();
                this.Hide();
            }
            else if (quyen == 2) // 2. Quyền Nhân Viên
            {
                capnhattrangthaichucnang(false);
                settrangthaichucnang(true, pnl_bangdanhgia, pic_bangdanhgia, lbl_dg, lbl_dg1);
                settrangthaichucnang(true, pnl_chamcong, pic_chamcong, lbl_cc, lbl_cc1);
                settrangthaichucnang(true, pnl_bangphancong, pic_bangphancong, lbl_pc, lbl_pc1);
            }
            else if (quyen == 3) // 3. Quyền Trưởng Phòng Nhân Sự
            {
                capnhattrangthaichucnang(false);
                settrangthaichucnang(true, pnl_bangdanhgia, pic_bangdanhgia, lbl_dg, lbl_dg1);
                settrangthaichucnang(true, pnl_chamcong, pic_chamcong, lbl_cc, lbl_cc1);
                settrangthaichucnang(true, pnl_bangphancong, pic_bangphancong, lbl_pc, lbl_pc1);
            }
            else if (quyen == 4) // 4. Quyền Trưởng Phòng Kế Hoạch Tài Chính
            {
                capnhattrangthaichucnang(false);
                settrangthaichucnang(true, pnl_congno, pic_congno, lbl_cn, lbl_cn1);
                settrangthaichucnang(true, pnl_thanhtoan, pic_thanhtoan, lbl_tt, lbl_tt1);
                settrangthaichucnang(true, pnl_hoadon, pic_hoadon, lbl_hoadon, lbl_hoadon1);
                settrangthaichucnang(true, pnl_thongketc, pic_thongketc, lbl_tk, lbl_tk1);
            }
            else if (quyen == 5) // 5. Quyền Trưởng Phòng Dịch Vụ - Tiện Ích
            {
                capnhattrangthaichucnang(false);
                settrangthaichucnang(true, pnl_cskh, pic_CSKH, lbl_cskh, lbl_cskh1);
                settrangthaichucnang(true, pnl_dkdv, pic_dkdv, lbl_dk, lbl_dk1);
                settrangthaichucnang(true, pnl_baotri, pic_btsc, lbl_btsc, lbl_btsc1);
                settrangthaichucnang(true, pnl_baixe, pic_xe, lbl_bx, lbl_bx1);
            }
            else if (quyen == 6) // 6. Cư Dân
            {
                capnhattrangthaichucnang(true);
                settrangthaichucnang(false, pnl_bangdanhgia, pic_bangdanhgia, lbl_dg, lbl_dg1);
                settrangthaichucnang(false, pnl_chamcong, pic_chamcong, lbl_cc, lbl_cc1);
                settrangthaichucnang(false, pnl_bangphancong, pic_bangphancong, lbl_pc, lbl_pc1);
            }else if(quyen == 7)// 7. Quyền Ban Quản Lý
            {
                capnhattrangthaichucnang(true);
            }
        }       
        //xây dựng hàm mở form đổi mật khẩu
        private void MoFormDoiMatKhau()
        {
            Frm_HTxacthuctaptrung f = new Frm_HTxacthuctaptrung();
            f.DangXuatSauDoiMK += () =>
            {
                this.DangXuat();
                this.Close();
                Frm_Login login = new Frm_Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    cls_chcecklogin.DaDangNhap = true;
                    string ten = login.TenDangNhap;
                    btn_dangnhap.Visible = false;
                    btn_thoat.Visible = false;
                    pnl_canhbao.Visible = false;
                    capnhattrangthaichucnang(true);
                    cb_user.Visible = true;
                    cb_user.Items.Clear();
                    cb_user.Items.Add("Xin Chào " + cls_chcecklogin.TenHienThi);
                    cb_user.Items.Add("Đăng Xuất");
                    cb_user.Items.Add("Đổi Mật Khẩu");
                    cb_user.SelectedIndex = 0;
                }
            };

            f.ShowDialog();
        }
        //xây dựng hàm cập nhật trạng thái các chức năng
        private void settrangthaichucnang(bool enabled, Panel pnl, PictureBox pic, Label lbl1, Label lbl2)
        {
            pnl.Enabled = enabled;
            pic.Enabled = enabled;
            lbl1.Enabled = enabled;
            lbl2.Enabled = enabled;
        }        
        private void capnhattrangthaichucnang (bool DaDangNhap)
        {
            settrangthaichucnang(DaDangNhap, pnl_canho, pic_canho, lbl_canho, lbl_canho1);
            settrangthaichucnang(DaDangNhap, pnl_cudan, pic_cudan, lbl_cudan, lbl_cudan1);
            settrangthaichucnang(DaDangNhap, pnl_congno, pic_congno, lbl_cn, lbl_cn1);
            settrangthaichucnang(DaDangNhap, pnl_thanhtoan, pic_thanhtoan, lbl_tt, lbl_tt1);
            settrangthaichucnang(DaDangNhap, pnl_hoadon, pic_hoadon, lbl_hoadon, lbl_hoadon1);
            settrangthaichucnang(DaDangNhap, pnl_thongketc, pic_thongketc, lbl_tk, lbl_tk1);
            settrangthaichucnang(DaDangNhap, pnl_cskh, pic_CSKH, lbl_cskh, lbl_cskh1);
            settrangthaichucnang(DaDangNhap, pnl_dkdv, pic_dkdv, lbl_dk, lbl_dk1);
            settrangthaichucnang(DaDangNhap, pnl_baotri, pic_btsc, lbl_btsc, lbl_btsc1);
            settrangthaichucnang(DaDangNhap, pnl_baixe, pic_xe, lbl_bx, lbl_bx1);
            settrangthaichucnang(DaDangNhap, pnl_bangdanhgia, pic_bangdanhgia, lbl_dg, lbl_dg1);
            settrangthaichucnang(DaDangNhap, pnl_chamcong, pic_chamcong, lbl_cc, lbl_cc1);
            settrangthaichucnang(DaDangNhap, pnl_bangphancong, pic_bangphancong, lbl_pc, lbl_pc1);
        }
        //xây dựng hàm đăng xuất
        public void DangXuat()
        {
            cls_chcecklogin.DaDangNhap = false;
            cb_user.SelectedIndex = -1;
            cb_user.Text = "";
            cb_user.Visible = false;
            pnl_canhbao.Visible = true;
            cb_user.Items.Clear();
            btn_dangnhap.Visible = true;
            btn_thoat.Visible = true;
            capnhattrangthaichucnang(false);
            MessageBox.Show("Đăng xuất thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       
        //xây dựng hàm bo góc
        GraphicsPath BoGocPanel(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            pnl_canhbao.Region = new Region(BoGocPanel(pnl_canhbao.ClientRectangle, 5));
            pnl_canhbao.BackColor = Color.FromArgb(120, 220, 53, 69);
            btn_dangnhap.Visible = true;//hiện button đăng nhập
            btn_thoat.Visible = true;//hiện button thoát
            cb_user.Visible = false;//tắt ComboBox
            cb_user.DropDownStyle = ComboBoxStyle.DropDownList;
            capnhattrangthaichucnang(false);
        }
        //Điều hướng
        private void btn_dangnhap_Click(object sender, EventArgs e)//button đăng nhập
        {
            Frm_Login frm = new Frm_Login();
            if (frm.ShowDialog() == DialogResult.OK || cls_chcecklogin.DaDangNhap)
            {               
                string ten = frm.TenDangNhap;
                btn_dangnhap.Visible = false;
                btn_thoat.Visible = false;
                pnl_canhbao.Visible = false;
                capnhattrangthaichucnang(true);
                cb_user.Visible = true;
                cb_user.Items.Clear();
                cb_user.Items.Add("Xin Chào " + cls_chcecklogin.TenHienThi);
                cb_user.Items.Add("Đăng Xuất");
                cb_user.Items.Add("Đổi Mật Khẩu");
                cb_user.SelectedIndex = 0;
                setquyen();
            }            
        }
        private void btn_thoat_Click(object sender, EventArgs e)//button thoát
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void cb_user_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cb_user.SelectedItem == null)
                return;
            string luaChon = cb_user.SelectedItem.ToString();
            if (luaChon == "Đăng Xuất")
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát hệ thống không?",
                    "Hệ Thống Quản Lý Chung Cư - Thông Báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DangXuat();
                }
            }
            else if (luaChon == "Đổi Mật Khẩu")
            {
                MoFormDoiMatKhau();
                if (cb_user.Items.Count > 0)
                    cb_user.SelectedIndex = 0;
            }
        }

        //-------------------------MENU-------------------------   
        ///1. Quản Lý Tòa Nhà
        private void ptrb_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(this);
            cudan.Show();
            this.Hide();
        }
        private void ptrb_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canHo = new Frm_CanHo(this);
            canHo.Show();
            this.Hide();
        }
        ///2. Quản Lý Tài Chính
        private void ptrb_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoaDon = new Frm_HoaDon(this);
            hoaDon.Show();
            this.Hide();
        }
        private void ptrb_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhToan = new Frm_TT(this);
            thanhToan.Show();
            this.Hide();
        }
        private void ptrb_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(this);
            congNo.Show();
            this.Hide();
        }
        private void ptrb_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(this);
            thongKeTaiChinh.Show();
            this.Hide();
        }
        ///3. Quản Lý Dịch Vụ-Tiện Ích
        private void ptrb_CSKH_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(this);
            cskh.Show();
            this.Hide();
        }
        private void ptrb_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dk = new frm_Dangkydichvu(this);
            dk.Show();
            this.Hide();
        }
        private void ptrb_xe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe guiXe = new Frm_BaiXe(this);
            guiXe.Show();
            this.Hide();
        }
        private void ptrb_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(this);
            baotri.Show();
            this.Hide();
        }
        ///4. Quản Lý Nhân Sự
        private void ptrb_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(this);
            bpc.Show();
            this.Hide();
        }
        private void ptrb_bangdanhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(this);
            danhGiaNhanSu.Show();
            this.Hide();
        }            
        private void ptrb_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCongNV = new Frm_ChamCong(this);
            chamCongNV.Show();
            this.Hide();
        }
        //----------------------------------------
    }
}
