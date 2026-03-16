using FurniWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Shop()
        {
            var products = await _db.Products
                .Where(p => p.IsActive)
                .ToListAsync();
            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
