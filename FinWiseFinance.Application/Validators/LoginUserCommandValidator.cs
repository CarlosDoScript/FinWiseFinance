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
             .Must(ExthensionMethodValidator.IsValidCpfOrCnpj)
             .WithMessage("CPF/CNPJ inválido");              

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha inválida");

            RuleFor(u => u.Password)
                .Must(ExthensionMethodValidator.ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
        }
    }
}
