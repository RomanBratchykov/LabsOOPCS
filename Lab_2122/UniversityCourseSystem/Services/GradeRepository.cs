using Lab_2122.UniversityCourseSystem.Data;
using Lab_2122.UniversityCourseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class GradeRepository : IGradeRepository
    {
        private readonly UniversityDbContext _context;
        public GradeRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudentsByCourse(int courseId)
        {
            return _context.Students
                .Include(s => s.Grades.Where(g => g.Assignment != null && g.Assignment.CourseId == courseId))
                .Where(s => s.Enrollments.Any(e => e.CourseId == courseId))
                .ToList();
        }

        public void SaveFinalGrade(int studentId, int courseId, decimal grade)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment != null)
            {
                enrollment.FinalGrade = grade;
                enrollment.CompletedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }
        }
    }
}
