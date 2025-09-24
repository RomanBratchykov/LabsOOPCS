using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    enum DepartmentEnum
    {
        Therapy,
        Surgery,
        Cardiology,
        Neurology,
        Oncology
    }
    internal class Hospital
    {
        private List<Doctor> doctors;
        private List<Patient> patients;
        public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }
        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
        public Hospital()
        {
            doctors = new List<Doctor>();
            patients = new List<Patient>();
        }
        public Hospital(List<Doctor> doctors, List<Patient> patients)
        {
            this.doctors = doctors;
            this.patients = patients;
        }
        public void addDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public void addPatient(Patient patient)
        {
            patients.Add(patient);
        }
    }
}
