namespace FinWiseFinance.Core.Entities
{
    public class PurchaseObjectiveHistory
    {
        public PurchaseObjectiveHistory(string title,string description, decimal amount)
        {
            Title = title;
            Description = description;
            Amount = amount;
            CreatedAt = DateTime.Now;
            Active = true;
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }

        public User User { get; private set; }
        public PurchaseTarget PurchaseTarget { get; private set; }
    }
}
