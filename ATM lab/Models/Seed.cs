using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATM_lab.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ATMcontext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ATMcontext>>()))
            {
                if (context.Card.Any())
                {
                    return;   // DB has been seeded
                }

                context.Card.AddRange(
                    new Card
                    {
                        CardNumber = "5555444433332222",
                        PIN = "5432",
                        FailedLogins = 0,
                        Blocked = false
                    },
                    new Card
                    {
                        CardNumber = "4444333322221111",
                        PIN = "4321",
                        FailedLogins = 0,
                        Blocked = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
