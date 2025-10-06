using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSP { get; set; }
        public int MaLoai { get; set; }
        public int MaNSX { get; set; }
        public decimal Gia { get; set; }
        public string GhiChu { get; set; }
        public string Hinh { get; set; }

    }
}