using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Models
{
    public class NhaSanXuat
    {
        public int MaNSX { get; set; }
        public string TenNSX { get; set; }

        public List<SanPham> DanhSachSanPham { get; set; }
    }

}