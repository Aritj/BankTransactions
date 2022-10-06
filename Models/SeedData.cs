using Microsoft.EntityFrameworkCore;

namespace BankTransactions.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TransactionDbContext dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TransactionDbContext>();

            checkPendingMigrations(dbContext);

            checkBanks(dbContext);

            CheckCustomers(dbContext);

            dbContext.SaveChanges();
        }

        private static void CheckCustomers(TransactionDbContext dbContext)
        {
            if (!dbContext.Customers.Any())
            {
                dbContext.Customers.AddRange(
                    new Customer
                    {
                        CustomerName = "Ari Torkilsson Johannesen",
                        Birthday = new DateTime(1997, 7, 30)
                    },
                    new Customer
                    {
                        CustomerName = "Rebekka Skaale",
                        Birthday = new DateTime(1998, 11, 6)
                    });
            }
        }

        private static void checkBanks(TransactionDbContext dbContext)
        {
            if (!dbContext.Banks.Any())
            {
                dbContext.Banks.AddRange(
                    new Bank
                    {
                        BankName = "Betri",
                        TransactionRate = 1
                    },
                    new Bank
                    {
                        BankName = "Bank Nordik",
                        TransactionRate = 2

                    },
                    new Bank
                    {
                        BankName = "Norðoyar Sparikassi",
                        TransactionRate = 3
                    },
                    new Bank
                    {
                        BankName = "Suðuroyar Sparikassi",
                        TransactionRate = 0
                    });
            }
        }

        private static void checkPendingMigrations(TransactionDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
