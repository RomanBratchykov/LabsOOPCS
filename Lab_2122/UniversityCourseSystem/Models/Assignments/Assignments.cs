using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models.Assignments
{
    internal class Exam : Assignment, IGradable
    {
        private readonly ILogger _logger;
        public Exam(ILogger logger)
        {
            _logger = logger;
        }
        public string ExamType { get; set; } = "Written"; 
        public int DurationMinutes { get; set; }
        public new int MaxPoints { get; set; }

        public string GetDescription() => $"Exam '{Title}' of type '{ExamType}' lasting {DurationMinutes} minutes.";
        public override void Submit()
        {
          _logger.Log($"Exam '{Title}' of type '{ExamType}' submitted.");
        }

        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"You have completed the exam '{Title}'.";
        }
    }
    internal class Project : Assignment, IGradable
    {
        private readonly ILogger _logger;
        public Project(ILogger logger)
        {
            _logger = logger;
        }
        public int TeamSize { get; set; }
        public new int MaxPoints { get; set; }

        public string GetDescription() => $"Project '{Title}' with team size {TeamSize} ";
        public override void Submit()
        {
            _logger.Log($"Project '{Title}' submitted.");
        }

        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"Project '{Title}' was great.";
        }
    }
    internal class Lab : Assignment, IGradable
    {
        private readonly ILogger _logger;
        public Lab(ILogger logger)
        {
            _logger = logger;
        }
        public int LabNumber { get; set; }
        public new int MaxPoints { get; set; }
        public string GetDescription() => $"Lab '{Title}'with number '{LabNumber}' ";
        public override void Submit()
        {
            _logger.Log($"Lab '{Title}' with number'{LabNumber}' submitted.");
        }
        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"You have completed the lab '{Title}'.";
        }
    }
    internal class Quiz : Assignment
    {
        private readonly ILogger _logger;
        public Quiz(ILogger logger)
        {
            _logger = logger;
        }
        public bool isOptional { get; set; }
        public int AttemptCount { get; set; }
        public string GetDescription()
        {
            string optionality = isOptional ? "optional" : "mandatory";
            return $"Quiz '{Title}' is {optionality} with '{AttemptCount}' attempts allowed.";
        }
        public override void Submit()
        {
            _logger.Log($"Quiz '{Title}' questions submitted.");
        }
        public void ShowCorrectAnswers()
        {
            _logger.Log($"Showing correct answers for Quiz '{Title}'.");
        }
    }
}
