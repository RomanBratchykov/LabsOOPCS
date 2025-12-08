using Lab_2122.UniversityCourseSystem.Data;
using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Models.Assignments;
using Lab_2122.UniversityCourseSystem.Repositories;
using Lab_2122.UniversityCourseSystem.Services;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using System.Text;

class Program
{
    private static ServiceProvider _provider;
    private static IServiceCollection _services;
    public static void Main(string[] args)
    {
        _services.AddDbContext<UniversityDbContext>();
        _services.AddScoped<IStudentRepository, StudentRepository>();
        _services.AddScoped<ICourseRepository, CourseRepository>();
        _services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        _services.AddTransient<IEmailSender, ConsoleEmailSender>();
        _services.AddTransient<INotificationService, NotificationService>();
        _services.AddSingleton<ILogger, ConsoleLogger>(); 
        _services.AddTransient<CourseService>();
        var serviceProvider = _services.BuildServiceProvider();
        var courseService = serviceProvider.GetRequiredService<CourseService>();
        ConfigureServices(useRealDb: true, useRealEmail: false);
        SeedData(); 

        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("SOLID LAB").Color(Color.Teal));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Виберіть модуль лабораторної:[/]")
                    .AddChoices(
                        "1. SRP (Course Management)",
                        "2. LSP (Assignment Management)",
                        "3. ISP (Report Generation)",
                        "4. DIP (Enrollment & Config)",
                        "Exit"));

            if (choice == "Exit") break;

            switch (choice)
            {
                case "1. SRP (Course Management)":
                    ShowSrpMenu();
                    break;
                case "2. LSP (Assignment Management)":
                    ShowLspMenu();
                    break;
                case "3. ISP (Report Generation)":
                    ShowIspMenu();
                    break;
                case "4. DIP (Enrollment & Config)":
                    ShowDipMenu();
                    break;
            }
        }
    }

    private static void ConfigureServices(bool useRealDb, bool useRealEmail)
    {
        _services = new ServiceCollection();

        // Database
        if (useRealDb)
        {
            _services.AddDbContext<UniversityDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UniversityDB;Trusted_Connection=True;"));
            _services.AddScoped<IStudentRepository, StudentRepository>();
            _services.AddScoped<ICourseRepository, CourseRepository>();
        }
        else
        {
            _services.AddScoped<IStudentRepository, StudentRepository>(); 
            _services.AddScoped<ICourseRepository, CourseRepository>();
        }

        _services.AddScoped<IGradeRepository, GradeRepository>();
        _services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

        _services.AddSingleton<ILogger, ConsoleLogger>();
        _services.AddTransient<IGradeCalculator, GradeCalculator>();

        if (useRealEmail)
            _services.AddTransient<IEmailSender, SmtpEmailSender>(); // Припустимо, він є
        else
            _services.AddTransient<IEmailSender, ConsoleEmailSender>();

        _services.AddTransient<INotificationService, NotificationService>();

        _services.AddTransient<IPdfGenerator, PdfReportGenerator>();
        _services.AddTransient<IExcelGenerator, ExcelReportGenerator>();
        _services.AddTransient<ICsvGenerator, CsvReportGenerator>();
        _services.AddTransient<IJsonGenerator, JsonReportGenerator>();
        _services.AddTransient<ICloudUploader, CloudReportService>();
        _services.AddTransient<IDatabaseSaver, JsonReportGenerator>(); // JSON вміє зберігати в БД

        _services.AddTransient<CourseService>();
        _services.AddTransient<ReportService>();

        _provider = _services.BuildServiceProvider();
    }

    private static void ShowSrpMenu()
    {
        Console.Clear();
        AnsiConsole.Write(new Rule("[blue]University Course Management System (SRP)[/]"));

        var service = _provider.GetRequiredService<CourseService>();

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices("Process Final Grades", "View Course Statistics", "Back"));

        if (action == "Process Final Grades")
        {
            var courseChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Course:")
                    .AddChoices("CS101 - Programming Fundamentals", "CS102 - Data Structures"));

            int courseId = 1; 

            AnsiConsole.MarkupLine($"Processing grades for [bold]{courseChoice.Split('-')[0].Trim()}[/]...");

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task = ctx.AddTask("[green]Calculating...[/]");
                    service.ProcessFinalGrades(courseId, ctx); // Передаємо контекст для оновлення
                });

            AnsiConsole.MarkupLine("[bold]Final Results:[/]");
            var table = new Table();
            table.AddColumn("Student");
            table.AddColumn("Name");
            table.AddColumn("Grade");

            table.AddRow("STU001", "John Doe", "[green]85.5[/]");
            table.AddRow("STU002", "Jane Smith", "[green]92.0[/]");
            AnsiConsole.Write(table);
        }

        Pause();
    }

    private static void ShowLspMenu()
    {
        Console.Clear();
        AnsiConsole.Write(new Rule("[purple]Assignment Management (LSP)[/]"));

        var assignmentService = _provider.GetRequiredService<AssignmentService>();

        // Get logger instance from DI container
        var logger = _provider.GetRequiredService<ILogger>();

        var assignments = new List<Assignment>
        {
            new Lab(logger) { Id = 1, Title = "Lab 1: Variables", MaxPoints = 100 },
            new Exam(logger) { Id = 2, Title = "Midterm Exam", MaxPoints = 120 },
            new Project(logger) { Id = 3, Title = "Final Project", MaxPoints = 200 },
            new Survey(logger) { Id = 4, Title = "Course Feedback", IsAnonymous = true },
            new Quiz(logger) { Id = 5, Title = "Self-check Quiz", isOptional = true }
        };

        AnsiConsole.MarkupLine("Course: [bold]CS101 - Programming Fundamentals[/]");
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Title");
        table.AddColumn("Type");
        table.AddColumn("Gradable");

        foreach (var a in assignments)
        {
            string type = a.GetType().Name;
            string gradable = a is IGradable ? "[green]✓[/]" : "[red]✗[/]";
            table.AddRow(a.Id.ToString(), a.Title, type, gradable);
        }
        AnsiConsole.Write(table);

        var selectedTitle = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select assignment:")
                .AddChoices(assignments.Select(a => $"{a.Id}. {a.Title}")));

        var selectedAssignment = assignments.First(a => $"{a.Id}. {a.Title}" == selectedTitle);

        AnsiConsole.MarkupLine($"Actions for [bold]\"{selectedAssignment.Title}\"[/]:");

        var actions = new List<string> { "Submit Assignment" };

        if (selectedAssignment is IGradable)
            actions.Add("Grade Assignment");

        if (selectedAssignment is Survey)
            actions.Add("View Survey Results");

        actions.Add("View Details");
        actions.Add("Back");

        var action = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(actions));

        if (action == "Submit Assignment")
        {
            assignmentService.SubmitAssignment(selectedAssignment);
        }
        else if (action == "Grade Assignment" && selectedAssignment is IGradable gradeable)
        {
            assignmentService.GradeAssignment(gradeable, 85);
        }
        else if (action == "View Survey Results" && selectedAssignment is Survey survey)
        {
            AnsiConsole.MarkupLine("[yellow]Survey Results:[/]");
            AnsiConsole.MarkupLine("- Response rate: 92%");
            AnsiConsole.MarkupLine("- Average satisfaction: 4.5/5");
        }

        Pause();
    }

    private static void ShowIspMenu()
    {
        Console.Clear();
        AnsiConsole.Write(new Rule("[orange1]Report Generation System (ISP)[/]"));

        var reportService = _provider.GetRequiredService<ReportService>();
        var data = new ReportData { CourseId = 101, CourseName = "CS101" };

        var format = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Report Format:")
                .AddChoices("PDF", "Excel", "CSV", "JSON", "Compare Features"));

        if (format == "Compare Features")
        {
            ShowFeatureComparison();
        }
        else
        {
            reportService.GenerateAndProcessReport(data, format);
        }

        Pause();
    }

    private static void ShowFeatureComparison()
    {
        var table = new Table().Title("Feature Comparison Matrix");
        table.AddColumns("Format", "PDF", "Excel", "CSV", "JSON", "Email", "Print", "Cloud");

        table.AddRow("PDF Gen", "✓", "✗", "✗", "✗", "✗", "✓", "✗");
        table.AddRow("Excel Gen", "✗", "✓", "✗", "✗", "✓", "✗", "✗");
        table.AddRow("CSV Gen", "✗", "✗", "✓", "✗", "✗", "✗", "✗");
        table.AddRow("Cloud Svc", "✗", "✗", "✗", "✗", "✗", "✗", "✓");

        AnsiConsole.Write(table);
    }

    private static void ShowDipMenu()
    {
        Console.Clear();
        AnsiConsole.Write(new Rule("[red]Configuration & DI (DIP)[/]"));

        var logger = _provider.GetRequiredService<ILogger>();
        var courseService = _provider.GetRequiredService<CourseService>();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("DIP Options:")
                .AddChoices(
                    "Enroll Student",
                    "View Logs (Simulated)",
                    "Change Email Provider (SMTP <-> Console)",
                    "Back"));

        if (choice == "Enroll Student")
        {
            AnsiConsole.MarkupLine("Enrolling student [green]STU001[/] to course [green]1[/]...");
            courseService.EnrollStudent(1, 1);
        }
        else if (choice == "Change Email Provider (SMTP <-> Console)")
        {
            var providerType = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Email Provider Implementation:")
                    .AddChoices("Console Mock (Testing)", "Real SMTP (Production)"));

            bool useReal = providerType.Contains("SMTP");

            AnsiConsole.Status().Start("Rebuilding Dependency Injection Container...", ctx =>
            {
                Thread.Sleep(1000); 
                ConfigureServices(useRealDb: true, useRealEmail: useReal);
            });

            AnsiConsole.MarkupLine($"[green]✓ Configuration updated to use {(useReal ? "SMTP" : "Console")} provider![/]");
            AnsiConsole.MarkupLine("[grey]Note: The entire app has been re-initialized.[/]");
        }

        Pause();
    }

    private static void Pause()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Markup("[grey]Press any key to continue...[/]"));
        Console.ReadKey();
    }

    private static void SeedData()
    {
        using (var scope = _provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}