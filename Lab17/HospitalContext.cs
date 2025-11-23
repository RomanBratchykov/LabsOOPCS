using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    internal class HospitalContext : DbContext
    {
        public DbSet<Patient> patients { get; set; } = null!;
        public DbSet<Visitation> visitations { get; set; } = null!;
        public DbSet<Diagnose> diagnoses { get; set; } = null!;
        public DbSet<Medicament> medicaments { get; set; } = null!;
        public DbSet<PatientMedicament> patientMedicaments { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Trusted_Connection=True;");
            }
        }
    }
}
