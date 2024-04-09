using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class BankRepository(FinWiseFinanceDbContext _finWiseFinanceDbContext) : IBankRepository
    {
        public async Task AddAsync(Bank bank)
        {
            await _finWiseFinanceDbContext.AddAsync(bank);
        }
    }
}
