using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(nameof(User));

            builder
                .HasKey(x => x.Id);

            builder
                .Property(u => u.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(u => u.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(u => u.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(u => u.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);
            
            builder
                .Property(u => u.Income)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(u => u.CorporateReason)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);
            
            builder
                .Property(u => u.CpfCnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder
                .Property(u => u.DayOfReceipt)
                .HasColumnType("DATETIME");

            builder
                .Property(u => u.BirthDate)
                .HasColumnType("DATETIME");

            builder
                .Property(u => u.CreatedAt)
                .HasColumnType("DATETIME");

            builder
                .Property(u => u.Password)
                .HasColumnType("VARCHAR(MAX)");

            builder.Property(u => u.IdCompanyBranch)
               .HasColumnName("IdCompanyBranch")
               .HasColumnType("INT");

            builder
                .HasOne(u => u.CompanyBranch)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.IdCompanyBranch)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
