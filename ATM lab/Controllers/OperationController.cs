using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_lab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ATM_lab.Controllers
{
    public class OperationController : Controller
    {
        private readonly ATMcontext _context;

        public OperationController(ATMcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string cardNumber)
        {
            ViewData["CardNumber"] = cardNumber;
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Balance(string cardNumber)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (card != null)
            {
                Card cardInfo = new Card
                {
                    CardNumber = cardNumber,
                    Balance = card.Balance,
                };

                return View(cardInfo);
            }
            
            return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index", errMessage = " " });
        }
    }
}