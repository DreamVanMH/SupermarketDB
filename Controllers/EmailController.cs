using Microsoft.AspNetCore.Mvc;
using SupermarketDB.Services;
using SupermarketDB.Models;
using System.Threading.Tasks;

namespace SupermarketDB.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(
                    model.To ?? string.Empty,
                    model.Subject ?? string.Empty,
                    model.Body ?? string.Empty
                );
            }

            return View();
        }
    }
}
