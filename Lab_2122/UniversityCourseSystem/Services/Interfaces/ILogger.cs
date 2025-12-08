using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    internal interface ILogger
    {
        internal void Log(string message);
        internal void LogError(string message, Exception ex);
        internal void LogWarning(string message);
    }
}
