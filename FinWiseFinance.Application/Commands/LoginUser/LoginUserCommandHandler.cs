using FinWiseFinance.Application.ViewModels;
using FinWiseFinance.Core.Repositories;
using FinWiseFinance.Core.Services;
using MediatR;

namespace FinWiseFinance.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler(
        IAuthService _authService,
        IUserRepository _userRepository
        ) : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
       

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByCpfOrCnpjAndPasswordAsync(request.CpfCnpj, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.FullName,user.Email,user.CpfCnpj);


            return new LoginUserViewModel(user.CpfCnpj,token);
        }
    }
}
