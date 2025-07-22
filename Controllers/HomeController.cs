using Microsoft.AspNetCore.Mvc;
using SupermarketDB.Data;
using SupermarketDB.Models;
using System.Linq;

namespace SupermarketDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.products.ToList(); // ✅ 
            return View(products); // ✅ 
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
