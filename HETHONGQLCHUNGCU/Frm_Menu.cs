using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace HETHONGQLCHUNGCU
{

    public partial class Frm_Menu : Form
    {
        //=========Xay dung ham set trang thai cac chuc nang ve Enabled khi chua dang nhap = false và nguoclai dua tren lop cls_checklogin =========
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
            settrangthaichucnang(DaDangNhap,pnl_cskh, pic_CSKH, lbl_cskh, lbl_cskh1);
            settrangthaichucnang(DaDangNhap, pnl_dkdv, pic_dkdv, lbl_dk, lbl_dk1);
            settrangthaichucnang(DaDangNhap, pnl_baotri, pic_btsc, lbl_btsc, lbl_btsc1);
            settrangthaichucnang(DaDangNhap, pnl_baixe, pic_xe, lbl_bx, lbl_bx1);
            settrangthaichucnang(DaDangNhap, pnl_bangdanhgia, pic_bangdanhgia, lbl_dg, lbl_dg1);
            settrangthaichucnang(DaDangNhap, pnl_chamcong, pic_chamcong, lbl_cc, lbl_cc1);
            settrangthaichucnang(DaDangNhap, pnl_bangphancong, pic_bangphancong, lbl_pc, lbl_pc1);
        }
        //=========================================================
        //========================xay dung ham dang xuat===========
        public void DangXuat()
        {
            cls_chcecklogin.DaDangNhap = false;
            cb_user.Visible = false;
            cb_user.Items.Clear();
            btn_dangnhap.Visible = true;
            btn_thoat.Visible = true;
            capnhattrangthaichucnang(false);
            MessageBox.Show("Đăng xuất thành công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //==========================================================
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            btn_dangnhap.Visible = true;//hiện button đăng nhập
            btn_thoat.Visible = true;//hiện button thoát
            cb_user.Visible = false;//tắt ComboBox
            cb_user.DropDownStyle = ComboBoxStyle.DropDownList;
            capnhattrangthaichucnang(false);
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)//button đăng nhập
        {
            Frm_Login frm = new Frm_Login();
            if (frm.ShowDialog() == DialogResult.OK || cls_chcecklogin.DaDangNhap)
            {
                string ten = frm.TenDangNhap;
                btn_dangnhap.Visible = false;
                btn_thoat.Visible = false;
                capnhattrangthaichucnang(true);
                cb_user.Visible = true;
                cb_user.Items.Clear();
                cb_user.Items.Add("Xin Chào " + ten);
                cb_user.Items.Add("Đăng Xuất");
                cb_user.Items.Add("Đổi Mật Khẩu");
                cb_user.SelectedIndex = 0;
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
            if (cb_user.SelectedItem.ToString() == "Đăng Xuất")
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát hệ thống không?", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DangXuat();
                }
            }
        }

        //===========================Kiem tra dang nhap truoc khi vao cac chuc nang===========================      
        private void ptrb_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoaDon = new Frm_HoaDon(this);
            hoaDon.Show();
            this.Hide();
        }
        private void ptrb_CSKH_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(this);
            cskh.Show();
            this.Hide();
        }
        private void ptrb_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaotruSuachua baotri = new Frm_BaotruSuachua(this);
            baotri.Show();
            this.Hide();
        }

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

        private void ptrb_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCongNV = new Frm_ChamCong(this);
            chamCongNV.Show();
            this.Hide();
        }
        //========================================================================================================
        

    }
}
