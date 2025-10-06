using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class Loai
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public List<SanPham> DanhSachSanPham { get; set; }
    }
}