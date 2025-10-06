using _2001230507_NhanTuManh_B5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001230507_NhanTuManh_B5.Controllers
{
    public class TaiKhoanController : Controller
    {
        private TaiKhoanDAL tkDAL = new TaiKhoanDAL();

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string TenDangNhap, string MatKhau)
        {
            if (tkDAL.KiemTraDangNhap(TenDangNhap, MatKhau))
            {
                Session["TenDangNhap"] = TenDangNhap; 
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                ViewBag.LoiDangNhap = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}