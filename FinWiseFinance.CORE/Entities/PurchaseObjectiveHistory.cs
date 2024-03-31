namespace FinWiseFinance.Core.Entities
{
    public class PurchaseObjectiveHistory : BaseEntity
    {
        public PurchaseObjectiveHistory(string title,string description, decimal amount, int idUser, int idPurchaseTarget)
        {
            Title = title;
            Description = description;
            Amount = amount;
            IdUser = idUser;
            IdPurchaseTarget = idPurchaseTarget;

            CreatedAt = DateTime.Now;
            Active = true;
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public int IdUser { get; private set; }
        public int IdPurchaseTarget { get; private set; }

        public User User { get; private set; }
        public PurchaseTarget PurchaseTarget { get; private set; }
    }
}
