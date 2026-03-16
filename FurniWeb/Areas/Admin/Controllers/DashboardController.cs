using FurniWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var totalProducts = await _db.Products.CountAsync();
            var totalOrders = await _db.Orders.CountAsync();
            
            // SQLite doesn't support Sum on decimal, so we need to fetch data and aggregate in memory
            var orderItems = await _db.OrderItems
                .AsNoTracking()
                .Select(i => new { i.UnitPrice, i.Quantity })
                .ToListAsync();
            
            var totalRevenue = orderItems.Sum(i => i.UnitPrice * i.Quantity);

            // Use ViewBag keys expected by the dashboard view
            ViewBag.ProductsCount = totalProducts;
            ViewBag.OrdersCount = totalOrders;
            ViewBag.Revenue = totalRevenue;

            return View();
        }
    }
}