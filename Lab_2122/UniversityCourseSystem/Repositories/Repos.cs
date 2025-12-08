using Lab_2122.UniversityCourseSystem.Data;
using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Repositories
{
    internal interface IStudentRepository
    {
        Student GetById(int id);
        List<Student> GetAll();
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);

    }
    internal interface ICourseRepository
    {
        Course GetById(int id);
        List<Course> GetAll();
        void Add(Course course);
        void Update(Course course);
    }
    internal interface IEnrollmentRepository
    {
        void Enroll(int studentId, int courseId);
        List<Enrollment> GetByStudent(int studentId);
        List<Enrollment> GetByCourse(int courseId);
    }
    internal class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _context;

        public StudentRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public Student? GetById(int id) => _context.Students.Find(id);

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
    internal class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _context;

        public CourseRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly UniversityDbContext _context;

        public EnrollmentRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public void Enroll(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public List<Enrollment> GetByStudent(int studentId)
        {
            return _context.Enrollments.Where(e => e.StudentId == studentId).ToList();
        }

        public List<Enrollment> GetByCourse(int courseId)
        {
            return _context.Enrollments.Where(e => e.CourseId == courseId).ToList();
        }
    }

    internal class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(string recipient, byte[] attachment, string subject)
        {
            // Реальна відправка через SMTP
        }
    }

    internal class ConsoleEmailSender : IEmailSender 
    {
        public void SendEmail(string recipient, byte[] attachment, string subject)
        {
            Console.WriteLine($"Email to {recipient}: {subject}");
        }
    }
    internal class NotificationService : INotificationService
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public NotificationService(IEmailSender emailSender, ILogger logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public void NotifyStudentEnrolled(Student student, Course course)
        {
            _emailSender.SendEmail(
                student.Email,
                null,
                "Enrollment Confirmation"
            );
            _logger.Log($"Student {student.Id} enrolled in {course.Id}");
        }

        public void NotifyGradePublished(Student student, Grade grade)
        {
            _emailSender.SendEmail(
                student.Email,
                null,
                "Grade Published"
            );
            _logger.Log($"Grade {grade.Id} published for student {student.Id}");
        }
    }


    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, $"[LOG] {DateTime.Now}: {message}\n");
        }

        public void LogInformation(string message)
        {
            File.AppendAllText(_filePath, $"[INFO] {DateTime.Now}: {message}\n");
        }
        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_filePath, $"[ERROR] {DateTime.Now}: {message}:{ex}\n");
        }
    public void LogWarning(string message)
        {
            File.AppendAllText(_filePath, $"[WARN] {DateTime.Now}: {message}\n");
        }
    }
}
