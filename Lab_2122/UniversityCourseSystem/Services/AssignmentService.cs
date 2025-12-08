using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    public class AssignmentService
    {
        private readonly ILogger _logger;

        public AssignmentService(ILogger logger)
        {
            _logger = logger;
        }
        public void SubmitAssignment(Assignment assignment)
        {
            assignment.Submit();

            _logger.Log($"Assignment '{assignment.Title}' (ID: {assignment.Id}) was processed via Service.");

            AnsiConsole.MarkupLine($"[green]✓ Successfully submitted: {assignment.Title}[/]");
        }

        public void GradeAssignment(IGradable gradeable, decimal points)
        {
            var grade = gradeable.CalculateGrade(points);


            if (gradeable is Assignment assignment)
            {
                _logger.Log($"Graded assignment '{assignment.Title}': {grade}/{gradeable.MaxPoints} points.");
            }

            AnsiConsole.MarkupLine($"[blue]ℹ Grade Calculated: {grade}[/]");
        }
    }
}
