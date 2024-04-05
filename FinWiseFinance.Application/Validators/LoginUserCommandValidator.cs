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
             .MaximumLength(14).WithMessage("CPF/CNPJ inválido");

            When(u => u.CpfCnpj?.Length == 11, () =>
            {
                RuleFor(u => u.CpfCnpj).Must(ExthensionMethodValidator.IsValidCpf).WithMessage("CPF inválido");
            });

            When(u => u.CpfCnpj?.Length == 14, () =>
            {
                RuleFor(u => u.CpfCnpj).Must(ExthensionMethodValidator.IsValidCnpj).WithMessage("CNPJ inválido");
            });
            
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Senha inválida");

            RuleFor(u => u.Password)
                .Must(ExthensionMethodValidator.ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
        }
    }
}
