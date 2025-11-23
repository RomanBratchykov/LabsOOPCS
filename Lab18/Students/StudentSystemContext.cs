using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace P01_StudentSystem.Data
{
    internal class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }
        public StudentSystemContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<HomeworkSubmissions> HomeworkSubmissons { get; set;} = null!;
        public DbSet<Student> Students { get; set; }   
        public DbSet<StudentCourses> StudentCourses { get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s => 
            {
                s.HasKey(s => s.StudentId);

                s.Property(s => s.Name)
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired();

                s.Property(s => s.PhoneNumber)
                .IsUnicode(false)
                .HasMaxLength(10)
                .IsRequired(false);

                s.Property(s => s.RegisteredOn)
                .IsRequired();

                s.Property(s => s.Birthday)
                .IsRequired(false);
            });
            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(c => c.CourseId);

                c.Property(c => c.Name)
                      .HasMaxLength(80)
                      .IsUnicode(true)
                      .IsRequired();

               c.Property(c => c.Description)
                      .IsUnicode(true)
                      .IsRequired(false); 
            });

            modelBuilder.Entity<Resource>(r =>
            {
                r.HasKey(r => r.ResourceId);

               r.Property(r => r.Name)
                      .HasMaxLength(50)
                      .IsUnicode(true)
                      .IsRequired();

                r.Property(r => r.Url)
                      .IsUnicode(false) 
                      .IsRequired();

                r.HasOne(r => r.Course)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<HomeworkSubmissions>(h =>
            {
                h.HasKey(h => h.HomeworkId);

                h.Property(h => h.Content)
                      .IsUnicode(false)  
                      .IsRequired();

               h.HasOne(h => h.Student)
                      .WithMany(s => s.HomeworkSubmissions)
                      .HasForeignKey(h => h.StudentId);

                 h.HasOne(h => h.Course)
                      .WithMany(c => c.HomeworkSubmissions)
                      .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.Courses)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.Students)
                      .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}

