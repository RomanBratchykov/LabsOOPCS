using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        = null!;
        public string Description { get; set; } = null!;
        public DateOnly  StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public ICollection<HomeworkSubmissions> HomeworkSubmissions { get; set; } = new HashSet<HomeworkSubmissions>();

        public ICollection<StudentCourses> Students = new HashSet<StudentCourses>();
    }
}
