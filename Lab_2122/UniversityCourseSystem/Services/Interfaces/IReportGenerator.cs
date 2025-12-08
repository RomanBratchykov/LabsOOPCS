using Lab_2122.UniversityCourseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    internal interface IReportGenerator
    {
        void GenerateReport(int courseId, List<Student> students);
    }
    internal interface IPdfGenerator
    {
        byte[] GeneratePdf(ReportData data);
    }
    internal interface IExcelGenerator
    {
        byte[] GenerateExcel(ReportData data);
    }
    internal interface ICsvGenerator
    {
        string GenerateCsv(ReportData data);
    }
    internal interface IJsonGenerator
    {
        string GenerateJson(ReportData data);
    }
    internal interface IEmailSender
    {
        void SendEmail(string recipient, byte[] attachment, string subject);
    }
    internal interface IPrintable
    {
        void Print(byte[] document);
    }
    internal interface ICloudUploader
    {
        void UploadToCloud(string fileName, byte[] content, string cloudProvider);
    }
    internal interface IDatabaseSaver
    {
        void SaveToDatabase(ReportData data);
    }

}
