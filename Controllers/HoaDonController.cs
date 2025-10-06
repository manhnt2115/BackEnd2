using _2001230507_NhanTuManh_B5.DAL;
using _2001230507_NhanTuManh_B5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Controllers
{
    public class HoaDonController : Controller
    {
        private HoaDonDAL hdDAL = new HoaDonDAL();

        public ActionResult LichSuGiaoDich()
        {
            if (Session["KhachHang"] == null)
                return RedirectToAction("DangNhap", "KhachHang");

            var kh = (KhachHang)Session["KhachHang"];
            var hoaDonList = hdDAL.GetHoaDonByKhachHang(kh.MaKH);

            return View(hoaDonList);
        }

    }
}