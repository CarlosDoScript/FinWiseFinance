using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinWiseFinanceDbContext _finWiseFinanceDbContext;
        public UserRepository(FinWiseFinanceDbContext finWiseFinanceDbContext)
        {
            _finWiseFinanceDbContext = finWiseFinanceDbContext;
        }

        public async Task<User> GetUserByCpfOrCnpjAndPasswordAsync(string cpfCnpj, string passwordHash)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.CpfCnpj == cpfCnpj && u.Password == passwordHash);
        }
    }
}
