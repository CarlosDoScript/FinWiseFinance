using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder
                .ToTable(nameof(Bank));

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
               .Property(b => b.Description)               
               .HasColumnName("Description")
               .HasColumnType("VARCHAR")
               .HasMaxLength(255);

            builder.Property(b => b.Active);
        }
    }
}
