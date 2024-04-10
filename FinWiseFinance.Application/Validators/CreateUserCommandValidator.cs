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
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do primeiro nome é de 50 caracteres")
                .NotNull()
                .WithMessage("Primeiro nome obrigatório") 
                .NotEmpty()
                .WithMessage("Primeiro nome obrigatório");


            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do último nome é de 50 caracteres")
                .NotNull()
                .WithMessage("Último nome obrigatório")
                .NotEmpty()
                .WithMessage("Último nome obrigatório");

            RuleFor(x => x.Email)
                 .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(15)
                .WithMessage("Número máximo de dígitos para telefone é 15");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ obrigatório")
                .Must(ExthensionMethodValidator.IsValidCpfOrCnpj)
                .WithMessage("CPF/CNPJ inválido");          
        }
    }
}
