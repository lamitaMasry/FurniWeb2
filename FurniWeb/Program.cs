using FurniWeb.Data;
using FurniWeb.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        // appsettings.json uses a SQLite connection string (Data Source=...).
        // UseSqlite here so the provider matches the configured connection string.
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

// Area routes (Admin)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// Normal MVC routes (Main app)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Seed the database with admin user and initial data
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedAsync(scope.ServiceProvider);
}

app.Run();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Application terminated unexpectedly: {ex.Message}");
    Console.Error.WriteLine($"Details: {ex}");
    Environment.Exit(1);
}

// This error indicates that there is an issue with using the 'Sum' aggregate operator on a 'decimal' type in SQLite. 
// It suggests converting the values to a supported type or using LINQ to Objects to aggregate the results on the client side.
// System.NotSupportedException: SQLite cannot apply aggregate operator 'Sum' on expressions of type 'decimal'. Convert the values to a supported type, or use LINQ to Objects to aggregate the results on the client side.

// InvalidOperationException: RenderBody invocation in '/Areas/Admin/Views/_ViewStart.cshtml' is invalid. RenderBody can only be called from a layout page.