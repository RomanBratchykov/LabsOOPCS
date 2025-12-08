using Lab_2122.UniversityCourseSystem.Models;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services
{
    internal interface IGradingStrategy
    {
        decimal Calculate(List<Grade> grades);
    }

    internal class WeightedAverageStrategy : IGradingStrategy
    {
        public decimal Calculate(List<Grade> grades)
        {
            return grades.Any() ? grades.Average(g => g.Points) : 0;
        }
    }

    internal class BestOfNStrategy : IGradingStrategy
    {
        private int _n = 5;
        public decimal Calculate(List<Grade> grades)
        {
            return grades.OrderByDescending(g => g.Points).Take(_n).Average(g => g.Points);
        }
    }
    internal class GradeCalculator : IGradeCalculator
    {
        private IGradingStrategy _strategy;

        public GradeCalculator()
        {
            _strategy = new WeightedAverageStrategy(); 
        }

        public void SetStrategy(IGradingStrategy strategy) => _strategy = strategy;

        public decimal CalculateFinalGrade(List<Grade> grades)
        {
            return _strategy.Calculate(grades);
        }
    }
}
