using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class UserRepository(FinWiseFinanceDbContext _finWiseFinanceDbContext) : IUserRepository
    {
        public async Task<User> GetByIdAsync(int id)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.Id == id && u.Active);
        }
        public async Task<User> GetByCpfCnpjAsync(string cpfCnpj)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.CpfCnpj == cpfCnpj && u.Active);
        }

        public async Task AddAsync(User user)
        {
            await _finWiseFinanceDbContext.AddAsync(user);            
        }

        public async Task<User> GetUserByCpfOrCnpjAndPasswordAsync(string cpfCnpj, string passwordHash)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.CpfCnpj == cpfCnpj && u.Password == passwordHash);
        }

        private bool _disposed = false;

        ~UserRepository() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
                _finWiseFinanceDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
