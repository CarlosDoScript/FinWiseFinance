using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder
                .ToTable(nameof(Bill));

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(b => b.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(b => b.TotalAmountDue)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(b => b.Observation)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(b => b.InstallmentStart)
                .HasColumnType("DATETIME");
            
            builder
                .Property(b => b.CreatedAt)
                .HasColumnType("DATETIME");
        }
    }
}
