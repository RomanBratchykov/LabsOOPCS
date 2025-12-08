using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Models.Assignments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Data
{
    internal class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }    
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<GradingStrategy> GradingStrategies { get; set;}
        public DbSet<Teacher> Teachers { get; set; }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>()
                .HasDiscriminator<string>("AssignmentType")
                .HasValue<Lab>("Lab")
                .HasValue<Exam>("Exam")
                .HasValue<Project>("Project")
                .HasValue<Survey>("Survey")
                .HasValue<Quiz>("Quiz");

            modelBuilder.Entity<Grade>().Property(g => g.Points).HasColumnType("decimal(5,2)");
        }
    }
}
