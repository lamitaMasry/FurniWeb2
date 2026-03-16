using FurniWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace FurniWeb.Controllers.Api
{
    [ApiController]
    [Route("api/diagnostics")]
    public class ApiDiagnosticsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ApiDiagnosticsController(ApplicationDbContext db) => _db = db;

        [HttpGet("db")]
        public async Task<IActionResult> Db()
        {
            try
            {
                var canConnect = await _db.Database.CanConnectAsync();
                var provider = _db.Database.ProviderName;

                return Ok(new
                {
                    canConnect,
                    provider
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { canConnect = false, error = ex.Message });
            }
        }
    }
}
