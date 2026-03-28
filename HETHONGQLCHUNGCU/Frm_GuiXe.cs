using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_GuiXe : Form
    {
        // Danh sách lưu tạm dữ liệu
        private List<GuiXe> dsGuiXe = new List<GuiXe>();

        public Frm_GuiXe()
        {
            InitializeComponent();
        }

        private void Frm_GuiXe_Load(object sender, EventArgs e)
        {
            CaiDatBanDau();
            TaoDuLieuMau();
            HienThiDanhSach();
            LamMoiForm();
        }

        private void CaiDatBanDau()
        {
    
        }

        private void TaoDuLieuMau()
        {
            dsGuiXe.Add(new GuiXe
            {
                MaGui = "MG001",
                MaXe = "XE001",
                MaViTri = "VT001",
                NgayBatDau = DateTime.Today,
                NgayKetThuc = DateTime.Today.AddMonths(1),
                PhiGui = 100000,
                TrangThai = "Hiệu lực"
            });

            dsGuiXe.Add(new GuiXe
            {
                MaGui = "MG002",
                MaXe = "XE002",
                MaViTri = "VT002",
                NgayBatDau = DateTime.Today,
                NgayKetThuc = DateTime.Today.AddMonths(2),
                PhiGui = 200000,
                TrangThai = "Hiệu lực"
            });
        }

        private void HienThiDanhSach()
        {
      
           
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txt_MaGui.Text))
            {
                MessageBox.Show("Vui lòng nhập mã gửi xe.");
                txt_MaGui.Focus();
                return false;
            }

            if (cbx_MaXe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã xe.");
                cbx_MaXe.Focus();
                return false;
            }

            if (cbx_MaViTri.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã vị trí.");
                cbx_MaViTri.Focus();
                return false;
            }

            if (cbx_TrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                cbx_TrangThai.Focus();
                return false;
            }

            decimal phi;
            if (!decimal.TryParse(txt_PhiGui.Text.Trim(), out phi) || phi < 0)
            {
                MessageBox.Show("Phí gửi không hợp lệ.");
                txt_PhiGui.Focus();
                return false;
            }

            if (dtp_KetThuc.Value.Date < dtp_BatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.");
                dtp_KetThuc.Focus();
                return false;
            }

            return true;
        }

        private void LamMoiForm()
        {
            txt_MaGui.Clear();
            txt_PhiGui.Clear();

            if (cbx_MaXe.Items.Count > 0) cbx_MaXe.SelectedIndex = -1;
            if (cbx_MaViTri.Items.Count > 0) cbx_MaViTri.SelectedIndex = -1;
            if (cbx_TrangThai.Items.Count > 0) cbx_TrangThai.SelectedIndex = 0;

            dtp_BatDau.Value = DateTime.Today;
            dtp_KetThuc.Value = DateTime.Today;

            txt_MaGui.Focus();
            
        }

        private int TimViTriTheoMaGui(string maGui)
        {
            for (int i = 0; i < dsGuiXe.Count; i++)
            {
                if (dsGuiXe[i].MaGui.Equals(maGui, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maGui = txt_MaGui.Text.Trim();

            if (TimViTriTheoMaGui(maGui) != -1)
            {
                MessageBox.Show("Mã gửi xe đã tồn tại.");
                txt_MaGui.Focus();
                return;
            }

            GuiXe gx = new GuiXe
            {
                MaGui = maGui,
                MaXe = cbx_MaXe.Text,
                MaViTri = cbx_MaViTri.Text,
                NgayBatDau = dtp_BatDau.Value.Date,
                NgayKetThuc = dtp_KetThuc.Value.Date,
                PhiGui = decimal.Parse(txt_PhiGui.Text.Trim()),
                TrangThai = cbx_TrangThai.Text
            };

            dsGuiXe.Add(gx);
            HienThiDanhSach();
            LamMoiForm();

            MessageBox.Show("Thêm thành công.");
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maGui = txt_MaGui.Text.Trim();
            int viTri = TimViTriTheoMaGui(maGui);

            if (viTri == -1)
            {
                MessageBox.Show("Không tìm thấy mã gửi xe để sửa.");
                return;
            }

            dsGuiXe[viTri].MaXe = cbx_MaXe.Text;
            dsGuiXe[viTri].MaViTri = cbx_MaViTri.Text;
            dsGuiXe[viTri].NgayBatDau = dtp_BatDau.Value.Date;
            dsGuiXe[viTri].NgayKetThuc = dtp_KetThuc.Value.Date;
            dsGuiXe[viTri].PhiGui = decimal.Parse(txt_PhiGui.Text.Trim());
            dsGuiXe[viTri].TrangThai = cbx_TrangThai.Text;

            HienThiDanhSach();
            LamMoiForm();

            MessageBox.Show("Sửa thành công.");
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string maGui = txt_MaGui.Text.Trim();
            int viTri = TimViTriTheoMaGui(maGui);

            if (viTri == -1)
            {
                MessageBox.Show("Không tìm thấy mã gửi xe để xóa.");
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa bản ghi này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                dsGuiXe.RemoveAt(viTri);
                HienThiDanhSach();
                LamMoiForm();
                MessageBox.Show("Xóa thành công.");
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void dgv_GuiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;



       
        }

        private void txt_PhiGui_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class GuiXe
    {
        public string MaGui { get; set; }
        public string MaXe { get; set; }
        public string MaViTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal PhiGui { get; set; }
        public string TrangThai { get; set; }
    }
}