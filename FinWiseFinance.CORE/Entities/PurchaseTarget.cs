namespace FinWiseFinance.Core.Entities
{
    public class PurchaseTarget : BaseEntity
    {
        public PurchaseTarget(string title, string? description, bool deductMonthlyIncome, decimal amount, string? link,bool combinedHistory, decimal specifiedValue)
        {
            Title = title;
            Description = description;
            Amount = amount;
            Link = link;
            CombinedHistory = combinedHistory;
            SpecifiedValue = specifiedValue;
            DeductMonthlyIncome = deductMonthlyIncome;

            CombinedTotal = 0;
            Active = true;
            Purchased = false;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public string? Link { get; private set; }
        public decimal SpecifiedValue { get; private set; }
        public decimal CombinedTotal { get; private set; }
        public bool DeductMonthlyIncome { get; private set; }
        public bool Active { get; private set; }
        public bool CombinedHistory { get; private set; }
        public bool Purchased { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User User { get; private set; }
        public Bank? Bank { get; private set; }

    }
}
