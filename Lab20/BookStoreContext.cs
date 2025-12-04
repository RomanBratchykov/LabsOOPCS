using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;


namespace BookShop.Data
{
    internal class BookStoreContext : DbContext
    {

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookCategory> BookCategory { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(
                a =>
                {
                    a.HasKey(a => a.AuthorId);
                    a.Property(a => a.FirstName).IsUnicode().HasMaxLength(50);
                    a.Property(a => a.LastName).IsUnicode().HasMaxLength(50);
                }
                );
            modelBuilder.Entity<Book>( b =>             {
                b.HasKey(b => b.BookId);
                b.Property(b => b.Title).IsUnicode().HasMaxLength(50);
                b.Property(b => b.Description).IsUnicode().HasMaxLength(100);
                b.HasOne(b => b.Author)
                 .WithMany(a => a.Books)
                 .HasForeignKey(b => b.AuthorId);
                b.Property(b => b.ReleaseDate);
                b.Property(b => b.Copies);
                b.Property(b => b.Price).HasColumnType("decimal(10,2)");
                b.Property(b => b.AgeRestriction);
                b.ToTable("Books", t => t.HasCheckConstraint("CH_Book_AgeRestriction_Valid",
        "[AgeRestriction] IN (0, 1, 2)"));
                b.Property(b => b.EditionType);
                b.ToTable("Books", t => t.HasCheckConstraint("CH_Book_EditionType_Valid",
        "[EditionType] IN (0, 1, 2)"));

            }
            );
            modelBuilder.Entity<Category>( c =>
            {
                c.HasKey(c => c.CategoryId);
                c.Property(c => c.Name).IsUnicode().HasMaxLength(50);
            }
            );
            modelBuilder.Entity<BookCategory>( bc =>
            {
                bc.HasKey(bc => new { bc.BookId, bc.CategoryId });
                bc.HasOne(bc => bc.Book)
                  .WithMany(b => b.BookCategory)
                  .HasForeignKey(bc => bc.BookId);
                bc.HasOne(bc => bc.Category)
                  .WithMany(c => c.BookCategories)
                  .HasForeignKey(bc => bc.CategoryId);
            }
            );
        }
    }
}
