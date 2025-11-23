using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03_SalesDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
                //entity.Property(p => p.Description)
                //      .IsUnicode()
                //      .HasDefaultValue("No description");
                //      .HasMaxLength(250);
                entity.Property(p => p.Price)
                      .IsRequired();
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(100);
                entity.Property(c => c.Email)
                      .IsRequired()
                      .IsUnicode(false)
                      .HasMaxLength(80);
                entity.Property(c => c.CreditCardNumber);
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.StoreId);  
                entity.Property(s => s.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(80);
            });
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);
                //entity.Property<DateTime>("Date")
                //      .HasDefaultValueSql("GETDATE()");
                entity.HasOne(s => s.Product)
                      .WithMany(p => p.Sales)
                      .HasForeignKey(s => s.ProductId);
                entity.HasOne(s => s.Customer)
                      .WithMany(c => c.Sales)
                      .HasForeignKey(s => s.CustomerId);
                entity.HasOne(s => s.Store)
                      .WithMany(st => st.Sales)
                      .HasForeignKey(s => s.StoreId);
            });
        }

    }
}
