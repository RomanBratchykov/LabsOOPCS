using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    public interface ILogger
    {
        public void Log(string message);
        public void LogError(string message, Exception ex);
        public void LogWarning(string message);
    }
}
