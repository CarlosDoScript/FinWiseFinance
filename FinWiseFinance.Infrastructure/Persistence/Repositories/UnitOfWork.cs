using FinWiseFinance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork(FinWiseFinanceDbContext _context) : IUnitOfWork
    {
        public async Task<bool> CommitAsync()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            return success;
        }

        public void Dispose() =>
            _context.Dispose();

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
