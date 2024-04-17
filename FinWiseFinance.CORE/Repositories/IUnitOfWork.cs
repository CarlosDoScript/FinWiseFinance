namespace FinWiseFinance.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task Rollback();
    }
}
