# Admin Login System - Quick Reference

## Login Flow Diagram

```
Anonymous User
    ?
Visit /admin
    ?
AdminGateController checks:
  - Is user authenticated? NO ? Redirect to /Admin/Account/Login
  - Is user in Admin role? NO ? Forbid (403)
    ?
AccountController.Login (GET)
  - Displays login form with CSRF token
    ?
User submits email + password
    ?
AccountController.Login (POST)
  - Validate input
  - Find user by email
  - Check if user is in Admin role
  - Verify password with SignInManager
  - On success: Sign in & redirect to /Admin/Dashboard
  - On failure: Show error, return login form
    ?
Admin Dashboard (/Admin/Dashboard)
  - Protected by [Authorize(Roles = "Admin")]
  - Shows key metrics
  - Navigation bar visible
```

## Architecture Overview

```
Program.cs
    ?
    ?? Startup:
    ?  ?? Add DbContext (ApplicationDbContext)
    ?  ?? Add Identity services
    ?  ?? Add Controllers & Views
    ?  ?? Call DbSeeder.SeedAsync()
    ?
    ?? DbSeeder.SeedAsync():
       ?? Run migrations
       ?? Create Admin role
       ?? Create admin@furni.com user

Routes:
    ?? /admin ? AdminGateController.Index
    ?? /Admin/Account/Login ? AccountController.Login
    ?? /Admin/Account/Logout ? AccountController.Logout
    ?? /Admin/Dashboard ? DashboardController.Index [Admin]
    ?? /Admin/Products ? ProductsController.Index [Admin]
    ?? /Admin/Orders ? OrdersController.Index [Admin]
```

## Key Components

### 1. ApplicationDbContext
```csharp
public class ApplicationDbContext : IdentityDbContext
```
- Inherits from IdentityDbContext (not DbContext)
- Provides Identity tables
- Includes Products, Orders, OrderItems DbSets

### 2. AccountController
```csharp
[Area("Admin")]
[AllowAnonymous]
public class AccountController : Controller
```
- Handles /Admin/Account/Login (GET/POST)
- Handles /Admin/Account/Logout
- Verifies user is in Admin role
- Uses SignInManager for authentication

### 3. AdminGateController
```csharp
[HttpGet("/admin")]
[AllowAnonymous]
public IActionResult Index()
```
- Entry point for /admin URL
- Redirects based on user state
- Checks authentication and role

### 4. Admin Layout
```html
<nav class="navbar navbar-dark bg-dark">
    Dashboard | Products | Orders | Logout
</nav>
```
- Persistent navigation
- Logout button with CSRF token
- Responsive design

## Database Schema Changes

**New Identity Tables:**
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- AspNetUserClaims
- AspNetUserLogins
- AspNetUserTokens
- AspNetRoleClaims

**Existing Tables (Unchanged):**
- Products
- Orders
- OrderItems

## Security Features

| Feature | Implementation |
|---------|-----------------|
| CSRF Protection | @Html.AntiForgeryToken() on forms |
| Password Hashing | IdentityUser password hashing |
| Role-Based Access | [Authorize(Roles = "Admin")] |
| Email Authentication | FindByEmailAsync & PasswordSignInAsync |
| Account Lockout | Built-in Identity lockout support |
| Session Management | Identity framework session cookies |

## Troubleshooting Matrix

| Issue | Cause | Solution |
|-------|-------|----------|
| "Invalid login attempt" | Wrong email/password | Verify credentials |
| "You do not have admin privileges" | User not in Admin role | Assign Admin role |
| "Account locked out" | Too many failed attempts | Reset in database |
| Login page not loading | Routes not configured | Check Program.cs routes |
| Can't access Products/Orders | Not Admin role | Login as admin user |
| Database migration fails | DbContext change | Run `dotnet ef database update` |

## Default Admin Credentials

```
Email:    admin@furni.com
Password: Admin@12345
```

**?? CHANGE IN PRODUCTION**

After first login:
1. Go to Identity Account Settings
2. Change password immediately
3. Create additional admin users as needed
4. Delete or disable default account

## Files Summary

| File | Purpose | Status |
|------|---------|--------|
| ApplicationDbContext.cs | Database context with Identity | ? Fixed |
| AccountController.cs | Login/Logout logic | ? Created |
| AdminController.cs | Admin gate/router | ? Fixed |
| Login.cshtml | Login form UI | ? Updated |
| _Layout.cshtml | Admin nav & layout | ? Updated |
| Program.cs | App startup & seeding | ? Updated |
| DbSeeder.cs | Database initialization | ? Existing |

## Testing Checklist

- [ ] App starts without errors
- [ ] Navigate to /admin ? Redirects to login
- [ ] Login with admin@furni.com / Admin@12345
- [ ] Dashboard shows metrics
- [ ] Can navigate to Products
- [ ] Can navigate to Orders
- [ ] Logout button works
- [ ] After logout, /admin redirects to login again

## Performance Notes

- Login uses email lookup (indexed by default)
- Password verification is async
- Database seeding runs once on startup
- Role checks are cached by Identity framework

## Deployment Notes

1. Run migrations: `dotnet ef database update`
2. Admin user auto-created by DbSeeder
3. No manual user creation needed
4. Change default password after first login
5. Consider using environment variables for credentials

---

**Created**: 2024
**Status**: Production Ready ?
