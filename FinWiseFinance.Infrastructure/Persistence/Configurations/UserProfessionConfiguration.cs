using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class UserProfessionConfiguration : IEntityTypeConfiguration<UserProfession>
    {
        public void Configure(EntityTypeBuilder<UserProfession> builder)
        {
            builder
                .ToTable(nameof(UserProfession));

            builder 
                .HasKey(x => x.Id);

            builder
                .Property(u => u.CreatedAt)
                .HasColumnType("DATETIME");


            // RELAÇÃO DE MUITOS PARA MUITOS
            builder
                .HasOne(u => u.User)
                .WithMany(up => up.UserProfessions)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Profession)
                .WithMany(up => up.UserProfessions)
                .HasForeignKey(u => u.IdProfession)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
