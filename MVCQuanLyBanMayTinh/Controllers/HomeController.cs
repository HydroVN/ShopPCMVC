using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCQuanLyBanMayTinh.Models;
using MVCQuanLyBanMayTinh.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCQuanLyBanMayTinh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ComputerShopDbContext _context;

        public HomeController(ComputerShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId, string search)
        {
            var query = _context.Computers.Include(c => c.Category).AsQueryable();

            if (categoryId.HasValue) query = query.Where(c => c.Category_Id == categoryId);
            if (!string.IsNullOrEmpty(search)) query = query.Where(c => c.Name.Contains(search) || c.Brand.Contains(search));

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.CurrentCategory = categoryId;
            ViewBag.CurrentSearch = search;

            return View(await query.ToListAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();

            var computer = await _context.Computers.Include(c => c.Category).FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null) return NotFound();

            return View(computer);
        }
    }
}