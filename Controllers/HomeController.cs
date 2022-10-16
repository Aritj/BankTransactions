using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankTransactions.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransactionDbContext _context;

        public HomeController(TransactionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Transaction());
        }

        [HttpGet]
        public async Task<IActionResult> Transactions()
        {
            return View(await _context.Transactions.ToListAsync());
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

            if (transaction.Amount <= 0 || fromAccount.Amount < transaction.Amount)
            {
                // Error message: invalid Transaction amount or insufficient funds
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
            transaction.Date = DateTime.Now;
            fromAccount.Amount -= transaction.Amount;
            toAccount.Amount += transaction.Amount * (1 - ((double) fromBank.TransactionRate / 100));

            // Store transaction
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}