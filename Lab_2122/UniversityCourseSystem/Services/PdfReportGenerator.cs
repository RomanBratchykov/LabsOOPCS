using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class PdfReportGenerator : IPdfGenerator, IPrintable, IReportGenerator
    {
        private readonly ILogger _logger;
        public PdfReportGenerator(ILogger logger)
        {
            _logger = logger;
        }
        public void GenerateReport(int courseId, List<Models.Student> students)
        {
            _logger.Log($"Generating PDF report for course {courseId} with {students.Count} students.");
        }
        public byte[] GeneratePdf(ReportData data)
        {
            Console.WriteLine($"[PDF] Generating PDF for course '{data.CourseName}'...");
            return Encoding.UTF8.GetBytes($"PDF Report for {data.CourseName}");
        }

        public void Print(byte[] document)
        {
            Console.WriteLine($"[Print] Printing document ({document.Length} bytes) to physical printer...");
        }
    }
}
