using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    internal class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext() { }
        public BillsPaymentSystemContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<CreditCard> CreditCards { get; set; } = null!;
        public DbSet<BankAccount> BankAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.UserId);
                u.Property(
                    u => u.FirstName
                ).HasMaxLength(50).IsUnicode(true);
                u.Property(
                    u => u.LastName
                ).HasMaxLength(50).IsUnicode(true);
                u.Property(
                    u => u.Email
                ).HasMaxLength(80).IsUnicode(false);
                u.Property(
                    u => u.Password
                ).HasMaxLength(25).IsUnicode(false);
            });
            modelBuilder.Entity<PaymentMethod>(pm =>
            {
                pm.HasKey(pm => pm.Id);
                pm.HasOne(pm => pm.User)
                    .WithMany(u => u.PaymentMethods)
                    .HasForeignKey(pm => pm.UserId);
                pm.Property(pm => pm.Type).IsRequired();

            });
        }
    }
}
