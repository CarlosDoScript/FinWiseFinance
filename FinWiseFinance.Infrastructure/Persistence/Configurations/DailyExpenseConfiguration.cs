using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class DailyExpenseConfiguration : IEntityTypeConfiguration<DailyExpense>
    {
        public void Configure(EntityTypeBuilder<DailyExpense> builder)
        {
            builder
                .ToTable(nameof(DailyExpense));

            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(d => d.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(d => d.Amount)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(d => d.CreatedAt)
                .HasColumnType("DATETIME");

            builder
                .HasOne(d => d.User)
                .WithMany(d => d.DailyExpenses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.Bank)
                .WithMany(d => d.DailyExpenses)
                .HasForeignKey(d => d.IdBank)
                .OnDelete(DeleteBehavior.Restrict);
            ;
        }
    }
}
