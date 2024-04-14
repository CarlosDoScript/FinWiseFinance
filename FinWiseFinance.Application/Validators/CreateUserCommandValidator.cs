using FinWiseFinance.Application.Commands.CreateUser;
using FinWiseFinance.Application.Exthension;
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
                .NotNull()
                .NotEmpty()
                .WithMessage("Último nome obrigatório")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do último nome é de 50 caracteres");

            RuleFor(x => x.Email)
                //.NotEmpty()
                //.NotNull()
                //.WithMessage("E-mail obrigatório")
                .EmailAddress()
                .WithMessage("E-mail não é válido");

            RuleFor(u => u.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ obrigatório")
                .Must(ExthensionMethodValidator.IsValidCpfOrCnpj)
                .WithMessage("CPF/CNPJ inválido");

            RuleFor(x => x.Income)
                .NotNull()
                .NotEmpty()
                .WithMessage("Renda obrigatório")
                .NotEqual(0.0M)
                .WithMessage("Valor da renda não pode ser zero");

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage("Tipo usuário obrigatório");

            RuleFor(x => x.TypeSalary)
                .NotNull()
                .WithMessage("Tipo salário obrigatório");

            RuleFor(x => x.DayOfReceipt)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de recebimento obrigatório")
                .Must(date => DateTime.TryParse(date.ToString(), out _))
                .WithMessage("Formato de data inválido");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de nascimento obrigatório")
                .Must(date => DateTime.TryParse(date.ToString(), out _))
                .WithMessage("Formato de data inválido");

            RuleFor(x => x.Password)
                 .Must(ExthensionMethodValidator.ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        }
    }
}
