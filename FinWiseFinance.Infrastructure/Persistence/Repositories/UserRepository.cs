using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinWiseFinance.Infrastructure.Persistence.Repositories
{
    public class UserRepository(FinWiseFinanceDbContext _finWiseFinanceDbContext) : IUserRepository
    {
        public async Task<User> GetById(int id)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.Id == id && u.Active);
        }

        public async Task<int> AddAsync(User user)
        {
            await _finWiseFinanceDbContext.AddAsync(user);            
            await _finWiseFinanceDbContext.SaveChangesAsync();

            return user.Id;
        }      

        public async Task<User> GetUserByCpfOrCnpjAndPasswordAsync(string cpfCnpj, string passwordHash)
        {
            return await _finWiseFinanceDbContext.Users.SingleOrDefaultAsync(u => u.CpfCnpj == cpfCnpj && u.Password == passwordHash);
        }
    }
}
