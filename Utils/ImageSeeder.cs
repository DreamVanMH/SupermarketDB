using System.IO;
using System.Text.RegularExpressions;
using SupermarketDB.Data;
using SupermarketDB.Models;

namespace SupermarketDB.Utils
{
    public class ImageSeeder
    {
        private readonly ApplicationDbContext _context;

        public ImageSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddImagesToProducts()
        {
            var imgFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");

            foreach (var product in _context.products)
            {
                var expectedFileName = NormalizeFileName(product.Name) + ".png";
                var filePath = Path.Combine(imgFolder, expectedFileName);

                if (File.Exists(filePath))
                {
                    product.ImageData = File.ReadAllBytes(filePath);
                    product.ImageMimeType = "image/png";
                }
            }

            _context.SaveChanges();
        }

        // "Logitech POP Mouse" → "logitechpopmouse"
        private string NormalizeFileName(string name)
        {
            return Regex.Replace(name.ToLower(), @"[\s\-]", "");
        }
    }
}
