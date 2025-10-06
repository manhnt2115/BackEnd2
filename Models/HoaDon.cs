using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaKH { get; set; }

        public KhachHang KhachHang { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}