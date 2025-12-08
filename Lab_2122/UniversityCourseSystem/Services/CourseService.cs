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
        private readonly IGradeCalculator _calculator;
        private readonly IGradeRepository _repository;
        private readonly INotificationService _notifier;
        private readonly IReportGenerator _reporter;
        private readonly ILogger _logger;

        public CourseService(
            IGradeCalculator calculator,
            IGradeRepository repository,
            INotificationService notifier,
            IReportGenerator reporter,
            ILogger logger)
        {
            _calculator = calculator;
            _repository = repository;
            _notifier = notifier;
            _reporter = reporter;
            _logger = logger;
        }

        public void ProcessFinalGrades(int courseId, ProgressContext? ctx = null)
        {
            _logger.Log($"Starting processing for course {courseId}...");

            var students = _repository.GetStudentsByCourse(courseId);
            var task = ctx?.AddTask($"[green]Processing {students.Count} students...[/]");

            foreach (var student in students)
            {
                decimal finalGrade = _calculator.CalculateFinalGrade(student.Grades.ToList());

                _repository.SaveFinalGrade(student.Id, courseId, finalGrade);

                _notifier.NotifyStudent(student, $"Your final grade is: {finalGrade}");

                task?.Increment(100.0 / students.Count);
                Thread.Sleep(100);
            }

            _reporter.GenerateReport(courseId, students);

            _logger.Log("Processing completed successfully.");
        }
    }
}
