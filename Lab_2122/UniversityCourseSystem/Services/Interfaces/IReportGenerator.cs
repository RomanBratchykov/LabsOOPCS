using Lab_2122.UniversityCourseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    public interface IReportGenerator
    {
        void GenerateReport(int courseId, List<Student> students);
    }
    public interface IPdfGenerator
    {
        byte[] GeneratePdf(ReportData data);
    }
    public interface IExcelGenerator
    {
        byte[] GenerateExcel(ReportData data);
    }
    public interface ICsvGenerator
    {
        string GenerateCsv(ReportData data);
    }
    public interface IJsonGenerator
    {
        string GenerateJson(ReportData data);
    }
    public interface IEmailSender
    {
        void SendEmail(string recipient, byte[] attachment, string subject);
    }
    public interface IPrintable
    {
        void Print(byte[] document);
    }
    public interface ICloudUploader
    {
        void UploadToCloud(string fileName, byte[] content, string cloudProvider);
    }
    public interface IDatabaseSaver
    {
        void SaveToDatabase(ReportData data);
    }

}
