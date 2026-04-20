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
    public partial class Frm_CuDan : Form
    {
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_ThongTinCuDan frmThongTinCuDan = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_TTCuDan frmttcudan = null;
        public Frm_CuDan()
        {
            InitializeComponent();
        }        
        public Frm_CuDan(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //Xây dựng hàm dùng chung
        private void MDI()
        {
            frmThongTinCuDan = new Frm_ThongTinCuDan();
            frmThongTinCuDan.MdiParent = this;
            frmThongTinCuDan.StartPosition = FormStartPosition.Manual;
            frmThongTinCuDan.Location = new Point(154, 115);
            frmThongTinCuDan.FormBorderStyle = FormBorderStyle.None;
            frmThongTinCuDan.FormClosed += FrmThongTinCuDan_FormClosed;
            frmThongTinCuDan.Show();
        }
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void ancontrols()
        {
            grp_BoLoc.Visible = false;
            grp_trangthai.Visible = false;
            dgv_thongtincudan.Visible = false;
            pnl_title.Visible = false;
        }
        //xây dựng hàm cgo grpbox
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM CuDan";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tong.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    string sel1 = "SELECT COUNT(*) FROM CuDan WHERE TrangThai = N'Cư Trú'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_cutru.Text = rdr1[0].ToString();
                    }
                    rdr1.Close();
                    string sel2 = "SELECT COUNT(*) FROM CuDan WHERE TrangThai = N'Tạm Trú'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_tamtru.Text = rdr2[0].ToString();
                    }
                    rdr2.Close();
                    string sel3 = "SELECT COUNT(*) FROM CuDan WHERE TrangThai = N'Tạm Vắng'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_tamvang.Text = rdr3[0].ToString();
                    } rdr3.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CuDan WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mcd.Text))
                    {
                        sel += " AND MaCuDan LIKE N'%" + txt_mcd.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_hoten.Text))
                    {
                        sel += " AND HoTen LIKE N'%" + txt_hoten.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_quequan.Text))
                    {
                        sel += " AND QueQuan LIKE N'%" + txt_quequan.Text.Trim() + "%'";
                    }
                    if (cbx_trangthai.SelectedIndex > 0)
                    {
                        sel += " AND TrangThai = N'" + cbx_trangthai.SelectedItem.ToString() + "'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_thongtincudan.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void thêmCưDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                //show form con
                MDI();
                frmThongTinCuDan.settrangthaibutton(true, false, false);
                //ẩn controls 
                ancontrols();
            }
            else
            {
                frmThongTinCuDan.Activate();
            }
        }
        private void cậpNhậtThôngTinCưDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                //show form con
                MDI();
                frmThongTinCuDan.settrangthaibutton(false, true, false);
                //ẩn controls 
                ancontrols();
            }
            else
            {
                frmThongTinCuDan.Activate();
            }
        }
        private void xóaTHÔToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThongTinCuDan == null || frmThongTinCuDan.IsDisposed)
            {
                //show form con
                MDI();
                frmThongTinCuDan.settrangthaibutton(false, false, true);
                //ẩn controls 
                ancontrols();
            }
            else
            {
                frmThongTinCuDan.Activate();    
            }
        }
        private void FrmThongTinCuDan_FormClosed(object sender, FormClosedEventArgs e)
        {
            // hiển thị controls
            grp_BoLoc.Visible = true;
            grp_trangthai.Visible = true;
            dgv_thongtincudan.Visible = true;
            pnl_title.Visible = true;
        }
        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        { if (menu != null)
            {
                menu.Show();
            } this.Close();
        }       
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmttcudan != null && !frmttcudan.IsDisposed)
                    {
                        frmttcudan.Hide();
                    }
                }
                else
                {
                    ancontrols();
                }
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
            if (cls_chcecklogin.Quyen == 6)
            {
                if (frmttcudan != null && !frmttcudan.IsDisposed)
                {
                    frmttcudan.Show();
                    frmttcudan.BringToFront();
                }
            }
            else
            {
                grp_BoLoc.Visible = true;
                grp_trangthai.Visible = true;
                dgv_thongtincudan.Visible = true;
                pnl_title.Visible = true;
            }
        }
       
        //----------------------------------------
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
            MessageBox.Show("Bạn đang ở trang Cư Dân!!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {           
            Frm_CanHo frmCanHo = new Frm_CanHo(menu);
            frmCanHo.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon frmHoaDon = new Frm_HoaDon(menu);
            frmHoaDon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT frmThanhToan = new Frm_TT(menu);
            frmThanhToan.Show();
            this.Close();
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo frmCongNo = new Frm_CongNo(menu);
            frmCongNo.Show();
            this.Close();
        }
        private void btn_thongke_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh frmThongKe = new Frm_ThongKeTaiChinh(menu);
            frmThongKe.Show();
            this.Close();
        }
        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH frmcskh = new Frm_CSKH(menu);
            frmcskh.Show();
            this.Close();
        }
        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu frmDangKyDichVu = new frm_Dangkydichvu(menu);
            frmDangKyDichVu.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua frmBaoTriSuaChua = new Frm_BaoTriSuaChua(menu);
            frmBaoTriSuaChua.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe frmBaiXe = new Frm_BaiXe(menu);
            frmBaiXe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong frmChamCong = new Frm_ChamCong(menu);
            frmChamCong.Show();
            this.Close();
        }
        private void btn_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV frmPhanCong = new Frm_BPCNV(menu);
            frmPhanCong.Show();
            this.Close();
        }
        private void btn_bangdanhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu frmBangDanhGia = new frm_DanhGiaNhanSu(menu);
            frmBangDanhGia.Show();
            this.Close();
        }
        //----------------------------------------
        //----------------Đổ Dữ Liệu--------------
        private void Frm_CuDan_Load(object sender, EventArgs e)
        {
            
            thongke();
            //truyền dl cbx
            cbx_trangthai.Items.Clear();
            cbx_trangthai.Items.Add("--Chọn Trạng Thái--");
            cbx_trangthai.Items.Add("Cư Trú");
            cbx_trangthai.Items.Add("Tạm Trú");
            cbx_trangthai.Items.Add("Tạm Vắng");
            cbx_trangthai.SelectedIndex = 0;
            //1. Phân Quyền Chức Năng
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_bdgns, btn_thongke, btn_btsc);
                quảnLýThôngTInCưDânToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmttcudan = new Frm_TTCuDan();
                frmttcudan.MdiParent = this;
                frmttcudan.StartPosition = FormStartPosition.Manual;
                frmttcudan.Location = new Point(190, 165);
                frmttcudan.FormBorderStyle = FormBorderStyle.None;
                frmttcudan.Show();
                grp_BoLoc.Visible = false;
                grp_trangthai.Visible = false;
                dgv_thongtincudan.Visible = false;
                pnl_title.Visible = false;
            }
            else if (quyen == 7)
            {
                //null
            }
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT * FROM CuDan";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    rdr.Close();
                    dgv_thongtincudan.DataSource = dt;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, 
                    "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                frmttcanhan.Show();
                //ẩn contorls
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmttcudan != null && !frmttcudan.IsDisposed)
                    {
                        frmttcudan.Hide();
                    }
                }
                else
                {
                    ancontrols();
                }
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
            if (cls_chcecklogin.Quyen == 6)
            {
                if (frmttcudan != null && !frmttcudan.IsDisposed)
                {
                    frmttcudan.Show();
                    frmttcudan.BringToFront();
                }
            }
            else
            {
                grp_BoLoc.Visible = true;
                grp_trangthai.Visible = true;
                dgv_thongtincudan.Visible = true;
                pnl_title.Visible = true;
            }
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            if(txt_hoten.Text.Trim() == "" && txt_mcd.Text.Trim() == "" && txt_quequan.Text.Trim() == "" && cbx_trangthai.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một tiêu chí tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                timkiem();
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            Frm_CuDan_Load(sender, e);
            txt_hoten.Clear();
            txt_mcd.Clear();
            txt_quequan.Clear();
        }
    }
}
