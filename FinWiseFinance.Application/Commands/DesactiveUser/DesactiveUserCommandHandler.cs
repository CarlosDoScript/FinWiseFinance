using FinWiseFinance.Core.Repositories;
using MediatR;

namespace FinWiseFinance.Application.Commands.DesactiveUser
{
    public class DesactiveUserCommandHandler(
        IUserRepository _userRepository,
        IUnitOfWork _uow
        )
        : IRequestHandler<DesactiveUserCommand, Unit>
    {        
        public async Task<Unit> Handle(DesactiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return Unit.Value;

            user.Desactive();

            await _uow.CommitAsync();

            return Unit.Value;
        }
    }
}
