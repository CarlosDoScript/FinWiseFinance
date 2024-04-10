using FinWiseFinance.Application.Commands.CreateUser;
using FluentValidation;

namespace FinWiseFinance.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            
        }
    }
}
