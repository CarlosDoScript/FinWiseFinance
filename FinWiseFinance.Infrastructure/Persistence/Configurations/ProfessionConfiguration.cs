using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder
                .ToTable(nameof(Profession));

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
                .Property(p => p.CreatedAt)
                .HasColumnType("DATETIME");
        }
    }
}
