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
            BankAccount? bankAccount = id == 0 ? new() : _context.BankAccounts.Find(id);
            bankAccount = bankAccount == null ? new() : bankAccount;

            BankAccountAddOrEditViewModel bankAccountAddOrEditViewModel = new()
            {
                BankAccount = bankAccount,
                BankList = _context.Banks.ToList(),
                CustomerList = _context.Customers.ToList()
            };

            return View(bankAccountAddOrEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(BankAccountAddOrEditViewModel viewModel)
        {
            BankAccount bankAccount = new()
            {
                BankAccountId = viewModel.BankAccount.BankAccountId,
                CustomerId = viewModel.Customer.CustomerId,
                BankId = viewModel.Bank.BankId,
                Amount = viewModel.BankAccount.Amount
            };

            if (viewModel.BankAccount.BankAccountId == 0)
            {
                this._context.Add(bankAccount);
            }
            else
            {
                this._context.Update(bankAccount);
            }

            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
