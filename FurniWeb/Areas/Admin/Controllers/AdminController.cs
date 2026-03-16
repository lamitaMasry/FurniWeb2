using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurniWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [HttpGet("/admin")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            // If not logged in -> go to admin login
            if (!User.Identity?.IsAuthenticated ?? true)
                return Redirect("/Admin/Account/Login");

            // If logged in but not admin -> show error
            if (!User.IsInRole("Admin"))
                return Forbid();

            // If logged in and is admin -> go to admin dashboard
            return Redirect("/Admin/Dashboard");
        }
    }
}