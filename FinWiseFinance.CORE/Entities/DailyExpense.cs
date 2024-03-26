namespace FinWiseFinance.Core.Entities
{
    public class DailyExpense : BaseEntity
    {
        public DailyExpense(string title, string description, decimal amount, bool daily, bool deductMonthlyIncome)
        {
            Title = title;
            Description = description;            
            Amount = amount;
            Daily = daily;
            DeductMonthlyIncome = deductMonthlyIncome;

            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Amount { get; private set; }
        public bool Daily { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool DeductMonthlyIncome { get; private set; }


        public User User { get; set; }
    }
}
