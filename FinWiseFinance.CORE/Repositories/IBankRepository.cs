using FinWiseFinance.Core.Entities;

namespace FinWiseFinance.Core.Repositories
{
    public interface IBankRepository
    {
        Task AddAsync(Bank bank);
    }
}
