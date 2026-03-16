using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurniWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /Admin/Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Admin/Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Email and password are required.");
                return View();
            }

            // Find user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // Check if user is admin
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (!isAdmin)
            {
                ModelState.AddModelError(string.Empty, "You do not have admin privileges.");
                return View();
            }

            // Sign in the user
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl ?? "/Admin/Dashboard");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account locked out.");
                return View();
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        // GET: /Admin/Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
