using Lab_2122.UniversityCourseSystem.Data;
using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Models.Assignments;
using Lab_2122.UniversityCourseSystem.Services;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Program;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<ILogger, ConsoleLogger>();
        services.AddDbContext<UniversityDbContext>(options =>
        options.UseSqlServer("Server=localhost;Database=UniversityDB;Trusted_Connection=True;TrustServerS"));
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddTransient<IGradeCalculator, GradeCalculator>();
        services.AddTransient<INotificationService, EmailNotificationService>();
        services.AddTransient<IReportGenerator, PdfReportGenerator>();
        services.AddTransient<CourseService>(); 

        var provider = services.BuildServiceProvider();

        using (var scope = provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();
            db.Database.EnsureCreated();
        }

        AnsiConsole.Write(new FigletText("Course Manager").Color(Color.Teal));
        var service = provider.GetRequiredService<CourseService>();

        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select an option:")
                    .AddChoices("Process Final Grades", "Exit"));

            if (choice == "Exit") break;

            if (choice == "Process Final Grades")
            {
                var courseId = AnsiConsole.Ask<int>("Enter Course ID (e.g. 1):");

                AnsiConsole.Progress()
                    .Start(ctx =>
                    {
                        service.ProcessFinalGrades(courseId, ctx);
                    });

                var table = new Table();
                table.AddColumn("Status");
                table.AddColumn("Message");
                table.AddRow("[green]Success[/]", "Grades calculated and saved.");
                AnsiConsole.Write(table);

                AnsiConsole.MarkupLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}