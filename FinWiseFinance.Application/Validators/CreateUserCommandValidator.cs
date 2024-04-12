using FinWiseFinance.Application.Commands.CreateUser;
using FinWiseFinance.Application.Validators.Exthension;
using FluentValidation;

namespace FinWiseFinance.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Primeiro nome obrigatório")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do primeiro nome é de 50 caracteres");


            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do último nome é de 50 caracteres")
                .NotNull()
                .NotEmpty()
                .WithMessage("Último nome obrigatório");

            RuleFor(x => x.Email)
                 .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ obrigatório")
                .Must(ExthensionMethodValidator.IsValidCpfOrCnpj)
                .WithMessage("CPF/CNPJ inválido");

            RuleFor(x => x.Income)
                .NotNull()
                .NotEqual(0.0M)
                .WithMessage("Valor do rendimento não pode ser zero");

            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tipo usuário obrigatório");

            RuleFor(x => x.TypeSalary)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tipo salário obrigatório");

            RuleFor(x => x.DayOfReceipt)
                .NotEmpty()
                .WithMessage("Data de recebimento obrigatório")
                .Must(date => DateTime.TryParse(date.ToString(), out _))
                .WithMessage("Formato de data inválido");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Data de nascimento obrigatório")
                .Must(date => DateTime.TryParse(date.ToString(), out _))
                .WithMessage("Formato de data inválido");

            RuleFor(x => x.Password)
                 .Must(ExthensionMethodValidator.ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        }
    }
}
