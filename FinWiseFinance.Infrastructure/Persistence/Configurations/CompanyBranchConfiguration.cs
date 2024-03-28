using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class CompanyBranchConfiguration : IEntityTypeConfiguration<CompanyBranch>
    {
        public void Configure(EntityTypeBuilder<CompanyBranch> builder)
        {
            builder
                .ToTable(nameof(CompanyBranch));

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
               .Property(c => c.Description)
               .HasColumnType("VARCHAR")
               .HasMaxLength(255);

            builder
               .Property(b => b.CreatedAt)
               .HasColumnType("DATETIME");


        }
    }
}
