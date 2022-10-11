using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankTransactions.Models;

namespace BankTransactions.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly TransactionDbContext _context;

        public BankAccountsController(TransactionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bankAccountIndexViewModel = from bankAccount in _context.BankAccounts
                                            join customer in _context.Customers on bankAccount.CustomerId equals customer.CustomerId
                                            join bank in _context.Banks on bankAccount.BankId equals bank.BankId
                                            select new BankAccountIndexViewModel { BankAccount = bankAccount, Customer = customer, Bank = bank };

            return View(bankAccountIndexViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.BankAccounts.FirstOrDefaultAsync(m => m.BankAccountId == id));
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            BankAccountAddOrEditViewModel x = new()
            {
                BankAccount = id == 0 ? new() : _context.BankAccounts.Find(id),
                BankList = _context.Banks.ToList(),
                CustomerList = _context.Customers.ToList()
            };

            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(BankAccountAddOrEditViewModel viewModel)
        {
            BankAccount testAccount = new()
            {
                BankAccountId = viewModel.BankAccount.BankAccountId,
                CustomerId = viewModel.Customer.CustomerId,
                BankId = viewModel.Bank.BankId
            };

            if (viewModel.BankAccount.BankAccountId == 0)
            {
                this._context.Add(testAccount);
            }
            else
            {
                this._context.Update(testAccount);
            }

            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);

            if (bankAccount != null) {
                this._context.Remove(bankAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
