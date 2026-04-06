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
            if (HttpContext.Session.GetString("VaiTro") != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new QuanLyThuVienContext())
            {
                // 1. Lấy toàn bộ sách bỏ vào túi "DanhSachSach"
                ViewBag.DanhSachSach = db.Saches.ToList();

                // 2. Lấy toàn bộ độc giả bỏ vào túi "DanhSachDocGia"
                ViewBag.DanhSachDocGia = db.DocGia.ToList();

                // Trả về giao diện (không cần truyền Model vào trong ngoặc nữa)
                return View();
            }
        }

        // 4. MỞ TRANG USER (CÓ BẢO VỆ)
        public IActionResult TrangChuUser()
        {
            if (HttpContext.Session.GetString("VaiTro") != "User")
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy tên đăng nhập (SĐT) đang lưu trong thẻ bài
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

            using (var db = new QuanLyThuVienContext())
            {
                // 1. Lấy danh sách Sách cho Tab 1 (Như cũ)
                var danhSachSach = db.Saches.ToList();

                // 2. Đi tìm Độc giả đang đăng nhập
                var taiKhoan = db.TaiKhoanDocGia.FirstOrDefault(t => t.TenDangNhap == tenDangNhap);
                if (taiKhoan != null)
                {
                    // Lấy thông tin cá nhân từ bảng DocGia
                    var docGia = db.DocGia.FirstOrDefault(d => d.MaDg == taiKhoan.MaDg);
                    ViewBag.ThongTinCaNhan = docGia;

                    // Nếu có thông tin, lấy luôn lịch sử mượn trả của người này
                    if (docGia != null)
                    {
                        var lichSuMuon = db.PhieuMuons.Where(p => p.MaDg == docGia.MaDg).ToList();
                        ViewBag.LichSuMuon = lichSuMuon;
                    }
                }

                return View(danhSachSach);
            }
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
        // 1. TRANG PHIẾU MƯỢN CỦA TÔI
        public IActionResult PhieuMuon()
        {
            if (HttpContext.Session.GetString("VaiTro") != "User") return RedirectToAction("Index", "Home");
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

            using (var db = new QuanLyThuVienContext())
            {
                var taiKhoan = db.TaiKhoanDocGia.FirstOrDefault(t => t.TenDangNhap == tenDangNhap);
                if (taiKhoan != null)
                {
                    var lichSuMuon = db.PhieuMuons.Where(p => p.MaDg == taiKhoan.MaDg).ToList();
                    return View(lichSuMuon);
                }
                return View(new List<PhieuMuon>());
            }
        }

        // 2. TRANG THÔNG TIN CÁ NHÂN
        public IActionResult ThongTinCaNhan()
        {
            if (HttpContext.Session.GetString("VaiTro") != "User") return RedirectToAction("Index", "Home");
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

            using (var db = new QuanLyThuVienContext())
            {
                var taiKhoan = db.TaiKhoanDocGia.FirstOrDefault(t => t.TenDangNhap == tenDangNhap);
                if (taiKhoan != null)
                {
                    var docGia = db.DocGia.FirstOrDefault(d => d.MaDg == taiKhoan.MaDg);
                    return View(docGia);
                }
                return View();
            }
        }


    }

    }
