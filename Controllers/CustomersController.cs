using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransactions.Models;
using BankTransactions.Extensions;

namespace BankTransactions.Controllers
{
    public class CustomersController : Controller
    {
        private readonly TransactionDbContext _context;

        public CustomersController(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.BankAccounts = _context.BankAccounts.Where(s => s.CustomerId == id).ToList();

            return View(await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id));
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            return id == 0 ? View(new Customer{ Birthday = DateTime.Now }) : View(_context.Customers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CustomerId,CustomerName,Birthday")] Customer customer)
        {
            if (! ModelState.IsValid)
            {
                return View(customer);

            }

            customer.CustomerName = customer.CustomerName.Capitalize();

            if (customer.CustomerId == 0)
            {
                this._context.Add(customer);
            }
            else
            {
                this._context.Update(customer);
            }

            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
