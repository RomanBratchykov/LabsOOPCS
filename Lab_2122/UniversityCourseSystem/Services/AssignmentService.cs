using Lab_2122.UniversityCourseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2122.UniversityCourseSystem.Services.Interfaces;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    internal class AssignmentService
    {
        public void SubmitAssignment(Assignment assignment)
        {
            assignment.Submit();
        }

        public void GradeAssignment(IGradable gradeable, decimal points)
        {
            var grade = gradeable.CalculateGrade(points);
        }

    }
}
