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
    public partial class frm_Dangkydichvu : Form
    {
        private frm_dkdv frmDangKyDichVu = null;
        private Frm_ThemDMDV_DKDV frmdmdv = null;
        public Frm_Menu menu;
        public frm_Dangkydichvu()
        {
            InitializeComponent();
        }
        public frm_Dangkydichvu(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI1()
        {
            frmDangKyDichVu = new frm_dkdv();
            frmDangKyDichVu.MdiParent = this;
            frmDangKyDichVu.StartPosition = FormStartPosition.Manual;
            frmDangKyDichVu.Location = new Point(170, 100);
            frmDangKyDichVu.FormBorderStyle = FormBorderStyle.None;
            frmDangKyDichVu.FormClosed += frmDangKyDichVu_FormClosed;
            frmDangKyDichVu.Show();
        }
        private void MDI2()
        {
            frmdmdv = new Frm_ThemDMDV_DKDV();
            frmdmdv.MdiParent = this;
            frmdmdv.StartPosition = FormStartPosition.Manual;
            frmdmdv.Location = new Point(170, 100);
            frmdmdv.FormBorderStyle = FormBorderStyle.None;
            frmdmdv.FormClosed += frmdmdv_FormClosed;
            frmdmdv.Show();
        }
        private void ancontrols()
        {
            pnl_titel1.Visible = false;
            grp_ThonTinDangKy.Visible = false;
            grp_TraCuDichVu.Visible = false;
            pnl_tiltel2.Visible = false;
            grb_dsdkdv.Visible = false;
            grb_dsdvti.Visible = false;
        }
        //----------------MenuStrip---------------------
        private void dangkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {
                MDI1();
                frmDangKyDichVu.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void sửaĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {

                MDI1();
                frmDangKyDichVu.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void xóaĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDangKyDichVu == null || frmDangKyDichVu.IsDisposed)
            {
                MDI1();
                frmDangKyDichVu.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmDangKyDichVu.Activate();
            }
        }
        private void frmDangKyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_titel1.Visible = true;
            grp_ThonTinDangKy.Visible = true;
            grp_TraCuDichVu.Visible = true;
            pnl_tiltel2.Visible = true;
            grb_dsdkdv.Visible = true;
            grb_dsdvti.Visible = true;
        }
        private void thêmDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void sửaDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void xóaDịchVụTiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmdmdv == null || frmdmdv.IsDisposed)
            {
                MDI2();
                frmdmdv.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmdmdv.Activate();
            }
        }
        private void frmdmdv_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnl_titel1.Visible = true;
            grp_ThonTinDangKy.Visible = true;
            grp_TraCuDichVu.Visible = true;
            pnl_tiltel2.Visible = true;
            grb_dsdkdv.Visible = true;
            grb_dsdvti.Visible = true;
        }
        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        //-----------------------------------------
                            //&&//
        //-----------------Dashboard---------------
        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
        }
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
            Frm_CanHo canHo = new Frm_CanHo(menu);
            canHo.Show();
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
            MessageBox.Show("Bạn hiện đang ở trang Đăng Ký Dịch Vụ!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);       
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
            this.Close();
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
        public void ThongKe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();

                    // 1. Lấy tổng số đăng ký dịch vụ
                    string sqlDangKy = "SELECT COUNT(*) FROM DangKyDichVu";
                    SqlCommand cmd1 = new SqlCommand(sqlDangKy, conn);
                    lbl_tongdv.Text = cmd1.ExecuteScalar().ToString();

                    // 2. Lấy tổng số dịch vụ hiện có
                    string sqlHienCo = "SELECT COUNT(*) FROM DangKyDichVu";
                    SqlCommand cmd2 = new SqlCommand(sqlHienCo, conn);
                    lbl_ti.Text = cmd2.ExecuteScalar().ToString();

                    // 3. Lấy số dịch vụ đang hoạt động
                    string sqlDangHoatDong = "SELECT COUNT(*) FROM DangKyDichVu WHERE TrangThai = 1";
                    SqlCommand cmd3 = new SqlCommand(sqlDangHoatDong, conn);
                    lbl_tidhd.Text = cmd3.ExecuteScalar().ToString();

                    // 4. Lấy số dịch vụ ngưng hoạt động
                    string sqlNgungHoatDong = "SELECT COUNT(*) FROM DangKyDichVu WHERE TrangThai = 0";
                    SqlCommand cmd4 = new SqlCommand(sqlNgungHoatDong, conn);
                    lbl_tinhd.Text = cmd4.ExecuteScalar().ToString();
                    // 5. Lấy số lượt đăng ký mới (giả sử là trong ngày hôm nay)
                    string sqlMoi = "SELECT COUNT(*) FROM DangKy WHERE CAST(NgayDangKy AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmd5 = new SqlCommand(sqlMoi, conn);

                    // Gán vào Label tương ứng (ví dụ đặt tên là lblDangKyMoi)
                    lbl_dkm.Text = cmd5.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }
        private void frm_Dangkydichvu_Load(object sender, EventArgs e)
        {
         
            Connection ketnoi = new Connection();

            if (ketnoi.moketnoi())
            {
              
                string sql1 = "SELECT * FROM DangKyDichVu";
                SqlDataReader rdr1 = ketnoi.truyvan(sql1);
                DataTable tb1 = new DataTable();
                tb1.Load(rdr1);
                rdr1.Close();

                dgv_ThongTindv.DataSource = tb1;


              
                string sql2 = "SELECT * FROM DichVu";
                SqlDataReader rdr2 = ketnoi.truyvan(sql2);
                DataTable tb2 = new DataTable();
                tb2.Load(rdr2);
                rdr2.Close();

                dataGridView3.DataSource = tb2; 


                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Không thể kết nối CSDL");
            }
        }

        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            void tiemkiem()
            {
                Connection ketnoi = new Connection();
                try
                {
                    if (ketnoi.moketnoi())
                    {
                        string sel = "SELECT MaBaoTri, MaCanHo, MaYeuCau, TrangThai FROM BaoTriSuaChua WHERE 1=1";
                        if (!string.IsNullOrEmpty(txt_mdk.Text.Trim()))
                        {
                            sel += " AND MaBaoTri LIKE N'%" + txt_mdk.Text.Trim() + "%'";
                        }
                        if (!string.IsNullOrEmpty(txt_mch.Text.Trim()))
                        {
                            sel += " AND MaCanHo LIKE N'%" + txt_mch.Text.Trim() + "%'";
                        }
                        if (cbx_tt.SelectedIndex > 0)
                        {
                            string TrangThai = cbx_tt.Text.Split('-')[0].Trim();
                            sel += " AND TrangThai = '" + TrangThai + "'";
                        }
                        if (!string.IsNullOrEmpty(txt_mdv.Text.Trim()))
                        {
                            sel += " AND MaYeuCau LIKE N'%" + txt_mdv.Text.Trim() + "%'";
                        }
                        SqlDataReader rdr = ketnoi.truyvan(sel);
                        DataTable tb = new DataTable();
                        tb.Load(rdr);
                        rdr.Close();
                        dgv_ThongTindv.DataSource = tb;
                        ketnoi.dongketnoi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
        //-----------------------------------------
    
}
