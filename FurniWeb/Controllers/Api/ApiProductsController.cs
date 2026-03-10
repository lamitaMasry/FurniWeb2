using FurniWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Controllers.Api
{
    [ApiController]
    [Route("api/products")]
    public class ApiProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ApiProductsController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _db.Products
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    price = p.Price,
                    imagePath = p.ImagePath,
                    imageUrl = p.ImageUrl
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}