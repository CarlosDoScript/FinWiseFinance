namespace FinWiseFinance.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string cpfCnpj, decimal rawMoney, string corporateReason, DateTime birthDate, DateTime createdAt, bool active, string password)
        {
            FullName = fullName;
            Email = email;
            CpfCnpj = cpfCnpj;
            RawMoney = rawMoney;
            CorporateReason = corporateReason;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
            Password = password;

            Professions = new List<UserProfession>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string CpfCnpj { get; private set; }
        public decimal RawMoney { get; private set; }
        public string CorporateReason { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }

        public List<UserProfession> Professions { get; private set; }
        public CompanyBranch CompanyBranch { get; private set; }
    }
}
