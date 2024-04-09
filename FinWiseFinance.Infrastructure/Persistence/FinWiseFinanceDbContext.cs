using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinWiseFinance.Infrastructure.Persistence
{
    public class FinWiseFinanceDbContext(DbContextOptions<FinWiseFinanceDbContext> options) : DbContext(options)
    {
        #region DbSet
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CompanyBranch> CompanyBranches { get; set; }
        public DbSet<DailyExpense> DailyExpenses { get; set; }
        public DbSet<InstallmentBill> InstallmentBills { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<PurchaseObjectiveHistory> PurchaseObjectiveHistories { get; set; }
        public DbSet<PurchaseTarget> PurchaseTargets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfession> UserProfessions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
