namespace FinWiseFinance.Core.Entities
{
    public class InstallmentBill : BaseEntity
    {
        public InstallmentBill(int installment, DateTime due, decimal installmentAmount, string? barCode)
        {
            Installment = installment;
            Due = due;
            InstallmentAmount = installmentAmount;
            BarCode = barCode;

            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int Installment { get; private set; }
        public DateTime Due { get; private set; }
        public decimal InstallmentAmount { get; private set; }
        public string? BarCode { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Bill Bill { get; private set; }
        public User User { get; private set; }
        public Bank? Bank { get; private set; }


    }
}
