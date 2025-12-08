using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    internal class Report
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public int ReportTypeId { get; set; }
        [ForeignKey("ReportTypeId")]
        public ReportType? ReportType { get; set; }

        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string GeneratedBy { get; set; } = string.Empty; 

        public int FileSizeBytes { get; set; }
    }
}
