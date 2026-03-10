# Admin Login & Dashboard Guide

## Quick Start

### Default Admin Credentials
```
Email: admin@furni.com
Password: Admin@12345
```

## Accessing Admin Area

### Method 1: Direct URL
Navigate to: `http://localhost:5000/admin`

This will redirect you to the admin login page if you're not authenticated.

### Method 2: Login Page
Navigate to: `http://localhost:5000/Admin/Account/Login`

## Admin Features

### 1. Dashboard (`/Admin/Dashboard`)
View key metrics:
- Total Products
- Total Orders
- Total Revenue

### 2. Products (`/Admin/Products`)
- View all products with prices and status
- **Add New Product**: Click "Add New Product" button
- **Edit Product**: Click "Edit" button on any product
- **Delete Product**: Click "Delete" button with confirmation
- Filter by active/inactive status

Product fields:
- Product Name (required)
- Description (optional)
- Price (required, decimal)
- Image URL (e.g., `/images/product-1.png`)
- Active checkbox (visible on shop if checked)

### 3. Orders (`/Admin/Orders`)
- View all customer orders
- Track order details including:
  - Customer information
  - Products ordered
  - Order total
  - Order items with quantities and prices

## Authentication Flow

1. **Anonymous User** ? Redirected to `/Admin/Account/Login`
2. **User Login**:
   - Enter email and password
   - System verifies user has "Admin" role
   - On success ? Redirected to `/Admin/Dashboard`
3. **Admin Dashboard** ? Access to all admin features
4. **Logout** ? Click logout button in navbar ? Return to homepage

## Security Features

? CSRF Token Protection on all forms
? Role-based access control (Admin role required)
? Password hashing with Identity Framework
? Unauthorized access handling (Forbid page)
? Session management

## Creating Additional Admin Users

To create another admin user, you need to:

1. Register a new user via `/Identity/Account/Register`
2. Stop the application
3. Manually update the user's role in the database to "Admin"

OR use the database directly:

```sql
-- Add admin role to existing user
INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM AspNetUsers u, AspNetRoles r
WHERE u.Email = 'newadmin@example.com' AND r.Name = 'Admin'
```

## Troubleshooting

### "Invalid login attempt"
- Check email is correct
- Verify password is correct
- Ensure user exists in database

### "You do not have admin privileges"
- User exists but doesn't have Admin role
- Contact system administrator to assign role

### "Account locked out"
- Too many failed login attempts
- Wait for lockout period to expire or reset in database

### Dashboard not loading
- Ensure you're logged in as admin
- Check browser console for JavaScript errors
- Verify database connection

## Database Tables Used

- **AspNetUsers**: Admin user accounts
- **AspNetRoles**: User roles (Admin, Customer)
- **AspNetUserRoles**: User-to-role mappings
- **Products**: Product catalog
- **Orders**: Customer orders
- **OrderItems**: Items in orders

## File Structure

```
FurniWeb/
??? Areas/Admin/
?   ??? Controllers/
?   ?   ??? AccountController.cs       # Login/Logout
?   ?   ??? AdminController.cs         # Gate controller
?   ?   ??? DashboardController.cs     # Dashboard
?   ?   ??? ProductsController.cs      # Products CRUD
?   ?   ??? OrdersController.cs        # Orders view
?   ??? Views/
?   ?   ??? Account/
?   ?   ?   ??? Login.cshtml           # Login page
?   ?   ??? Dashboard/
?   ?   ?   ??? Index.cshtml
?   ?   ??? Products/
?   ?   ?   ??? Index.cshtml
?   ?   ?   ??? Create.cshtml
?   ?   ?   ??? Edit.cshtml
?   ?   ??? Orders/
?   ?   ?   ??? Index.cshtml
?   ?   ?   ??? Details.cshtml
?   ?   ??? Shared/
?   ?       ??? _Layout.cshtml         # Admin layout with navbar
??? Data/
    ??? ApplicationDbContext.cs        # DbContext (inherits IdentityDbContext)
```

## Next Steps

- Create admin user accounts for team members
- Configure email notifications for orders
- Set up logging and monitoring
- Customize product categories
- Add inventory management
