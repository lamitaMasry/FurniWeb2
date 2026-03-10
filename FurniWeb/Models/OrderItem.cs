using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurniWeb.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        // FK
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }

        [Required, MaxLength(200)]
        public string ProductName { get; set; } = "";

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}