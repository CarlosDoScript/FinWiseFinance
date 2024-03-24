using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Core.Entities
{
    public class Bill : BaseEntity
    {
        public Bill(string description, BillTypeEnum type, decimal totalAmountDue, int totalInstallments, string observation, DateTime installmentStart)
        {
            Description = description;
            Type = type;
            TotalAmountDue = totalAmountDue;
            TotalInstallments = totalInstallments;
            Observation = observation;
            InstallmentStart = installmentStart;

            Active = true;
            CreatedAt = DateTime.Now;

            InstallmentBills = new List<InstallmentBill>();
        }

        public string Description { get; private set; }
        public BillTypeEnum Type { get; private set; }
        public decimal TotalAmountDue { get; private set; }
        public int TotalInstallments { get; private set; }
        public string Observation { get; private set; }
        public DateTime InstallmentStart { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User User { get; private set; }

        public List<InstallmentBill> InstallmentBills { get; private set; }

    }
}
