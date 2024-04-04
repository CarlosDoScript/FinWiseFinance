using FinWiseFinance.Application.ViewModels;
using MediatR;
using System.Net;

namespace FinWiseFinance.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string CpfCnpj { get; set; }
        public string Password { get; set; }
    }
}
