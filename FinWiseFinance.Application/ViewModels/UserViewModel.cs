namespace FinWiseFinance.Application.ViewModels
{
    public record UserViewModel
    {
        public UserViewModel(string firstName, string lastName, string email, string? phoneNumber, string cpfCnpj, decimal income, string? corporateReason, DateTime dayOfReceipt, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CpfCnpj = cpfCnpj;
            Income = income;
            CorporateReason = corporateReason;
            DayOfReceipt = dayOfReceipt;
            BirthDate = birthDate;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string CpfCnpj { get; init; }
        public decimal Income { get; init; }
        public string? CorporateReason { get; init; }
        public DateTime DayOfReceipt { get; init; }
        public DateTime BirthDate { get; init; }
    }
}
