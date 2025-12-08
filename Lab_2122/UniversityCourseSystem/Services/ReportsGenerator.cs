using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class CsvReportGenerator : ICsvGenerator
    {
        public string GenerateCsv(ReportData data)
        {
            Console.WriteLine($"[CSV] Generating CSV data...");
            var sb = new StringBuilder();
            sb.AppendLine("StudentId,Name,Grade");
            foreach (var s in data.Students)
            {
                sb.AppendLine($"{s.Id},{s.FirstName} {s.LastName},N/A");
            }
            return sb.ToString();
        }
    }
     internal class JsonReportGenerator : IJsonGenerator, IDatabaseSaver
    {
        public string GenerateJson(ReportData data)
        {
            Console.WriteLine("Generating JSON...");
            return "{ \"students\": [] }";
        }

        public void SaveToDatabase(ReportData data)
        {
            Console.WriteLine("💾 Saving JSON report to Database...");
        }
    }
    internal class CloudReportService : ICloudUploader
    {
        public void UploadToCloud(string fileName, byte[] content, string cloudProvider)
        {
            Console.WriteLine($"☁️ Uploading {fileName} to Google Drive...");
        }
    }
    internal class EmailReportService : IEmailSender
    {
        public void SendEmail(string recipient, byte[] attachment, string subject)
        {
            Console.WriteLine($"Sending email to {recipient} with subject '{subject}' and attachment of {attachment.Length} bytes.");
        }
    }
    internal class UniversalReportGenerator : IPdfGenerator, IExcelGenerator, ICsvGenerator, IJsonGenerator
    {
        public byte[] GeneratePdf(ReportData data) => Encoding.UTF8.GetBytes("Universal PDF");
        public byte[] GenerateExcel(ReportData data) => Encoding.UTF8.GetBytes("Universal Excel");
        public string GenerateCsv(ReportData data) => "Universal,CSV";
        public string GenerateJson(ReportData data) => "{ \"universal\": true }";
    }

}
