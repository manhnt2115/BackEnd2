using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001230507_NhanTuManh_B5.DAL;
using _2001230507_NhanTuManh_B5.Models;

namespace _2001230507_NhanTuManh_B5.Controllers
{
    public class SanPhamController : Controller
    {
        private SanPhamDAL spDAL = new SanPhamDAL();
        private LoaiDAL loaiDAL = new LoaiDAL();

        // GET: /SanPham/
        public ActionResult Index()
        {
            if (Session["TenDangNhap"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            List<SanPham> dsSanPham = spDAL.GetAllSanPham();  
            return View(dsSanPham);                           
        }

        // GET: /SanPham/Details/5
        public ActionResult Details(int id)
        {
            SanPham sp = spDAL.GetSanPhamById(id);
            if (sp == null)
                return HttpNotFound();

            return View(sp);
        }
        public ActionResult TimKiem(int? maLoai, int? giaTu, int? giaDen)
        {
            ViewBag.DanhSachLoai = new SelectList(loaiDAL.GetAllLoai(), "MaLoai", "TenLoai");
            var ketQua = spDAL.TimKiemSanPham(maLoai, giaTu, giaDen);
            return View(ketQua);
        }


    }
}