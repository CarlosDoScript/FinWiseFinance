using FinWiseFinance.Application.ViewModels;
using FinWiseFinance.Core.Repositories;
using MediatR;

namespace FinWiseFinance.Application.Queries.GetUserExistentByCpfCnpj
{
    public class GetUserExistentByCpfCnpjQueryHandler(
        IUserRepository _userRepository
        ) : IRequestHandler<GetUserExistentByCpfCnpjQuery, UserViewModel>
    {
        public async Task<UserViewModel> Handle(GetUserExistentByCpfCnpjQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByCpfCnpjAsync(request.CpfCnpj);

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
