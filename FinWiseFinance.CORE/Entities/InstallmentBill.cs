namespace FinWiseFinance.Core.Entities
{
    public class InstallmentBill(int installment, DateTime due, decimal installmentAmount, string? barCode, int idBill, int idUser, int? idBank) : BaseEntity
    {
        public int Installment { get; private set; } = installment;
        public DateTime Due { get; private set; } = due;
        public decimal InstallmentAmount { get; private set; } = installmentAmount;
        public string? BarCode { get; private set; } = barCode;
        public bool Active { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public int IdBill { get; private set; } = idBill;
        public int IdUser { get; private set; } = idUser;
        public int? IdBank { get; private set; } = idBank;

        public Bill Bill { get; private set; }
        public User User { get; private set; }
        public Bank? Bank { get; private set; }


    }
}
