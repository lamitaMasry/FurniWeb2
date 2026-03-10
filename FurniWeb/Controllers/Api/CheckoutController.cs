using FurniWeb.Data;
using FurniWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Controllers.Api
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CheckoutController(ApplicationDbContext db) => _db = db;

        public record CartItem(int ProductId, int Quantity);

        public record CheckoutRequest(
            string FirstName,
            string LastName,
            string Email,
            string Phone,
            string Country,
            string Address1,
            string? Address2,
            string State,
            string Zip,
            string? OrderNotes,
            List<CartItem> Items
        );

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CheckoutRequest req)
        {
            // Validation (required fields)
            if (string.IsNullOrWhiteSpace(req.FirstName)) return BadRequest("First name required");
            if (string.IsNullOrWhiteSpace(req.LastName)) return BadRequest("Last name required");
            if (string.IsNullOrWhiteSpace(req.Email)) return BadRequest("Email required");
            if (string.IsNullOrWhiteSpace(req.Phone)) return BadRequest("Phone required");
            if (string.IsNullOrWhiteSpace(req.Country)) return BadRequest("Country required");
            if (string.IsNullOrWhiteSpace(req.Address1)) return BadRequest("Address required");
            if (string.IsNullOrWhiteSpace(req.State)) return BadRequest("State required");
            if (string.IsNullOrWhiteSpace(req.Zip)) return BadRequest("Zip required");
            if (req.Items == null || req.Items.Count == 0) return BadRequest("Cart is empty");

            var ids = req.Items.Select(i => i.ProductId).Distinct().ToList();

            var products = await _db.Products
                .Where(p => ids.Contains(p.Id) && p.IsActive)
                .ToDictionaryAsync(p => p.Id);

            foreach (var it in req.Items)
            {
                if (it.Quantity <= 0) return BadRequest("Invalid quantity");
                if (!products.ContainsKey(it.ProductId)) return BadRequest($"Product not found: {it.ProductId}");
            }

            var order = new Order
            {
                CreatedAtUtc = DateTime.UtcNow,
                FirstName = req.FirstName.Trim(),
                LastName = req.LastName.Trim(),
                Email = req.Email.Trim(),
                Phone = req.Phone.Trim(),
                Country = req.Country.Trim(),
                Address1 = req.Address1.Trim(),
                Address2 = string.IsNullOrWhiteSpace(req.Address2) ? null : req.Address2.Trim(),
                State = req.State.Trim(),
                Zip = req.Zip.Trim(),
                OrderNotes = string.IsNullOrWhiteSpace(req.OrderNotes) ? null : req.OrderNotes.Trim()
            };

            foreach (var it in req.Items)
            {
                var p = products[it.ProductId];

                order.Items.Add(new OrderItem
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Quantity = it.Quantity,
                    UnitPrice = p.Price
                });
            }

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return Ok(new { orderId = order.Id, total = order.TotalAmount });
        }
    }
}