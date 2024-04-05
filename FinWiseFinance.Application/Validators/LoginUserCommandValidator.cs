using FinWiseFinance.Application.Commands.LoginUser;
using FinWiseFinance.Application.Validators.Exthension;
using FluentValidation;
using System.Text.RegularExpressions;

namespace FinWiseFinance.Application.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.CpfCnpj)
           .NotEmpty().WithMessage("CPF/CNPJ obrigatório")
           .Must(ExthensionMethodValidator.IsValidCpf).WithMessage("CPF inválido")
           .Must(ExthensionMethodValidator.IsValidCnpj).WithMessage("CNPJ inválido")
           .MaximumLength(14);

            When(u => u.CpfCnpj.Length == 11, () =>
            {
                RuleFor(u => u.CpfCnpj).Must(ExthensionMethodValidator.IsValidCpf).WithMessage("CPF inválido");
            });

            When(u => u.CpfCnpj.Length == 14, () =>
            {
                RuleFor(u => u.CpfCnpj).Must(ExthensionMethodValidator.IsValidCnpj).WithMessage("CNPJ inválido");
            });

        }       
    }
}
