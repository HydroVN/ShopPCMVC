using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity; // Hasher chính thống của Microsoft
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCQuanLyBanMayTinh.Models;
using MVCQuanLyBanMayTinh.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCQuanLyBanMayTinh.Controllers
{
    public class AccountController : Controller
    {
        private readonly ComputerShopDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountController(ComputerShopDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user != null)
                {
                    var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        string roleClaimValue = user.Role_Id.ToString();

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim("FullName", user.FullName),
                            new Claim(ClaimTypes.Role, roleClaimValue)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        if (user.Role_Id == 1) return RedirectToAction("Index", "Computer", new { area = "Admin" });
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Tài khoản đăng nhập hoặc mật khẩu bảo mật không chính xác.");
            }
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password,FullName")] User user)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Tên tài khoản đăng nhập này đã tồn tại.");
                    return View(user);
                }

                user.Password = _passwordHasher.HashPassword(user, user.Password);
                user.Role_Id = 2; // Mặc định tự đăng ký là Client (2)
                user.Created_At = DateTime.Now;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();
    }
}