using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public BankAccountConfiguration() { }
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);

            builder.Property(ba => ba.Balance)
                .IsRequired();

            builder.Property(ba => ba.BankName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(ba => ba.SWIFTCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
