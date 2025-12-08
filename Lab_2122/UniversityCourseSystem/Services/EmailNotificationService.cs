using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;


namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class EmailNotificationService : Interfaces.INotificationService
    {
        private readonly ILogger _logger;
        public EmailNotificationService(ILogger logger)
        {
            _logger = logger;
        }
        public void NotifyStudent(Models.Student student, string message)
        {
            _logger.Log($"Sending email to {student} with message: {message}");
        }
    }
}
