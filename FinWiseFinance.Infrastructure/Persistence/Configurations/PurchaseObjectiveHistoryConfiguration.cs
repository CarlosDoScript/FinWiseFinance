using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class PurchaseObjectiveHistoryConfiguration : IEntityTypeConfiguration<PurchaseObjectiveHistory>
    {
        public void Configure(EntityTypeBuilder<PurchaseObjectiveHistory> builder)
        {
            builder
                .ToTable(nameof(PurchaseObjectiveHistory));

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(p => p.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(p => p.Amount)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("DATETIME");

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.PurchaseObjectiveHistories)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.PurchaseTarget)
                .WithMany(p => p.PurchaseObjectiveHistories)
                .HasForeignKey(p => p.IdPurchaseTarget)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
