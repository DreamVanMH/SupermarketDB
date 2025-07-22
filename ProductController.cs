using Microsoft.AspNetCore.Mvc;
using SupermarketDB.Data;
using SupermarketDB.Models;
using System.Linq;

namespace SupermarketDB.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // This method returns image data from the database for a given product ID
        public FileContentResult GetImage(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product != null && product.ImageData != null)
            {
                return File(product.ImageData, product.ImageMimeType ?? "image/png");
            }
            return File(new byte[0], "image/png"); // Return an empty image if not found
        }

        // This method retrieves all products from the database and returns them to the view
        public IActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Price")] Product product, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                // If an image was uploaded, convert it to byte[] and store MIME type
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImageFile.CopyTo(ms);
                        product.ImageData = ms.ToArray();
                        product.ImageMimeType = ImageFile.ContentType;
                    }
                }

                // Save the product to the database
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // If model validation fails, return the view with the entered data
            return View(product);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Price")] Product product, IFormFile ImageFile)
        {
            // Check if the product ID in the route matches the form data
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Get the original product from the database
                var existingProduct = _context.products.FirstOrDefault(p => p.Id == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update name and price
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                // If an image was uploaded, update the image data and MIME type
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImageFile.CopyTo(ms);
                        existingProduct.ImageData = ms.ToArray();
                        existingProduct.ImageMimeType = ImageFile.ContentType;
                    }
                }

                // Save changes to the database
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, return the product to the form
            return View(product);
        }

        // GET: Product/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
