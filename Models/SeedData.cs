using Microsoft.EntityFrameworkCore;

namespace BankTransactions.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TransactionDbContext dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TransactionDbContext>();

            CheckPendingMigrations(dbContext);

            CheckBanks(dbContext);

            CheckCustomers(dbContext);

            CheckBankAccounts(dbContext);

            dbContext.SaveChanges();
        }

        private static void CheckBankAccounts(TransactionDbContext dbContext)
        {
            if (! dbContext.BankAccounts.Any())
            {
                dbContext.BankAccounts.AddRange(
                    new BankAccount
                    {
                        CustomerId = 1,
                        BankId = 1,
                        Amount = 1000
                    },
                    new BankAccount
                    {
                        CustomerId = 2,
                        BankId = 2,
                        Amount = 100
                    },
                    new BankAccount
                    {
                        CustomerId = 2,
                        BankId = 3,
                        Amount = 0
                    });
            }
        }

        private static void CheckCustomers(TransactionDbContext dbContext)
        {
            if (! dbContext.Customers.Any())
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

        private static void CheckBanks(TransactionDbContext dbContext)
        {
            if (! dbContext.Banks.Any())
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

        private static void CheckPendingMigrations(TransactionDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
