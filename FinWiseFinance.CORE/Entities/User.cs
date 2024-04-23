using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Core.Entities
{
    public class User(
        string firstName,
        string lastName,
        string email,
        string? phoneNumber,
        string cpfCnpj,
        decimal income, 
        string? corporateReason,
        UserTypeEnum type, 
        UserTypeSalaryEnum typeSalary,
        DateTime birthDate,
        string password,
        DateTime dayOfReceipt,
        int? idCompanyBranch
        ) : BaseEntity
    {
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Email { get; private set; } = email;
        public string? PhoneNumber { get; private set; } = phoneNumber;
        public string CpfCnpj { get; private set; } = cpfCnpj;
        public decimal Income { get; private set; } = income;
        public string? CorporateReason { get; private set; } = corporateReason;
        public UserTypeEnum Type { get; private set; } = type;
        public UserTypeSalaryEnum TypeSalary { get; private set; } = typeSalary;
        public DateTime DayOfReceipt { get; private set; } = dayOfReceipt;
        public DateTime BirthDate { get; private set; } = birthDate;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool Active { get; private set; } = true;
        public string Password { get; private set; } = password;
        public int? IdCompanyBranch { get; private set; } = idCompanyBranch;

        public List<UserProfession> UserProfessions { get; private set; } = new List<UserProfession>();
        public List<Bill> Bills { get; private set; } = new List<Bill>();
        public List<InstallmentBill> InstallmentBills { get; private set; } = new List<InstallmentBill>();
        public List<DailyExpense> DailyExpenses { get; private set; } = new List<DailyExpense>();
        public List<PurchaseTarget> PurchaseTargets { get; private set; } = new List<PurchaseTarget>();
        public List<PurchaseObjectiveHistory>? PurchaseObjectiveHistories { get; private set; } = new List<PurchaseObjectiveHistory>();

        public CompanyBranch? CompanyBranch { get; private set; }

        public void Desactive()
        {
            if (Active)
            {
                Active = false;
            }
        }
    }
}
