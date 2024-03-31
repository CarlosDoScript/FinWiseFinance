using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class PurchaseTargetConfiguration : IEntityTypeConfiguration<PurchaseTarget>
    {
        public void Configure(EntityTypeBuilder<PurchaseTarget> builder)
        {
            builder
                .ToTable(nameof(PurchaseTarget));

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
                .Property(p => p.Link)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(p => p.SpecifiedValue)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);
            
            builder
                .Property(p => p.CombinedTotal)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("DATETIME");

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.PurchaseTargets)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Bank)
                .WithMany(p => p.PurchaseTargets)
                .HasForeignKey(p => p.IdBank)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
