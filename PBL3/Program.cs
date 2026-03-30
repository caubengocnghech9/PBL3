using PBL3.Models; // Gọi thư mục Models của bạn

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm dịch vụ MVC (Bắt buộc phải có để chạy web)
builder.Services.AddControllersWithViews();

// 2. KÍCH HOẠT BỘ NHỚ SESSION (Thẻ bài đăng nhập)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tự động đăng xuất sau 30 phút
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Cấu hình luồng chạy của ứng dụng (Middleware Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 3. CHO PHÉP ĐỌC THƯ MỤC WWWROOT (Bắt buộc để chạy được CSS, JS, Hình ảnh)
app.UseStaticFiles();

app.UseRouting();

// 4. KHỞI ĐỘNG SESSION (Bắt buộc phải nằm GIỮA UseRouting và UseAuthorization)
app.UseSession();

app.UseAuthorization();

// 5. CẤU HÌNH ĐƯỜNG DẪN MẶC ĐỊNH LÀ TRANG INDEX (Đăng nhập)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();