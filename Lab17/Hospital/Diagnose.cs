using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    internal class Diagnose
    {
        public int DiagnoseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
