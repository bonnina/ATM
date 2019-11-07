using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ATM_lab.Models
{
    public class ATMcontext : DbContext
    {
        public ATMcontext(DbContextOptions<ATMcontext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
