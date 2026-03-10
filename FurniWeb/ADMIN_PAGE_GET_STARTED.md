# ?? ADMIN PAGE - START HERE

## ? Everything is Ready!

The admin page is **fully functional** and ready to use. Follow these simple steps:

---

## ?? Step 1: Start the Application

1. **Stop the current debug session** (if running)
   - Press `Shift + F5` or click Stop

2. **Start the application** 
   - Press `F5` or click Run
   - Wait for it to load (usually shows "Now listening on: https://localhost:...")

3. **Open your browser**
   - Navigate to: `https://localhost:7227` (or your local URL)

---

## ?? Step 2: Login as Admin

1. **Go to Admin Login Page**
   - Click the Admin link on the home page, OR
   - Navigate directly to: `https://localhost:7227/Admin/Account/Login`

2. **Enter Admin Credentials**
   - **Email:** `admin@furni.com`
   - **Password:** `Admin@12345`

3. **Click Login**
   - You'll be redirected to the Admin Dashboard

---

## ?? Step 3: Admin Dashboard

Once logged in, you'll see the dashboard with:
- ?? **Total Products** count
- ?? **Total Revenue** 
- ?? **Orders** count

Two main buttons:
- **"Manage Products"** ? Click this to add/edit/delete products
- **"View Orders"** ? View customer orders

---

## ?? Step 4: Add a Product (Most Important!)

1. **Click "Manage Products"** button on the dashboard
   - OR navigate to: `https://localhost:7227/Admin/Products`

2. **Click "Add New Product"** button (green button with +)

3. **Fill in the Product Form:**
   ```
   Product Name:     Nordic Chair
   Description:      Beautiful wooden chair
   Price:            $50.00
   Image URL:        /images/product-1.png
   Active:           ? (check the box)
   ```

4. **Click "Save Product"**

5. **Done!** The product appears in the list and on the public shop

---

## ?? Step 5: Edit a Product

1. From the **Products page**, find the product
2. Click the **"Edit"** button (yellow button)
3. Change any field:
   - Name
   - Description
   - Price
   - Image URL
   - Active status
4. Click **"Update Product"**

---

## ??? Step 6: Delete a Product

1. From the **Products page**, find the product
2. Click the **"Delete"** button (red button)
3. **Confirm** in the popup dialog
4. **Done!** Product is removed

---

## ?? Quick Reference - Product Form Fields

| Field | Required | Example |
|-------|----------|---------|
| **Product Name** | ? Yes | Nordic Chair |
| **Description** | ? No | Beautiful wooden design... |
| **Price** | ? Yes | 50.00 |
| **Image URL** | ? No | /images/product-1.png |
| **Active** | ? No | ? Check to show in store |

---

## ?? Admin Navigation

Once logged in, you'll see the menu bar at the top:

```
Furni. Admin | Dashboard | Products | Orders | Logout
```

- **Dashboard** - Go back to main stats page
- **Products** - Manage all products (add/edit/delete)
- **Orders** - View all customer orders
- **Logout** - Exit admin area

---

## ??? Image Path Examples

When adding products, the Image URL should look like:

```
/images/product-1.png
/images/nordic-chair.jpg
/images/furniture/chair.png
```

**Note:** You need to upload actual image files to the `wwwroot/images/` folder first!

---

## ?? Important Notes

### ? Products MUST be "Active" to show in the public shop
- Check the "Active" checkbox when creating products
- Uncheck it to hide products (without deleting)

### ? Image URLs must start with `/`
- Good: `/images/product-1.png`
- Bad: `images/product-1.png` or `C:\images\product.png`

### ? Price format is in dollars
- Enter: `49.99` (not `$49.99`)

### ? Deleted products CANNOT be recovered
- Be careful when clicking Delete!

---

## ?? Login Troubleshooting

| Problem | Solution |
|---------|----------|
| **Can't login** | Check email/password are correct (admin@furni.com / Admin@12345) |
| **"Invalid login attempt"** | Verify credentials, try again |
| **Page not found** | Make sure URL is `/Admin/Account/Login` |
| **Database locked** | Restart the application |

---

## ?? Step-by-Step Example: Add 3 Chairs

### Chair 1: Nordic Chair
1. Click "Add New Product"
2. Name: `Nordic Chair`
3. Price: `50`
4. Image: `/images/product-1.png`
5. Check "Active"
6. Save

### Chair 2: Kruzo Aero Chair
1. Click "Add New Product"
2. Name: `Kruzo Aero Chair`
3. Price: `78`
4. Image: `/images/product-2.png`
5. Check "Active"
6. Save

### Chair 3: Ergonomic Chair
1. Click "Add New Product"
2. Name: `Ergonomic Chair`
3. Price: `43`
4. Image: `/images/product-3.png`
5. Check "Active"
6. Save

---

## ? Verification Checklist

After following the steps above, verify:

- [ ] Admin login works with email/password
- [ ] Dashboard shows product count
- [ ] Can add a new product
- [ ] Can edit product details
- [ ] Can delete a product (with confirmation)
- [ ] Products appear on the public shop
- [ ] Inactive products don't show in shop
- [ ] Can logout successfully

---

## ?? What's Working

? Admin Login/Logout
? Product Management (Add/Edit/Delete)
? Order Viewing
? Database Seeding
? Authorization (Admin role protection)
? Anti-forgery tokens (Security)

---

## ?? Need Help?

If something doesn't work:
1. **Rebuild the solution** - Press `Ctrl+Shift+B`
2. **Restart the application** - Press `Shift+F5` then `F5`
3. **Check the browser console** - `F12` ? Console tab
4. **Check Visual Studio Output window** - View ? Output

---

**You're all set! Start at Step 1 and follow along! ??**
