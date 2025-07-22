using System.ComponentModel.DataAnnotations;

namespace SupermarketDB.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;

        // This property stores the price of the product
        [Required]
        public decimal Price { get; set; }

        // Optional: This was probably used earlier in your Views
        public string? ImagePath { get; set; }

        // These are used to store image binary data in the database
        public byte[]? ImageData { get; set; }

        public string? ImageMimeType { get; set; }
    }
}
