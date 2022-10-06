using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransactions.Models;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("BankId,BankName,TransactionRate")] Bank bank)
        {
            if (! ModelState.IsValid)
            {
                return View(bank);

            }

            if (bank.BankId == 0)
            {
                this._context.Add(bank);
            }
            else
            {
                this._context.Update(bank);
            }

            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
