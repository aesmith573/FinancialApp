using System.Diagnostics;
using FinancialApp.Models;
using FinancialApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinancialApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch last 5 transactions
            var transactions = _context.Transactions.OrderByDescending(t => t.Date).Take(5).ToList();

            var totalIncome = _context.Transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            var totalExpenses = _context.Transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            var balance = totalIncome - totalExpenses;

            var dashboardData = new DashboardViewModel
            {
                RecentTransactions = transactions,
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                Balance = balance
            };
            return View(dashboardData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
