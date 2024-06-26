﻿using FinWiseFinance.Core.Entities;

namespace FinWiseFinance.Core.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByCpfCnpjAsync(string cpfCnpj);
        Task<User> GetUserByCpfOrCnpjAndPasswordAsync(string cpfCnpj, string passwordHash);
        Task AddAsync(User user);
    }
}
