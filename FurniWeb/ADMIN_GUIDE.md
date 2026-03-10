# Admin Product Management Guide

## Overview
The admin dashboard now has a complete product management system that allows you to add, edit, and delete products from the web interface.

## Accessing the Admin Panel
1. Navigate to `/Admin/Products`
2. You'll see a list of all products with their details

## Features

### View Products
- See all products in a clean table format
- View product ID, name, price, and active status
- Filter or search through the product list

### Add New Product
1. Click the "Add New Product" button
2. Fill in the following fields:
   - **Product Name** (required): Name of the product
   - **Description** (optional): Product details
   - **Price** (required): Product cost in dollars
   - **Image URL** (optional): Path to product image (e.g., `/images/product-1.png`)
   - **Active**: Check to make the product visible on the shop

3. Click "Save Product" to create the product

### Edit Product
1. Click the "Edit" button next to any product
2. Modify the fields as needed
3. Click "Update Product" to save changes

### Delete Product
1. Click the "Delete" button next to any product
2. Confirm the deletion when prompted
3. The product will be removed from the database

## Product Image Paths
When adding images, use paths relative to the `wwwroot` folder:
- Example: `/images/product-1.png`
- Image files should be stored in `wwwroot/images/`

## Active Status
- **Active**: Product appears on the shop and public APIs
- **Inactive**: Product is hidden from customers (for soft deletes)

## Database Integration
- All changes are saved directly to the database
- The `/api/products` endpoint automatically returns only active products
- The shop.html page displays only active products

## API Integration
The public-facing shop uses the `/api/products` endpoint which:
- Only returns active products
- Returns JSON with product details for the frontend

## Security Notes
- All forms include CSRF protection
- Delete operations require confirmation
- Admin access should be restricted to authorized users only

## Troubleshooting

### Products not appearing on shop
- Check that the product's "Active" checkbox is enabled
- Verify the product exists in the admin list

### Price formatting
- Prices should be entered as decimal numbers (e.g., 19.99)
- Display format is automatic with $ prefix

### Image not showing
- Ensure the image file exists in `wwwroot/images/`
- Check the path is correct (must start with `/`)
- Verify the image format is supported (PNG, JPG, GIF, etc.)
