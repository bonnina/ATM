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
            Operation operation = new Operation
            {
                CardNumber = cardNumber
            };

            return View(operation);
        }

        [HttpGet]
        public IActionResult Withdraw(string cardNumber)
        {
            Operation operation = new Operation
            {
                CardNumber = cardNumber
            };

            return View(operation);
        }
    }
}