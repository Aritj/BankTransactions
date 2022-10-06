using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankTransactions.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}