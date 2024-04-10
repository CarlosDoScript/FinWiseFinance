using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using FinWiseFinance.Core.Services;
using MediatR;

namespace FinWiseFinance.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(
        IUserRepository _userRepository,
        IAuthService _authService
        ) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.PhoneNumber,
                    request.CpfCnpj,
                    request.Income,
                    request.CorporateReason,
                    request.Type,
                    request.TypeSalary,
                    request.BirthDate,
                    passwordHash,
                    request.DayOfReceipt,
                    request.IdCompanyBranch
                );

            var id = await _userRepository.AddAsync(user);

            return id;
        }
    }
}
