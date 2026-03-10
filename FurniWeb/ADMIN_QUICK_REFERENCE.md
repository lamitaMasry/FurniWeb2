# Admin Panel - Quick Reference

## ?? Quick Start

| Action | URL | How |
|--------|-----|-----|
| **Login** | `/Admin/Account/Login` | Email: `admin@furni.com` / Password: `Admin@12345` |
| **Dashboard** | `/Admin/Dashboard` | View stats and analytics |
| **Products** | `/Admin/Products` | Manage all products |
| **Orders** | `/Admin/Orders` | View customer orders |

---

## ?? Product Operations

### Add Product (Enroll)
```
1. /Admin/Products ? "Add New Product" button
2. Fill form: Name, Price, Image URL, Active checkbox
3. Click "Save Product"
```

### Edit Product
```
1. /Admin/Products ? Find product ? "Edit" button
2. Modify fields as needed
3. Click "Update Product"
```

### Delete Product (Drop)
```
1. /Admin/Products ? Find product ? "Delete" button
2. Confirm deletion in popup
3. Product is permanently removed
```

---

## ?? Order Operations

### View All Orders
```
/Admin/Orders ? See table of all orders
```

### View Order Details
```
/Admin/Orders ? Click order ? See full customer info & items
```

---

## ?? Common Workflows

### Add 5 New Chairs
1. Go to `/Admin/Products`
2. Click "Add New Product"
3. Enter: Name (required), Price (required), Image URL, check Active
4. Save
5. Repeat 4 more times

### Deactivate Product (Keep in DB)
1. `/Admin/Products` ? Edit product
2. Uncheck "Active"
3. Update
4. Won't show on public site

### Remove Inactive Products
1. `/Admin/Products` ? Find inactive items
2. Click Delete
3. Confirm

---

## ?? Login Details

```
?? Email:    admin@furni.com
?? Password: Admin@12345
```

---

## ?? Important

- ? Products must be "Active" to show in store
- ? Image URL must start with `/` (e.g., `/images/chair.png`)
- ? Prices use decimal format (99.99)
- ? Deleted items cannot be recovered
- ? Only users with Admin role can access

---

## ?? Admin Dashboard Metrics

- **Total Products** - All products in database
- **Total Revenue** - Sum of all completed orders
- **Orders** - Total number of orders

---

## ?? Navigation Menu
```
Furni. Admin | Dashboard | Products | Orders | Logout
```

All pages accessible from any admin page!

---

## Form Fields Reference

### Product Form
| Field | Required | Format | Example |
|-------|----------|--------|---------|
| Name | ? | Text (max 200) | "Nordic Chair" |
| Description | ? | Text (max 2000) | "Beautiful wooden chair..." |
| Price | ? | Decimal | 49.99 |
| Image Path | ? | URL path | /images/product-1.png |
| Active | ? | Checkbox | ? |

---

## Status Badges

- ?? **Active** - Product visible to customers
- ? **Inactive** - Product hidden from store

---

**Last Updated:** Feb 2026
