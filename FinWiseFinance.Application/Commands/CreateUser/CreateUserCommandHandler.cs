using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using MediatR;

namespace FinWiseFinance.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                    request.FullName,
                    request.Email,
                    request.PhoneNumber,
                    request.CpfCnpj,
                    request.Income,
                    request.CorporateReason,
                    request.Type,
                    request.TypeSalary,
                    request.BirthDate,
                    request.Password,
                    request.DayOfReceipt,
                    request.IdCompanyBranch
                );

            //var result = userRepository.AddAsync
            await Task.FromResult(4);

            return 10;
        }
    }
}
