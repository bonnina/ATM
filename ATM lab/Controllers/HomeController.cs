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
        
        public IActionResult ErrorRedirect(string errMessage = "Invalid credentials")
        {
            return RedirectToAction("Error", new Error
            {
                ErrMessage = errMessage,
                PrevUrl = ControllerContext.RouteData.Values["action"].ToString()
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cardNumber)
        {
            if (!ModelState.IsValid)
            {
                return ErrorRedirect();
            }
            
            Card card = await _context.Card.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (card != null && !card.Blocked)
            {
                return RedirectToAction("Pin", "Home", new { cardNumber });
            }

            return ErrorRedirect();
        }

        [HttpGet]
        public IActionResult Pin (string cardNumber)
        {
            ViewData["CardNumber"] = cardNumber;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pin (string cardNumber, string pin)
        {
            if (String.IsNullOrEmpty(cardNumber) || String.IsNullOrEmpty(pin))
            {
                return ErrorRedirect();
            }

            Card card = await _context.Card.FirstAsync(c => c.CardNumber == cardNumber);

            if (pin == card.PIN && !card.Blocked)
            {
                // redirect to operations screen
            }

            if (pin != card.PIN && !card.Blocked) 
            {
                card.FailedLogins++;

                if (card.FailedLogins > 3)
                {
                    card.Blocked = true;
                }

                await _context.SaveChangesAsync();
            }

            return ErrorRedirect();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(Error error)
        {
            return View(error);
        }
    }
}
