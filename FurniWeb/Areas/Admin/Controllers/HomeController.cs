using Microsoft.AspNetCore.Mvc;

namespace FurniWeb.Controllers;

public class HomeController : Controller
{
    // ✅ redirect MVC homepage to real static template
    public IActionResult Index() => Redirect("/");

    // optional convenience routes
    public IActionResult Shop() => Redirect("/shop.html");
    public IActionResult Contact() => Redirect("/contact.html");
}
