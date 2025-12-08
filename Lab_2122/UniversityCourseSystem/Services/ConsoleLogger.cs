using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"[LOG] {message}");
        public void LogInformation(string message) => Console.WriteLine($"[INFO] {message}");
        public void LogError(string message, Exception ex) => Console.WriteLine($"[ERROR] {message}:{ex}");
        public void LogWarning(string message) => Console.WriteLine($"[WARN] {message}");
    }
}
