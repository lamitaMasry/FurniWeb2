using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FurniWeb.Models
{
    public class Order
    {
        public int Id { get; set; }

        // When order was created
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Customer info
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = "";

        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = "";

        [Required]
        [MaxLength(200)]
        public string Address1 { get; set; } = "";

        [MaxLength(200)]
        public string? Address2 { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Zip { get; set; } = "";

        [MaxLength(500)]
        public string? OrderNotes { get; set; }

        // Items
        public List<OrderItem> Items { get; set; } = new();

        // Total money
        public decimal TotalAmount
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.UnitPrice * item.Quantity;
                }
                return total;
            }
        }

        // Optional alias so older code that uses "Total" still works
        public decimal Total => TotalAmount;

        public string CustomerName => $"{FirstName} {LastName}".Trim();
    }
}