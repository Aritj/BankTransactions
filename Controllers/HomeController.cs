using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankTransactions.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransactionDbContext _context;

        public HomeController(TransactionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new Transaction { Date = DateTime.Now });
        }

        [HttpPost]
        public async Task<IActionResult> Transaction([Bind("TransactionId,FromAccountNumber,ToAccountNumber,Amount,Date")] Transaction transaction)
        {
            if (! ModelState.IsValid)
            {
                // Error message: invalid ModelState
                return RedirectToAction(nameof(Index));
            }

            BankAccount? fromAccount = _context.BankAccounts.Find(transaction.FromAccountNumber);
            BankAccount? toAccount = _context.BankAccounts.Find(transaction.ToAccountNumber);

            if (fromAccount == null || toAccount == null || fromAccount == toAccount)
            {
                // Error message: invalid AccountNumber(s)
                return RedirectToAction(nameof(Index));
            }

            if (transaction.Amount <= 0)
            {
                // Error message: invalid Transaction amount
                return RedirectToAction(nameof(Index));
            }

            Bank? fromBank = _context.Banks.Find(fromAccount.BankId);
            Bank? toBank = _context.Banks.Find(toAccount.BankId);

            if (fromBank == null || toBank == null)
            {
                // Error message: invalid Bank
                return RedirectToAction(nameof(Index));
            }

            // Perform transaction
            fromAccount.Amount -= transaction.Amount;
            toAccount.Amount += transaction.Amount * (1 - ((double) fromBank.TransactionRate / 100));

            // Store transaction
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}