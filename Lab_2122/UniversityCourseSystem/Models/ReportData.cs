using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    internal class ReportData
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
