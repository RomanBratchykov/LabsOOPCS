using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class ExcelReportGenerator : Interfaces.IReportGenerator
    {
        private readonly ILogger _logger;
        public ExcelReportGenerator(ILogger logger)
        {
            _logger = logger;
        }
        public void GenerateReport(int courseId, List<Models.Student> students)
        {
            _logger.Log($"Generating excel report for course {courseId} with {students.Count} students.");
        }
    }
}
