using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class EmailNotificationService : INotificationService
    {
        private readonly ILogger _logger;
        public EmailNotificationService(ILogger logger)
        {
            _logger = logger;
        }
        public void NotifyStudent(Models.Student student, string message)
        {
            _logger.Log($"Sending email to {student} with message: {message}");
        }
        public void NotifyStudentEnrolled(Student student, Course course)
        {
            _logger.Log($"Sending email to {student} with message about enrollment to: {course.Name}");
        }
        public void NotifyGradePublished(Student student, Grade grade)
        {
            _logger.Log($"Sending email to {student} that he have grade {grade.Points}");

        }
    }
}
