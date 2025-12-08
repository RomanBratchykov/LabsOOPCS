using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class ExcelReportGenerator : IExcelGenerator, IEmailSender
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
        public byte[] GenerateExcel(ReportData data)
        {
            Console.WriteLine($"[Excel] Generating .xlsx for course '{data.CourseName}'...");
            return Encoding.UTF8.GetBytes($"Excel Data for {data.CourseName}");
        }

        public void SendEmail(string recipient, byte[] attachment, string subject)
        {
            Console.WriteLine($"Sending email to {recipient} with subject '{subject}' and attachment of {attachment.Length} bytes.");
        }
    }
}
