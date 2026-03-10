# Admin Panel - Complete Guide

## Overview
The FurniWeb Admin Panel is a secure area where administrators can manage products and view orders. Access is restricted to users with the "Admin" role.

---

## ?? Admin Login

### Default Admin Credentials
- **Email:** `admin@furni.com`
- **Password:** `Admin@12345`

### How to Login
1. Navigate to `/Admin/Account/Login` or click the admin link
2. Enter your email and password
3. Click **Login**
4. You'll be redirected to the Admin Dashboard

---

## ?? Admin Dashboard (`/Admin/Dashboard`)

The dashboard displays key metrics:
- **Total Products** - Number of products in the store
- **Total Revenue** - Sum of all order revenues
- **Orders** - Number of orders placed

Quick action buttons:
- **Manage Products** - Navigate to product management
- **View Orders** - Navigate to orders management

---

## ?? Product Management (`/Admin/Products`)

### View Products
1. From the dashboard, click **"Manage Products"** or use the navigation menu
2. View all products in a table with:
   - Product ID
   - Product Name
   - Price
   - Active Status
   - Action buttons

### Add New Product (Enroll)
1. Click the **"Add New Product"** button (green button with + icon)
2. Fill in the product details:
   - **Product Name** (required) - e.g., "Nordic Chair"
   - **Description** (optional) - Detailed product information
   - **Price** (required) - Product price in dollars
   - **Image URL** (optional) - Path to product image (e.g., `/images/product-1.png`)
   - **Active** (checkbox) - Check to make the product visible to customers
3. Click **"Save Product"**
4. You'll be redirected back to the products list

### Edit Product
1. Click the **"Edit"** button (yellow button) next to the product
2. Modify any fields:
   - Name
   - Description
   - Price
   - Image URL
   - Active status
3. Click **"Update Product"**
4. Changes are saved immediately

### Delete Product (Drop)
1. Click the **"Delete"** button (red button with trash icon)
2. Confirm the deletion in the popup dialog
3. The product is permanently removed from the store

---

## ?? Order Management (`/Admin/Orders`)

### View Orders
1. From the dashboard, click **"View Orders"** or use the navigation menu
2. See all orders with:
   - Customer name
   - Email address
   - Phone number
   - Order date
   - Order total
   - Items purchased

### View Order Details
1. Click on an order to see full details
2. View complete customer information:
   - Name, email, phone
   - Shipping address
   - Order date and time
   - All items ordered with quantities and prices
   - Total amount

---

## ?? Navigation

### Admin Navigation Bar
Located at the top of all admin pages:

```
Furni. Admin | Dashboard | Products | Orders | Logout
```

- **Dashboard** - Return to the main admin dashboard
- **Products** - Manage all products
- **Orders** - View all customer orders
- **Logout** - Exit admin area and return to public site

---

## ?? Security

### Authentication
- Admin area requires login
- Unauthenticated users are redirected to `/Admin/Account/Login`

### Authorization
- Only users with the **"Admin"** role can access admin features
- Non-admin users will see a "Forbidden" error
- All admin actions are protected with anti-forgery tokens

### Admin Role Assignment
- Set during database seeding for the initial admin user
- Can be assigned to other users via the User Manager

---

## ?? Common Tasks

### How to Add 5 New Products
1. Go to `/Admin/Products`
2. Click "Add New Product" for each item
3. Fill in the details
4. Check "Active" to make them visible
5. Click "Save Product"
6. Repeat 5 times

### How to Deactivate a Product (Without Deleting)
1. Click "Edit" next to the product
2. Uncheck the "Active" checkbox
3. Click "Update Product"
4. The product won't appear on the public store but remains in the database

### How to Update Product Prices
1. Click "Edit" next to the product
2. Change the price value
3. Click "Update Product"
4. Changes are immediately visible to customers

### How to Remove Inactive Products
1. Go to `/Admin/Products`
2. Look for products with "Inactive" badge
3. Click "Delete" to remove them permanently

---

## ?? Important Notes

1. **Product Images** - Images must be uploaded to `/wwwroot/images/` directory separately
2. **Price Format** - Use decimal format (e.g., 99.99)
3. **Image Path** - Always start with `/` (e.g., `/images/product-name.png`)
4. **Active Status** - Products must be "Active" to appear on the public shop
5. **Delete Action** - Deleted products cannot be recovered

---

## ?? Troubleshooting

### Can't Login
- Verify you're using the correct email and password
- Check if the admin user was created during database seeding
- Ensure cookies are enabled in your browser

### Can't Access Products Page
- Verify you're logged in as an admin user
- Check the URL: should be `/Admin/Products`
- Ensure your user has the "Admin" role

### Product Not Showing in Store
- Verify the product is marked as "Active"
- Check the image path is correct
- Verify the product was saved successfully

---

## ?? Support
For issues or questions about the admin panel, please contact the development team.
