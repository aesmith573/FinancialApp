using System.Collections.Generic;

namespace FinancialApp.Models
{
    public class DashboardViewModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> RecentTransactions { get; set; }
    }
}
