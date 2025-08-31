using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien
{
    internal class LuuTenDangNhap
    {
        public static string tenDangNhap;
    }

    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }

        // Biến tĩnh lưu thông tin sinh viên hiện tại
        public static SinhVien CurrentSinhVien { get; set; }
        
    }

    public class KQSV
    {
        public string MaDT { get; set; }
        public string MaKyThi { get; set; }
        public static KQSV CurrentKQ { get; set; }
    }

}
