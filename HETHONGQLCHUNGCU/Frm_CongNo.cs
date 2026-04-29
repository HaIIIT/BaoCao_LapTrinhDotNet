using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_CongNo : Form
    {
        private Frm_thongtincongno frmthongtincongno = null;
        public Frm_Menu menu;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        private Frm_TTCongNo_CUDAN frmcongno = null;
        public Frm_CongNo()
        {
            InitializeComponent();          
        }
        public Frm_CongNo(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI()
        {
            AnTatCaFormCon();
            frmthongtincongno = new Frm_thongtincongno();
            frmthongtincongno.MdiParent = this;
            frmthongtincongno.StartPosition = FormStartPosition.Manual;
            frmthongtincongno.Location = new Point(170, 130);
            frmthongtincongno.FormBorderStyle = FormBorderStyle.None;
            frmthongtincongno.FormClosed += frmthongtincongno_FormClosed;
            frmthongtincongno.Show();
        }
        private void ancontrols()
        {
            dgv_dscongno.Visible = false;
            pnl_find.Visible = false;
            pnl_titel.Visible = false;
            pnl_titel2.Visible = false;
        }
        private void hiencontrols()
        {
            dgv_dscongno.Visible = true;
            pnl_find.Visible = true;
            pnl_titel.Visible = true;
            pnl_titel2.Visible = true;
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaCongNo,MaCanHo,MaHoaDon,SoTienNo,NgayPhatSinh,HanNo,TrangThai,GhiChu FROM CongNo WHERE 1=1";
                    if (!string.IsNullOrEmpty(txt_cn.Text.Trim()))
                    {
                        sel += " AND MaCongNo LIKE N'%" + txt_cn.Text.Trim() + "%'";
                    }
                    if (!string.IsNullOrEmpty(txt_ch.Text.Trim()))
                    {
                        sel += " AND MaCanHo LIKE N'%" + txt_ch.Text.Trim() + "%'";
                    }
                    if (cbx_tt.SelectedIndex > 0)
                    {
                        string TrangThai = cbx_tt.Text.Split('-')[0].Trim();
                        sel += " AND TrangThai = N'" +cbx_tt.Text.Trim()+ "'";
                    }
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    DataTable tb = new DataTable();
                    tb.Load(rdr);
                    rdr.Close();
                    dgv_dscongno.DataSource = tb;
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        //----------------MenuStrip---------------------
        private void themcongnotool_Click(object sender, EventArgs e)
        {
            if (frmthongtincongno == null || frmthongtincongno.IsDisposed)
            {
                MDI();
                frmthongtincongno.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmthongtincongno.Activate();
            }
        }
        private void suattcongnotool_Click(object sender, EventArgs e)
        {
            if (frmthongtincongno == null || frmthongtincongno.IsDisposed)
            {
                MDI();
                frmthongtincongno.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmthongtincongno.Activate();
            }
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtincongno == null || frmthongtincongno.IsDisposed)
            {
                MDI();
                frmthongtincongno.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
            else
            {
                frmthongtincongno.Activate();
            }
        }
        private void frmthongtincongno_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hiện contorls
            hiencontrols();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu != null)
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
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmcongno != null && !frmcongno.IsDisposed)
                    {
                        frmcongno.Hide();
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
                if (frmcongno != null && !frmcongno.IsDisposed)
                {
                    frmcongno.Show();
                    frmcongno.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                hiencontrols();
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
                if (cls_chcecklogin.Quyen == 6)
                {
                    if (frmcongno != null && !frmcongno.IsDisposed)
                    {
                        frmcongno.Hide();
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
                if (frmcongno != null && !frmcongno.IsDisposed)
                {
                    frmcongno.Show();
                    frmcongno.BringToFront();
                }
            }
            else
            {
                hiencontrols();
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
            MessageBox.Show("Bạn đang ở trang Công Nợ!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongketc = new Frm_ThongKeTaiChinh(menu);
            thongketc.Show();
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
        private void btn_bangphancong_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpcnv = new Frm_BPCNV(menu);
            bpcnv.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //-----------------------------
        private void Frm_CongNo_Load(object sender, EventArgs e)
        {
            btn_load.Visible = false;
            cbx_tt.Items.Clear();
            cbx_tt.Items.Add("--Chọn Trạng Thái--");
            cbx_tt.Items.Add("Đã Tất Toán");
            cbx_tt.Items.Add("Chưa Thanh Toán");
            cbx_tt.Items.Add("Quá Hạn");
            cbx_tt.SelectedIndex = 0;
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 6)
            {
                PhanQuyenDashboard.tat(btn_chamcong, btn_bpcnv, btn_dgns, btn_thongketc, btn_btsc);
                quảnLýCôngNợToolStripMenuItem.Visible = false;
                AnTatCaFormCon();
                frmcongno = new Frm_TTCongNo_CUDAN();
                frmcongno.MdiParent = this;
                frmcongno.StartPosition = FormStartPosition.Manual;
                frmcongno.Location = new Point(220, 130);
                frmcongno.FormBorderStyle = FormBorderStyle.None;
                frmcongno.Show();
                //ẩn contorls
                ancontrols();
            }
            else if (quyen == 7)
            {
                //null
            }
            else if (quyen == 4)
            {
                PhanQuyenDashboard.tat(btn_cudan, btn_canho, btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            } 
                Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaCongNo,MaCanHo,MaHoaDon,SoTienNo,NgayPhatSinh,HanNo,TrangThai,GhiChu FROM CongNo";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                dgv_dscongno.DataSource = tb;
                rdr.Close();
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("Khong the ket noi CSDL");
            }
        }
        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            if (txt_cn.Text.Trim() == "" && txt_ch.Text.Trim() == "" && cbx_tt.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Frm_CongNo_Load(sender, e);
            txt_ch.Clear();
            txt_cn.Clear();
            cbx_tt.SelectedIndex = 0;
        }        
    }
}
