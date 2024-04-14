using FinWiseFinance.Application.ViewModels;
using FinWiseFinance.Core.Repositories;
using MediatR;

namespace FinWiseFinance.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(
        IUserRepository _userRepository
        ) : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
                return null;

            var userViewModel = new UserViewModel(
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.CpfCnpj,
                user.Income,
                user.CorporateReason,
                user.BirthDate,
                user.DayOfReceipt
                );

            return userViewModel;
        }
    }
}
