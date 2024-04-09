using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Core.Entities
{
    public class Bill(string title, string description, BillTypeEnum type, decimal totalAmountDue, int totalInstallments, string observation, DateTime installmentStart, int idUser, int? idBank) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public BillTypeEnum Type { get; private set; } = type;
        public decimal TotalAmountDue { get; private set; } = totalAmountDue;
        public int TotalInstallments { get; private set; } = totalInstallments;
        public string? Observation { get; private set; } = observation;
        public DateTime InstallmentStart { get; private set; } = installmentStart;
        public bool Active { get; private set; } = true;
        public int IdUser { get; private set; } = idUser;
        public int? IdBank { get; private set; } = idBank;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public User User { get; private set; }
        public Bank? Bank { get; private set; }

        public List<InstallmentBill> InstallmentBills { get; private set; } = new List<InstallmentBill>();
    }
}
