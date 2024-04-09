namespace FinWiseFinance.Core.Entities
{
    public class DailyExpense(string title, string description, decimal amount, bool daily, bool deductMonthlyIncome, int idUser, int? idBank) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public bool Active { get; private set; } = true;
        public decimal Amount { get; private set; } = amount;
        public bool Daily { get; private set; } = daily;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool DeductMonthlyIncome { get; private set; } = deductMonthlyIncome;
        public int IdUser { get; private set; } = idUser;
        public int? IdBank { get; private set; } = idBank;


        public User User { get; set; }
        public Bank? Bank { get; private set; }

    }
}
