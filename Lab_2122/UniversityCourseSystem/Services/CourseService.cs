using Lab_2122.UniversityCourseSystem.Repositories;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class CourseService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;

        public CourseService(
        IStudentRepository studentRepo,
        ICourseRepository courseRepo,
        IEnrollmentRepository enrollmentRepo,
        INotificationService notificationService,
        ILogger logger)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
            _enrollmentRepo = enrollmentRepo;
            _notificationService = notificationService;
            _logger = logger;
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            var student = _studentRepo.GetById(studentId);
            var course = _courseRepo.GetById(courseId);

            if (student == null || course == null)
            {
                _logger.LogWarning("Invalid student or course");
                return;
            }

            _enrollmentRepo.Enroll(studentId, courseId);
            _notificationService.NotifyStudentEnrolled(student, course);
            _logger.Log($"Student {studentId} enrolled in {courseId}");
        }
        public void ProcessFinalGrades(int courseId, ProgressContext ctx)
        {
            var task = ctx.AddTask($"Processing final grades for Course ID {courseId}");
            for (int i = 0; i <= 100; i += 10)
            {
                task.Value = i;
                System.Threading.Thread.Sleep(50);
            }
            _logger.Log($"Final grades processed for Course ID {courseId}.");
        }
    }}
