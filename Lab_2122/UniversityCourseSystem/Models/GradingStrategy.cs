using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    public class GradingStrategy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string StrategyName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")] 
        public string Configuration { get; set; } = "{}";

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
