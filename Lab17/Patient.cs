using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = null!;
        public ICollection<Diagnose> Diagnoses { get; set; } = null!;

        public ICollection<PatientMedicament> Prescriptions { get; set; } = null!;

    }
}
