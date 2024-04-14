using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Application.ViewModels
{
    public record UserViewModel(
         string firstName,
         string lastName,
         string email,
         string? phoneNumber,
         string cpfCnpj,
         decimal income,
         string corporateReason,
         DateTime birthDate,
         DateTime dayOfReceipt
         )
    {
        public string FirstName { get; init; } = firstName;
        public string LastName { get; init; } = lastName;
        public string Email { get; init; } = email;
        public string? PhoneNumber { get; init; } = phoneNumber;
        public string CpfCnpj { get; init; } = cpfCnpj;
        public decimal Income { get; init; } = income;
        public string? CorporateReason { get; init; } = corporateReason;
        public DateTime DayOfReceipt { get; init; } = dayOfReceipt;
        public DateTime BirthDate { get; init; } = birthDate;
    }
}
