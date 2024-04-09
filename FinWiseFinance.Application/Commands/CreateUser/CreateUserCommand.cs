using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Enums;
using MediatR;

namespace FinWiseFinance.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string CpfCnpj { get; set; }
        public decimal Income { get; set; }
        public string? CorporateReason { get; set; }
        public UserTypeEnum Type { get; set; }
        public UserTypeSalaryEnum TypeSalary { get; set; }
        public DateTime DayOfReceipt { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public int? IdCompanyBranch { get; set; }
    }
}
