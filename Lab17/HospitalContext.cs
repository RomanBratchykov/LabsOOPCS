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
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Patient> patients { get; set; } = null!;
        public DbSet<Visitation> visitations { get; set; } = null!;
        public DbSet<Diagnose> diagnoses { get; set; } = null!;
        public DbSet<Medicament> medicaments { get; set; } = null!;
        public DbSet<PatientMedicament> patientMedicaments { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.PatientId);

                p.Property(p => p.FirstName).HasMaxLength(50).IsUnicode().IsRequired();

                p.Property(p => p.LastName).HasMaxLength(50).IsUnicode().IsRequired();

                p.Property(p => p.Address).HasMaxLength(250).IsUnicode().IsRequired();

                p.Property(p => p.Email).HasMaxLength(80).IsUnicode(false).IsRequired();

                p.Property(p => p.HasInsurance);
            });

            modelBuilder.Entity<Visitation>(v => {
                v.HasKey(v => v.VisitationId);

               v.Property(v => v.Comments)
                      .HasMaxLength(250)
                      .IsUnicode(true);

                v.HasOne(v => v.Patient)
                      .WithMany(p => p.Visitations)
                            .HasForeignKey(p => p.PatientId);

            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity.Property(d => d.Name)
                      .HasMaxLength(50)
                      .IsUnicode(true)
                      .IsRequired();

                entity.Property(d => d.Comments)
                      .HasMaxLength(250)
                      .IsUnicode(true);

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Diagnoses)
                      .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity.Property(m => m.Name)
                      .HasMaxLength(50)
                      .IsUnicode(true)
                      .IsRequired();
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity.HasOne(pm => pm.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(pm => pm.PatientId);

                entity.HasOne(pm => pm.Medicament)
                      .WithMany(m => m.Prescriptions)
                      .HasForeignKey(pm => pm.MedicamentId);
            });
        }
    }
}

