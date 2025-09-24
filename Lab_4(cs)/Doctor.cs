using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    internal class Doctor
    {
        private string name;
        private List<Patient> patients;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
        public Doctor(string name, List<Patient> patients)
        {
            this.name = name;
            this.patients = patients;
        }
    }
}
