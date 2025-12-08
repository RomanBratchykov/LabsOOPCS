using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Models
{
    internal class ReportType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string FileExtension { get; set; } = string.Empty;

        [MaxLength(100)]
        public string MimeType { get; set; } = string.Empty;

        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
