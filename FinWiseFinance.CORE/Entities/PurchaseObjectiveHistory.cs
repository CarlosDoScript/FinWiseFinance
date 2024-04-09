namespace FinWiseFinance.Core.Entities
{
    public class PurchaseObjectiveHistory(string title, string description, decimal amount, int idUser, int idPurchaseTarget) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string? Description { get; private set; } = description;
        public decimal Amount { get; private set; } = amount;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool Active { get; private set; } = true;
        public int IdUser { get; private set; } = idUser;
        public int IdPurchaseTarget { get; private set; } = idPurchaseTarget;

        public User User { get; private set; }
        public PurchaseTarget PurchaseTarget { get; private set; }
    }
}
