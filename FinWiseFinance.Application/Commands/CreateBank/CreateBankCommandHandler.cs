using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using MediatR;

namespace FinWiseFinance.Application.Commands.CreateBank
{
    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, int>
    {
        private readonly IBankRepository _bankRepository;

        public CreateBankCommandHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<int> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Bank(request.Title,request.Description);

            await _bankRepository.AddAsync(bank);

            return bank.Id;
        }
    }
}
