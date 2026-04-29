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
    public partial class Frm_ChamCong : Form
    {
        private Frm_CCcs Frm_CCcs = null;
        private Frm_htchamcong frmchamcong = null;
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_NhanSu frmns = null;
        public Frm_ChamCong()
        {
            InitializeComponent();
        }
        public Frm_ChamCong(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void AnTatCaFormCon()
        {
            if (Frm_CCcs != null && !Frm_CCcs.IsDisposed)
                Frm_CCcs.Hide();
            if (frmchamcong != null && !frmchamcong.IsDisposed)
                frmchamcong.Hide();
        }
        private void MDI()
        {
            AnTatCaFormCon();
            Frm_CCcs = new Frm_CCcs();
            Frm_CCcs.MdiParent = this;
            Frm_CCcs.StartPosition = FormStartPosition.Manual;
            Frm_CCcs.Location = new Point(175, 150);
            Frm_CCcs.FormBorderStyle = FormBorderStyle.None;
            Frm_CCcs.FormClosed += Frm_CCcs_FormClosed;
            Frm_CCcs.Show();
        }
        private void ancontrols()
        {
            gpb_trangthai.Visible = false;
            pnlTTCC.Visible = false;
            gbxTTCC.Visible = false;
            pnlDSCC.Visible = false;
            dgvDSCC.Visible = false;
        }
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        //----------------MenuStrip---------------------
        private void thêmThôngTinThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }                      
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }
        }
        private void capnhatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_CCcs == null || Frm_CCcs.IsDisposed)
            {
                MDI();
                Frm_CCcs.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_CCcs.Activate();
            }
        }
        private void Frm_CCcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_CCcs = null;
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 2)
            {
                ancontrols();
                Frm_ChamCong_Load(sender, e);
            }
            gpb_trangthai.Visible = true;
            pnlTTCC.Visible = true;
            gbxTTCC.Visible = true;
            pnlDSCC.Visible = true;
            dgvDSCC.Visible = true;
            Frm_ChamCong_Load(sender, e);
        }
        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmchamcong == null || frmchamcong.IsDisposed)
            {
                AnTatCaFormCon();
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
            }
            else
            {
                frmchamcong.Activate();
            }         
        }
        private void Frm_htchamcong_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmchamcong = null;
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 2)
            {
                ancontrols();
                Frm_ChamCong_Load(sender, e);
            }
            else
            {
                gpb_trangthai.Visible = true;
                pnlTTCC.Visible = true;
                gbxTTCC.Visible = true;
                pnlDSCC.Visible = true;
                dgvDSCC.Visible = true;
                Frm_ChamCong_Load(sender, e);
            }
        }
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
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
            if (cls_chcecklogin.Quyen == 2)
            {
                AnTatCaFormCon();
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
                ancontrols();
                Frm_ChamCong_Load(sender, e);
            }
            else
            {
                // hiển thị controls
                gpb_trangthai.Visible = true;
                pnlTTCC.Visible = true;
                gbxTTCC.Visible = true;
                pnlDSCC.Visible = true;
                dgvDSCC.Visible = true;
                Frm_ChamCong_Load(sender, e);
            }
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
            if (cls_chcecklogin.Quyen ==2)
            {
                AnTatCaFormCon();
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
                Frm_ChamCong_Load(sender, e);
            }
            else
            {
                gpb_trangthai.Visible = true;
                pnlTTCC.Visible = true;
                gbxTTCC.Visible = true;
                pnlDSCC.Visible = true;
                dgvDSCC.Visible = true;
                Frm_ChamCong_Load(sender, e);
            }
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
            Frm_ThongKeTaiChinh thongKe = new Frm_ThongKeTaiChinh(menu);
            thongKe.Show();
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
            MessageBox.Show("Bạn đang ở trang chấm công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //---------------------
        private void Frm_ChamCong_Load(object sender, EventArgs e)
        {
            btn_load.Visible = false;
            LoadThongKe();
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 2)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                    btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
                quảnLýChamCongToolStripMenuItem.Visible = false;
                quảnLýNhâACnSựToolStripMenuItem.Visible = false;
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
                ancontrols();
            }
            else if (quyen == 3)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            }else if (quyen == 7)
            {
                //null
            }

            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                // Lấy danh sách chấm công
                string sel = "SELECT MaChamCong, MaNhanSu, NgayCham, GioVao, GioRa, TrangThai, SoGioLam, GhiChu FROM ChamCong";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                dgvDSCC.DataSource = tb;
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Không thể kết nối CSDL để lấy danh sách!");
            }
        }
        private int LayGiaTriDon(string sql, Connection kn)
        {
            int ketqua = 0;
            SqlDataReader dr = kn.truyvan(sql);
            if (dr.Read())
            {
                ketqua = int.Parse(dr[0].ToString());
            }
            dr.Close();
            return ketqua;
        }
        private void LoadThongKe()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                try
                {
                    // 1. Lấy tổng số nhân sự
                    string sqlTongNS = "SELECT COUNT(*) FROM NhanSu";
                    int tongNS = LayGiaTriDon(sqlTongNS, ketnoi);
                    // 2. Lấy số nhân sự đã chấm công hôm nay
                    string sqlDaCham = "SELECT COUNT(DISTINCT MaNhanSu) FROM ChamCong WHERE NgayCham = CAST(GETDATE() AS DATE)";
                    int daCham = LayGiaTriDon(sqlDaCham, ketnoi);
                    // 3. Gán giá trị lên Label (Đảm bảo ID Label trên Form trùng với ở đây)
                    lbl_1.Text = tongNS.ToString();
                    lbl_2.Text = daCham.ToString();
                    lbl_3.Text = (tongNS - daCham).ToString();
                    // Nếu bạn có label "Tổng số nhân viên chấm công trong ngày", dùng luôn daCham
                    lbl_4.Text = daCham.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thống kê: " + ex.Message);
                }
                finally
                {
                    ketnoi.dongketnoi();
                }
            }

        }
        void tiemkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaChamCong, MaNhanSu, NgayCham, GioVao, GioRa, TrangThai, SoGioLam, GhiChu FROM ChamCong WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_mcc.Text.Trim()))
                    {
                        sel += " AND MaChamCong LIKE N'%" + txt_mcc.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_mns.Text.Trim()))
                    {
                        sel += " AND MaNhanSu LIKE N'%" + txt_mns.Text.Trim() + "%'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgvDSCC.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_tk_Click(object sender, EventArgs e)
        {
            if (txt_mcc.Text.Trim() == "" && txt_mns.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tiemkiem();
                btn_load.Visible = true;
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            Frm_ChamCong_Load(sender, e);
        }

        private void quảnLýNhâACnSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmns == null || frmns.IsDisposed)
            {
                AnTatCaFormCon();
                frmns = new Frm_NhanSu();
                frmns.MdiParent = this;
                frmns.StartPosition = FormStartPosition.Manual;
                frmns.Location = new Point(180, 95);
                frmns.FormBorderStyle = FormBorderStyle.None;
                frmns.FormClosed += Frm_NhanSu_FormClosed;
                if (cls_chcecklogin.Quyen == 6)
                {

                }
                else
                {
                    ancontrols();
                }
                frmns.Show();
            }
            else
            {
                frmns.Activate();
            }
        }
        private void Frm_NhanSu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmns = null;
            if (cls_chcecklogin.Quyen == 2)
            {
                AnTatCaFormCon();
                frmchamcong = new Frm_htchamcong();
                frmchamcong.MdiParent = this;
                frmchamcong.StartPosition = FormStartPosition.Manual;
                frmchamcong.Location = new Point(310, 190);
                frmchamcong.FormBorderStyle = FormBorderStyle.None;
                frmchamcong.FormClosed += Frm_CCcs_FormClosed;
                frmchamcong.Show();
                ancontrols();
                ancontrols();
                Frm_ChamCong_Load(sender, e);
            }
            else
            {
                // hiển thị controls
                gpb_trangthai.Visible = true;
                pnlTTCC.Visible = true;
                gbxTTCC.Visible = true;
                pnlDSCC.Visible = true;
                dgvDSCC.Visible = true;
                Frm_ChamCong_Load(sender, e);
            }
        }
    }
}
