using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class ReportService
    {
        private readonly IEnumerable<IPdfGenerator> _pdfGenerators;
        private readonly IEnumerable<IExcelGenerator> _excelGenerators;
        private readonly IEnumerable<ICsvGenerator> _csvGenerators;
        private readonly IEnumerable<IJsonGenerator> _jsonGenerators;

        private readonly IEnumerable<ICloudUploader> _cloudUploaders;
        private readonly IEnumerable<IDatabaseSaver> _dbSavers;

        public ReportService(
            IEnumerable<IPdfGenerator> pdfGenerators,
            IEnumerable<IExcelGenerator> excelGenerators,
            IEnumerable<ICsvGenerator> csvGenerators,
            IEnumerable<IJsonGenerator> jsonGenerators,
            IEnumerable<ICloudUploader> cloudUploaders,
            IEnumerable<IDatabaseSaver> dbSavers)
        {
            _pdfGenerators = pdfGenerators;
            _excelGenerators = excelGenerators;
            _csvGenerators = csvGenerators;
            _jsonGenerators = jsonGenerators;
            _cloudUploaders = cloudUploaders;
            _dbSavers = dbSavers;
        }

        public void GenerateAndProcessReport(ReportData data, string format)
        {
            object? selectedGenerator = null;
            byte[]? fileBytes = null;
            string? fileString = null;

            AnsiConsole.Status().Start($"Generating {format}...", ctx =>
            {
                if (format == "PDF")
                {
                    var gen = _pdfGenerators.FirstOrDefault(); 
                    if (gen != null) { fileBytes = gen.GeneratePdf(data); selectedGenerator = gen; }
                }
                else if (format == "Excel")
                {
                    var gen = _excelGenerators.FirstOrDefault();
                    if (gen != null) { fileBytes = gen.GenerateExcel(data); selectedGenerator = gen; }
                }
                else if (format == "CSV")
                {
                    var gen = _csvGenerators.FirstOrDefault();
                    if (gen != null) { fileString = gen.GenerateCsv(data); selectedGenerator = gen; }
                }
                else if (format == "JSON")
                {
                    var gen = _jsonGenerators.FirstOrDefault();
                    if (gen != null) { fileString = gen.GenerateJson(data); selectedGenerator = gen; }
                }
            });

            if (selectedGenerator == null)
            {
                AnsiConsole.MarkupLine($"[red]No generator found for format {format}![/]");
                return;
            }

            AnsiConsole.MarkupLine($"[green]✓ {format} Generated successfully![/]");

            var actions = new Dictionary<string, Action>();

            actions.Add("Save Locally", () => Console.WriteLine($"Saved {format} to disk."));

            if (selectedGenerator is IPrintable printable)
            {
                actions.Add("Print", () => printable.Print(fileBytes ?? Encoding.UTF8.GetBytes(fileString)));
            }

            if (selectedGenerator is IEmailSender emailSender)
            {
                actions.Add("Send Email", () => emailSender.SendEmail("prof@uni.edu", "Report", "Attached"));
            }

            if (selectedGenerator is IDatabaseSaver dbSaver && fileString != null)
            {
                actions.Add("Save to DB", () => dbSaver.SaveToDatabase(fileString));
            }

            if (_cloudUploaders.Any())
            {
                actions.Add("Upload to Cloud", () =>
                {
                    var contentBytes = fileBytes ?? (fileString != null ? Encoding.UTF8.GetBytes(fileString) : Array.Empty<byte>());
                    _cloudUploaders.First().UploadToCloud("report", contentBytes, "DefaultProvider");
                });
            }

            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"What to do with this [yellow]{format}[/]?")
                    .AddChoices(actions.Keys));

            actions[actionChoice].Invoke();
        }
    }
}

