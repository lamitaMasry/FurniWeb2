using FurniWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrdersController(ApplicationDbContext db) => _db = db;

        // ViewModel used by the Orders page
        public class AdminOrderVm
        {
            public int Id { get; set; }
            public DateTime CreatedAtUtc { get; set; }
            // Keep raw name parts so views that reference FirstName/LastName continue to work
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
            public string Phone { get; set; } = "";
            public decimal Total { get; set; }
            public List<AdminOrderItemVm> Items { get; set; } = new();
        }

        public class AdminOrderItemVm
        {
            public string ProductName { get; set; } = "";
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _db.Orders
                .Include(o => o.Items)
                .AsNoTracking()
                .OrderByDescending(o => o.CreatedAtUtc)
                .ToListAsync();

            var list = orders.Select(o => new AdminOrderVm
            {
                Id = o.Id,
                CreatedAtUtc = o.CreatedAtUtc,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Name = (o.FirstName + " " + o.LastName).Trim(),
                Email = o.Email,
                Phone = o.Phone,
                Total = o.TotalAmount,
                Items = o.Items.Select(i => new AdminOrderItemVm
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            }).ToList();

            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _db.Orders
                .Include(o => o.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }
    }
}