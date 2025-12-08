using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class ConsoleLogger : Interfaces.ILogger
    {
        public void Log(string message)
        {
            AnsiConsole.MarkupLine($"[grey][[LOG]] {message}[/]");
        }
    }
}
