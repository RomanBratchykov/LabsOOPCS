using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Models.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Data
{
    public class UniversityDbContextFactory : IDesignTimeDbContextFactory<UniversityDbContext>
    {
        public UniversityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniversityDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new UniversityDbContext(optionsBuilder.Options);
        }
    }
    public class UniversityDbContext : DbContext
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

            modelBuilder.Entity<Grade>().Property(g => g.Points).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Enrollment>().Property(e => e.FinalGrade).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Lab>();
            modelBuilder.Entity<Exam>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<Survey>();
            modelBuilder.Entity<Quiz>();

            modelBuilder.Entity<Assignment>()
                .HasDiscriminator<string>("Assignment_Discriminator")
                .HasValue(typeof(Lab), "Lab")
                .HasValue(typeof(Exam), "Exam")
                .HasValue(typeof(Project), "Project")
                .HasValue(typeof(Survey), "Survey")
                .HasValue(typeof(Quiz), "Quiz");


            modelBuilder.Entity<AssignmentType>().HasData(
                new AssignmentType { Id = 1, TypeName = "Lab", IsGradeable = true },
                new AssignmentType { Id = 2, TypeName = "Exam", IsGradeable = true },
                new AssignmentType { Id = 3, TypeName = "Project", IsGradeable = true },
                new AssignmentType { Id = 4, TypeName = "Survey", IsGradeable = false },
                new AssignmentType { Id = 5, TypeName = "Quiz", IsGradeable = false }
            );

            modelBuilder.Entity<GradingStrategy>().HasData(
                new GradingStrategy { Id = 1, StrategyName = "WeightedAverage", Configuration = "{}" },
                new GradingStrategy { Id = 2, StrategyName = "BestOfN", Configuration = "{}" }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "Alan", LastName = "Turing", Email = "alan@uni.edu" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "CS101 - OOP", Code = "CS101", Credits = 5, TeacherId = 1, GradingStrategyId = 1 }
            );

            modelBuilder.Entity<ReportType>().HasData(
                new ReportType { Id = 1, TypeName = "PDF" },
                new ReportType { Id = 2, TypeName = "Excel" },
                new ReportType { Id = 3, TypeName = "CSV" },
                new ReportType { Id = 4, TypeName = "JSON" }
            );
        }
    }
}
