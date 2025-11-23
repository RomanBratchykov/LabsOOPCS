using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    internal class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public ResourceType ResourceType { get; set; } 
        public Course Course { get; set; } = null!;
        public int CourseId { get; set; }
    }
}
