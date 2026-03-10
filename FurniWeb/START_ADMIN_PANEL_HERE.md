# ?? ADMIN PANEL - START HERE (5 MINUTES)

## ? QUICKEST START

```
1. Press Shift+F5 (Stop any running app)
2. Delete: C:\Projects\FurniWeb\FurniWeb\FurniWeb\furni.db
3. Press F5 (Start)
4. Click user icon (top-right of home page)
5. Login: admin@furni.com / Admin@12345
6. Done! ?
```

---

## ?? WHAT YOU CAN DO

? **View Dashboard**
- See total products count
- See total revenue $
- See order count

? **Add Products**
- Click "+ Add New Product"
- Fill: Name, Price, Image, Active
- Click Save

? **Edit Products**
- Click "Edit" button
- Change details
- Click Update

? **Delete Products**
- Click "Delete" button
- Confirm deletion

? **View Orders**
- See all customer orders
- Customer name, email, phone
- Order total and items

? **Track Revenue**
- Automatically calculated
- Updates with each order

---

## ?? LOGIN CREDENTIALS

```
Email:    admin@furni.com
Password: Admin@12345
```

---

## ?? URLs

| Page | URL |
|------|-----|
| Login | /Admin/Account/Login |
| Dashboard | /Admin/Dashboard |
| Products | /Admin/Products |
| Orders | /Admin/Orders |

---

## ? EVERYTHING WORKS!

All these files are ready:
? AccountController.cs - Login/Logout
? DashboardController.cs - Revenue tracking
? ProductsController.cs - Add/Edit/Delete
? OrdersController.cs - View orders
? Login.cshtml - Login form
? Dashboard view - Shows stats
? Products views - Add/Edit/Delete forms
? Orders view - Order listing
? DbSeeder.cs - Auto-creates admin user
? SQLite database - All data stored

---

## ?? ADMIN WORKFLOW

```
1. START APP ? F5
2. CLICK ADMIN ICON ? Home page
3. LOGIN ? admin@furni.com / Admin@12345
4. SEE DASHBOARD ? Total products, revenue, orders
5. CLICK MANAGE PRODUCTS ? See product list
6. ADD PRODUCT ? Fill form, save
7. EDIT PRODUCT ? Modify details, update
8. DELETE PRODUCT ? Remove from list
9. VIEW ORDERS ? See customer orders & revenue
10. LOGOUT ? Exit admin area
```

---

## ?? KEY FACTS

- **Admin account created automatically** on first app start
- **Database is SQLite** (furni.db) - stores everything
- **Revenue calculated automatically** from all orders
- **Products seeded with 3 items** on first startup
- **No additional setup needed** - ready to use!

---

## ?? SECURITY

? Admin login required
? Admin role required
? Password encrypted
? Anti-forgery tokens
? Session management

---

**Just start the app and click the admin icon! Everything works!** ??
