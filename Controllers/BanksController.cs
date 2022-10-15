using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankTransactions.Models;
using BankTransactions.Extensions;

namespace BankTransactions.Controllers
{
    public class BanksController : Controller
    {
        private readonly TransactionDbContext _context;

        public BanksController(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.Banks.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            return id == 0 ? View(new Bank()) : View(_context.Banks.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([Bind("BankId,BankName,TransactionRate")] Bank bank)
        {
            bank.BankName = bank.BankName.Capitalize();

            if (bank.BankId == 0)
            {
                _context.Add(bank);
            }
            else
            {
                _context.Update(bank);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bank = await _context.Banks.FindAsync(id);

            if (bank != null)
            {
                _context.Banks.Remove(bank);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
