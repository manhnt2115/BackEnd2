using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }  // Nếu có cột mật khẩu trong CSDL

        public List<HoaDon> DanhSachHoaDon { get; set; }
    }
}