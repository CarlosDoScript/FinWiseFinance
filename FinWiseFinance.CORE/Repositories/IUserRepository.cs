using FinWiseFinance.Core.Entities;

namespace FinWiseFinance.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetUserByCpfOrCnpjAndPasswordAsync(string cpfCnpj, string passwordHash);
        Task<int> AddAsync(User user);
    }
}
