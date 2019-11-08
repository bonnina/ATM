using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATM_lab.Models;
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

        [HttpGet]
        public IActionResult Index()
        {
            var card = new Card();
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cardNumber)
        {
            if (!ModelState.IsValid)
            {
                return ErrorRedirect();
            }
            
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (card != null && !card.Blocked)
            {
                return RedirectToAction("Pin", "Home", new { cardNumber });
            }

            return ErrorRedirect();
        }

        [HttpGet]
        public IActionResult Pin (string cardNumber)
        {
            Card card = new Card
            {
                CardNumber = cardNumber
            };

            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> Pin (string cardNumber, string pin)
        {
            if (String.IsNullOrEmpty(cardNumber) || String.IsNullOrEmpty(pin))
            {
                return ErrorRedirect();
            }

            Card card = await _context.Cards.FirstAsync(c => c.CardNumber == cardNumber);

            if (pin == card.PIN && !card.Blocked)
            {
                return RedirectToAction("Index", "Operation", new { cardNumber });
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
