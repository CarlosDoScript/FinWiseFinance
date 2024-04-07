using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly FinWiseFinanceDbContext _finWiseFinanceDbContext;
        public BankRepository(FinWiseFinanceDbContext finWiseFinanceDbContext)
        {
            _finWiseFinanceDbContext = finWiseFinanceDbContext;
        }

        public async Task AddAsync(Bank bank)
        {
            await _finWiseFinanceDbContext.AddAsync(bank);
        }
    }
}
