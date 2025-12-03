using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Type)
                .IsRequired();

            builder.Property(pm => pm.UserId)
                .IsRequired();

            builder.Property(pm => pm.BankAccountId)
                .IsRequired(false);

            builder.Property(pm => pm.CreditCardId)
                .IsRequired(false);

            builder.HasOne(pm => pm.User)
                   .WithMany(u => u.PaymentMethods)
                   .HasForeignKey(pm => pm.UserId);

            builder.HasOne(pm => pm.BankAccount)
                   .WithOne(ba => ba.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
                   .IsRequired(false).OnDelete(DeleteBehavior.Cascade); ;

            builder.HasOne(pm => pm.CreditCard)
                   .WithOne(cc => cc.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                   .IsRequired(false).OnDelete(DeleteBehavior.Cascade); ;

            builder.HasIndex(pm => new { pm.UserId, pm.BankAccountId, pm.CreditCardId })
                   .IsUnique(true);

            builder.ToTable("PaymentMethods", t => t.HasCheckConstraint("CH_PaymentMethod_XOR",
                "([BankAccountId] IS NULL AND [CreditCardId] IS NOT NULL) OR ([BankAccountId] IS NOT NULL AND [CreditCardId] IS NULL)"));
        }
    }
}
