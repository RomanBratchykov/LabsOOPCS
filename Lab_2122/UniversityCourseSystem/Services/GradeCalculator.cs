using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal class GradeCalculator : Interfaces.IGradeCalculator
    {
        public decimal CalculateFinalGrade(List<Grade> grades)
        {
            decimal finalGrade = 0m;
            if (grades is null || grades.Count == 0) return 0m;
            return grades.Average(g => g.Points);
        }
    }
}
