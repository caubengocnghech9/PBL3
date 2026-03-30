using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Bắt buộc phải có dòng này để dùng được Session
using PBL3.Models; // Gọi Database của bạn

namespace PBL3.Controllers
{
    public class HomeController : Controller
    {
        // 1. MỞ TRANG ĐĂNG NHẬP
        public IActionResult Index()
        {
            return View();
        }

        // 2. XỬ LÝ NÚT BẤM ĐĂNG NHẬP
        [HttpPost]
        public IActionResult XulyDangNhap(string role, string username, string password)
        {
            using (var db = new QuanLyThuVienContext())
            {
                if (role == "admin")
                {
                    var admin = db.TaiKhoanNhanViens.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhau == password);
                    if (admin != null)
                    {
                        // Cấp thẻ bài (Session)
                        HttpContext.Session.SetString("TenDangNhap", admin.TenDangNhap);
                        HttpContext.Session.SetString("VaiTro", "Admin");

                        return RedirectToAction("TrangAdmin", "Home"); // Chuyển trang
                    }
                }
                else if (role == "user")
                {
                    var user = db.TaiKhoanDocGia.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhau == password);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
                        HttpContext.Session.SetString("VaiTro", "User");

                        return RedirectToAction("TrangChuUser", "Home");
                    }
                }
            }

            // Gói câu thông báo vào TempData và quay xe về lại trang Đăng nhập (Index)
            TempData["Error"] = "Sai tài khoản hoặc mật khẩu!";
            return RedirectToAction("Index", "Home");
        }

        // 3. MỞ TRANG ADMIN (CÓ BẢO VỆ)
        public IActionResult TrangAdmin()
        {
            // Nếu không có thẻ bài Admin -> Đá văng ra ngoài
            if (HttpContext.Session.GetString("VaiTro") != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // 4. MỞ TRANG USER (CÓ BẢO VỆ)
        public IActionResult TrangChuUser()
        {
            if (HttpContext.Session.GetString("VaiTro") != "User")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // 5. NÚT ĐĂNG XUẤT
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear(); // Xé bỏ thẻ bài
            return RedirectToAction("Index", "Home"); // Quay về trang chủ
        }
        // MỞ TRANG ĐĂNG KÝ
        public IActionResult DangKy()
        {
            return View();
        }


    }

    }
