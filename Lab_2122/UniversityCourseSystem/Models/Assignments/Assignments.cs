using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models.Assignments
{
    public class Exam : Assignment, IGradable
    {
        public string ExamType { get; set; } = "Written"; 
        public int DurationMinutes { get; set; }
        public new int MaxPoints { get; set; }

        public string GetDescription() => $"Exam '{Title}' of type '{ExamType}' lasting {DurationMinutes} minutes.";
        public override void Submit()
        {
            Console.WriteLine($"Exam '{Title}' of type '{ExamType}' submitted.");
        }

        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"You have completed the exam '{Title}'.";
        }
    }
    public class Project : Assignment, IGradable
    {
        public int TeamSize { get; set; }
        public new int MaxPoints { get; set; }

        public string GetDescription() => $"Project '{Title}' with team size {TeamSize} ";
        public override void Submit()
        {
            Console.WriteLine($"Project '{Title}' submitted.");
        }

        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"Project '{Title}' was great.";
        }
    }
    public class Lab : Assignment, IGradable
    {
        public int LabNumber { get; set; }
        public new int MaxPoints { get; set; }
        public string GetDescription() => $"Lab '{Title}'with number '{LabNumber}' ";
        public override void Submit()
        {
            Console.WriteLine($"Lab '{Title}' with number'{LabNumber}' submitted.");
        }
        public decimal CalculateGrade(decimal points) => points;
        public string GetFeedback()
        {
            return $"You have completed the lab '{Title}'.";
        }
    }
   public class Quiz : Assignment
    {
        public bool isOptional { get; set; }
        public int AttemptCount { get; set; }
        public string GetDescription()
        {
            string optionality = isOptional ? "optional" : "mandatory";
            return $"Quiz '{Title}' is {optionality} with '{AttemptCount}' attempts allowed.";
        }
        public override void Submit()
        {
            Console.WriteLine($"Quiz '{Title}' questions submitted.");
        }
        public void ShowCorrectAnswers()
        {
            Console.WriteLine($"Showing correct answers for Quiz '{Title}'.");
        }
    }
    public class Survey : Assignment
    {
        public bool IsAnonymous { get; set; }
        public int QuestionCount { get; set; }
        public string GetDescription()

        {  
            string state = IsAnonymous ? "anonymous" : "identified";
            return $"Survey '{Title}' with '{QuestionCount}' questions. was {state}";
        }
        public override void Submit()
        {
            Console.WriteLine($"Survey '{Title}' responses submitted.");
        }
        public void AnalyzeResponses()
        {
            Console.WriteLine($"Analyzing responses for Survey '{Title}'.");
        }
    }
}
