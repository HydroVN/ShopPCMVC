using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCQuanLyBanMayTinh.Models;
using MVCQuanLyBanMayTinh.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVCQuanLyBanMayTinh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "1")] // Chỉ tài khoản mang chuỗi Role "1" từ bảng Roles mới được phép gõ link truy cập trực tiếp
    public class ComputerController : Controller
    {
        private readonly ComputerShopDbContext _context;

        public ComputerController(ComputerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Computers.Include(c => c.Category).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category_Id = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Price,Quantity,Image,Description,Category_Id")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                computer.Created_At = DateTime.Now;
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category_Id = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", computer.Category_Id);
            return View(computer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var computer = await _context.Computers.FindAsync(id);
            if (computer == null) return NotFound();

            ViewBag.Category_Id = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", computer.Category_Id);
            return View(computer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Price,Quantity,Image,Description,Category_Id,Created_At")] Computer computer)
        {
            if (id != computer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Computers.Any(e => e.Id == computer.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category_Id = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", computer.Category_Id);
            return View(computer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer != null)
            {
                _context.Computers.Remove(computer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}