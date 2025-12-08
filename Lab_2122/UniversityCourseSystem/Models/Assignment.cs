using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    public abstract class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public int AssignmentTypeId { get; set; }
        [ForeignKey("AssignmentTypeId")]
        public AssignmentType? AssignmentType { get; set; }

        public int MaxPoints { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsGradeable { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public abstract void Submit();
    }
}
