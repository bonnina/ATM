using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_lab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ATM_lab.Constants;

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

                Operation operation = new Operation
                {
                    CardNumber = cardNumber,
                    Type = OperationType.BALANCE,
                    Timestamp = DateTime.UtcNow,
                };

                  _context.Operations.Add(operation);

                  await _context.SaveChangesAsync();

                return View(cardInfo);
            }
            
            return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index", errMessage = " " });
        }

        [HttpGet]
        public async Task<IActionResult> Withdrawal(string cardNumber)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (card != null && !card.Blocked)
            {
                Operation operation = new Operation
                {
                    CardNumber = cardNumber
                };

                return View(operation);
            }

            return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index", errMessage = " " });
        }

        [HttpPost]
        public async Task<IActionResult> Withdrawal(string cardNumber, decimal amount)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (card != null && !card.Blocked && card.Balance >= amount)
            {
                card.Balance -= amount;

                Operation operation = new Operation
                {
                    CardNumber = cardNumber,
                    Type = OperationType.WITHDRAWAL,
                    Amount = amount,
                    Timestamp = DateTime.UtcNow,
                };

                _context.Operations.Add(operation);

                await _context.SaveChangesAsync();

                return RedirectToAction("Receipt", "Operation", new { card });
            }

            if (card.Balance < amount)
            {
                return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index", errMessage = "Insufficient Funds" });
            }

            return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index" });
        }

        [HttpGet]
        public IActionResult Receipt(Card card)
        {
            if (card != null) {
                return View(card);
            }

            return RedirectToAction("ErrorRedirect", "Home", new { prevUrl = "Index" });
        }
    }
}