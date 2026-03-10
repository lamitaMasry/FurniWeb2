using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurniWeb.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = "";

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; } // ex: "/images/product-1.png"

        // Compatibility alias for views and older code that reference "ImageUrl".
        // Keep this as a non-mapped property so EF continues to use the existing
        // ImagePath column in the database.
        [NotMapped]
        public string? ImageUrl
        {
            get => ImagePath;
            set => ImagePath = value;
        }

        public bool IsActive { get; set; } = true;
    }
}