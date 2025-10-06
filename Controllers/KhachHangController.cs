using System.Web.Mvc;
using _2001230507_NhanTuManh_B5.Models; // nếu bạn có model KhachHang

namespace _2001230507_NhanTuManh_B5.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string username, string password)
        {
            // TODO: Thay bằng logic kiểm tra đăng nhập thật sự
            if (username == "admin" && password == "123")
            {
                // Lưu thông tin đăng nhập vào session
                Session["UserName"] = username;
                // Chuyển đến trang danh sách sản phẩm (hoặc trang chủ)
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
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
