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
        public DbSet<Courses> Courses { get; set; } = null!;
        public DbSet<Resources> Resources { get; set; } = null!
        public DbSet<HomeworkSubmissons> HomeworkSubmissons { get; set;} = null!;
        public DbSet<Students> Students { get; set; }   
        public DbSet<StudentCourses> StudentCourses { get; set;} = null!;
    }
}
