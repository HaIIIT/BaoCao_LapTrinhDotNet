using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETHONGQLCHUNGCU
{
    public static class cls_chcecklogin
    {
        public static bool DaDangNhap = false;
        public static string TenDangNhap = "";
        public static string TenHienThi = "";
        public static int Quyen = 0;
        public static string MaCuDan = "";
        public static string MaNhanVien = "";
        public static void DangXuat()
        {
            DaDangNhap = false;
            TenDangNhap = "";
            TenHienThi = "";
            Quyen = 0;
            MaCuDan = "";
            MaNhanVien = "";
        }
    }
}
