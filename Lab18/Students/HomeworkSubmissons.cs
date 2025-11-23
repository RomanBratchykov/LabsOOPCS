using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    enum ContentType
    {
        Application,
        PDF,
        ZIP
    }
    internal class HomeworkSubmissions
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; } = null!;
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public Student Student { get; set; } = null!;
        public int StudentId { get; set; }
        public Course Course { get; set; } = null!;
        public int CourseId { get; set; }
    }
}
