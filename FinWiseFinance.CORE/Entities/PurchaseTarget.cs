namespace FinWiseFinance.Core.Entities
{
    public class PurchaseTarget(string title, string? description, bool deductMonthlyIncome, decimal amount, string? link, bool combinedHistory, decimal specifiedValue, int idUser, int? idBank) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string? Description { get; private set; } = description;
        public decimal Amount { get; private set; } = amount;
        public string? Link { get; private set; } = link;
        public decimal SpecifiedValue { get; private set; } = specifiedValue;
        public decimal CombinedTotal { get; private set; } = 0;
        public bool DeductMonthlyIncome { get; private set; } = deductMonthlyIncome;
        public bool Active { get; private set; } = true;
        public bool CombinedHistory { get; private set; } = combinedHistory;
        public bool Purchased { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public int IdUser { get; private set; } = idUser;
        public int? IdBank { get; private set; } = idBank;

        public User User { get; private set; }
        public Bank? Bank { get; private set; }

        public List<PurchaseObjectiveHistory>? PurchaseObjectiveHistories { get; private set; }
    }
}
