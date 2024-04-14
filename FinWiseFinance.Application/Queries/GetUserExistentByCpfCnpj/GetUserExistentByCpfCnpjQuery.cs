using FinWiseFinance.Application.ViewModels;
using MediatR;

namespace FinWiseFinance.Application.Queries.GetUserExistentByCpfCnpj
{
    public class GetUserExistentByCpfCnpjQuery : IRequest<UserViewModel>
    {
        public GetUserExistentByCpfCnpjQuery(string cpfCnpj)
        {
            CpfCnpj = cpfCnpj;
        }

        public string CpfCnpj { get; private set; }
    }
}
