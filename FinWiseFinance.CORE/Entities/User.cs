using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string? phoneNumber, string cpfCnpj, decimal money, string? corporateReason, UserTypeEnum type, UserTypeSalaryEnum typeSalary, DateTime birthDate, DateTime createdAt,string password)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            CpfCnpj = cpfCnpj;
            Income = money;
            CorporateReason = corporateReason;
            Type = type;
            TypeSalary = typeSalary;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Password = password;

            Active = true;
            CreatedAt = DateTime.Now;

            Professions = new List<UserProfession>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string CpfCnpj { get; private set; }
        public decimal Income { get; private set; }
        public string? CorporateReason { get; private set; }
        public UserTypeEnum Type { get; private set; }
        public UserTypeSalaryEnum TypeSalary { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }

        public List<UserProfession>? Professions { get; private set; }
        public List<Bill> Bills { get; private set; }
        public List<InstallmentBill> InstallmentBills { get; private set; }

        public CompanyBranch? CompanyBranch { get; private set; }
    }
}
