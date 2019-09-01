using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATM_lab.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace ATM_lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ATMcontext _context;

        public HomeController(ATMcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cardNumber)
        {
            Regex regex = new Regex(@"\d{16}", RegexOptions.IgnorePatternWhitespace);
            bool match = regex.IsMatch(cardNumber);

            if (!match)
            {
                ViewData["ErrMessage"] = "A card with this nmber does not exist";

                return View("Error");
            }

            if (await _context.Card.AnyAsync(c => c.CardNumber == cardNumber))
            {
                return RedirectToAction("Pin", "Home");
            } 

            ViewData["ErrMessage"] = "A card with this nmber does not exist";

            return View("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
