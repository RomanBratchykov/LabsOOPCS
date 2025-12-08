using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] 
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)] 
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)] 
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string StudentNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
