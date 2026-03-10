using FurniWeb.Data;
using FurniWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FurniWeb.Seeding;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider sp)
    {
        var db = sp.GetRequiredService<ApplicationDbContext>();
        
        // Admin user + role
        var userMgr = sp.GetRequiredService<UserManager<IdentityUser>>();
        var roleMgr = sp.GetRequiredService<RoleManager<IdentityRole>>();

        const string adminRole = "Admin";
        
        if (!await roleMgr.RoleExistsAsync(adminRole))
        {
            await roleMgr.CreateAsync(new IdentityRole(adminRole));
        }

        var email = "admin@furni.com";
        var pass = "Admin@12345";

        var admin = await userMgr.FindByEmailAsync(email);
        if (admin == null)
        {
            admin = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
            await userMgr.CreateAsync(admin, pass);
        }

        if (!await userMgr.IsInRoleAsync(admin, adminRole))
            await userMgr.AddToRoleAsync(admin, adminRole);

        // Products seed
        if (!await db.Products.AnyAsync())
        {
            db.Products.AddRange(
                new Product { Name = "Nordic Chair", Price = 50, ImagePath = "/images/product-1.png", IsActive = true },
                new Product { Name = "Kruzo Aero Chair", Price = 78, ImagePath = "/images/product-2.png", IsActive = true },
                new Product { Name = "Ergonomic Chair", Price = 43, ImagePath = "/images/product-3.png", IsActive = true }
            );
            await db.SaveChangesAsync();
        }
    }
}