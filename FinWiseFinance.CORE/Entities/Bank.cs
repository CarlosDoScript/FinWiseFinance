namespace FinWiseFinance.Core.Entities
{
    public class Bank : BaseEntity
    {
        public Bank(string title, string? description)
        {
            Title = title;
            Description = description;
            Active = true;

            Bills = new List<Bill>();
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public bool Active { get; private set; }

        public List<Bill> Bills { get; private set; }
        public List<InstallmentBill> InstallmentBills { get; private set; }
    }
}
