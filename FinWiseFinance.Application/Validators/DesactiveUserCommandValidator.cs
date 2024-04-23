using FinWiseFinance.Application.Commands.DesactiveUser;
using FluentValidation;

namespace FinWiseFinance.Application.Validators
{
    public class DesactiveUserCommandValidator : AbstractValidator<DesactiveUserCommand>
    {
        public DesactiveUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("IdUser obrigatório");
        }
    }
}
