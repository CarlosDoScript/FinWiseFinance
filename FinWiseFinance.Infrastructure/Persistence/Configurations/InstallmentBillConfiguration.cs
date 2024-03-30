﻿using FinWiseFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinWiseFinance.Infrastructure.Persistence.Configurations
{
    public class InstallmentBillConfiguration : IEntityTypeConfiguration<InstallmentBill>
    {
        public void Configure(EntityTypeBuilder<InstallmentBill> builder)
        {
            builder
                .ToTable(nameof(InstallmentBill));

            builder
                .HasKey(ib => ib.Id);

            builder
                .Property(ib => ib.Due)
                .HasColumnType("DATETIME");

            builder
                .Property(ib => ib.InstallmentAmount)
                .HasColumnType("DECIMAL (18,2)")
                .HasMaxLength(18);

            builder
                .Property(ib => ib.BarCode)
                .HasMaxLength(255);

            builder
                .Property(ib => ib.CreatedAt)
                .HasColumnType("DATETIME");

            builder
                .HasOne(ib => ib.User)
                .WithMany(ib => ib.InstallmentBills)
                .HasForeignKey(ib => ib.IdUser);

            builder
                .HasOne(ib => ib.Bill)
                .WithMany(ib => ib.InstallmentBills)
                .HasForeignKey(ib => ib.IdBill);

            builder
                .HasOne(ib => ib.Bank)
                .WithMany(ib => ib.InstallmentBills)
                .HasForeignKey(ib => ib.IdBank);
        }
    }
}