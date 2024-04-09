namespace FinWiseFinance.Core.Entities
{
    public class Bank(string title, string? description) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string? Description { get; private set; } = description;
        public bool Active { get; private set; } = true;

        public List<Bill> Bills { get; private set; } = new List<Bill>();
        public List<InstallmentBill> InstallmentBills { get; private set; } = new List<InstallmentBill>();
        public List<DailyExpense> DailyExpenses { get; private set; } = new List<DailyExpense>();
        public List<PurchaseTarget> PurchaseTargets { get; private set; }
    }
}
