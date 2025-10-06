using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }

        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
    }

}