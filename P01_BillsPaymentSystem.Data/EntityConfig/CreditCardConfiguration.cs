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
    internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>    
    {
        public CreditCardConfiguration() { }
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(cc => cc.CreditCardId);

            builder.Property(cc => cc.Limit)
                .IsRequired();

            builder.Property(cc => cc.MoneyOwed)
                .IsRequired();

            builder.Property(cc => cc.ExpirationDate)
                .IsRequired();

            builder.Ignore(cc => cc.LimitLeft);
        }
    }
}
