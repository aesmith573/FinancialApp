namespace FinancialApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string Type { get; set; } // e.g., Income or Expense
        public required string Account { get; set; } // e.g., Bank account, Credit card

        public Transaction()
        {

        }
    }
}
