using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateOnly RegisteredOn { get; set; }  
        public DateOnly? Birthday { get; set; }

        public ICollection<HomeworkSubmissions> HomeworkSubmissions { get; set; } = new HashSet<HomeworkSubmissions>();

        public ICollection<StudentCourses> Courses { get; set; } = new HashSet<StudentCourses>();
    }
}
