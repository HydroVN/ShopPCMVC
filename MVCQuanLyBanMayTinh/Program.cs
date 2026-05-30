using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVCQuanLyBanMayTinh.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký dịch vụ MVC
builder.Services.AddControllersWithViews();

// 2. Cấu hình chuỗi kết nối khớp cơ sở dữ liệu ComputerShopDbContext
builder.Services.AddDbContext<ComputerShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComputerShopDB")));

// 3. Đăng ký cơ chế Cookie Authentication xử lý chặn URL gõ link dẫn thủ công trái phép
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";            // Bị đá về đây nếu chưa đăng nhập
        options.AccessDeniedPath = "/Account/AccessDenied";  // Bị đá về đây nếu đăng nhập bằng tài khoản thường
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// BẮT BUỘC: Middleware bảo mật luồng di chuyển URL
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

// Đăng ký tuyến đường định vị Area Admin độc lập
app.MapAreaControllerRoute(
    name: "adminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Computer}/{action=Index}/{id?}")
    .WithStaticAssets();

// Tuyến đường mặc định công cộng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();