using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty; 

        [MaxLength(50)]
        public string NotificationType { get; set; } = "Email";

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } 
    }
}
