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
        private Dictionary<DepartmentEnum, Department> departments;
        private Dictionary<string, Doctor> doctors;

        public Hospital()
        {
            departments = new Dictionary<DepartmentEnum, Department>();
            doctors = new Dictionary<string, Doctor>();

            foreach (DepartmentEnum dep in Enum.GetValues(typeof(DepartmentEnum)))
            {
                departments[dep] = new Department(dep);
            }
        }

        public void AddPatient(string depName, string doctorName, string patientName)
        {
            if (!Enum.TryParse(depName, true, out DepartmentEnum dep))
            {
                Console.WriteLine($"Unknown department {depName}");
            }

            if (!doctors.ContainsKey(doctorName))
                doctors[doctorName] = new Doctor(doctorName);

            var patient = new Patient(patientName);

            if (departments[dep].TryAddPatient(patient))
            {
                doctors[doctorName].addPatient(patient);
            }
            else
            {
                Console.WriteLine($"Patient {patientName} needs to be transfered, there is no place in {dep}");
            }
        }

        public void PrintDepartment(string depName)
        {
            if (!Enum.TryParse(depName, true, out DepartmentEnum dep)) return;

            foreach (var p in departments[dep].GetAllPatientsInOrder())
                Console.WriteLine(p.Name);
        }


        public void PrintRoom(string depName, int roomNumber)
        {
            if (!Enum.TryParse(depName, true, out DepartmentEnum dep)) return;
            var room = departments[dep].Rooms[roomNumber - 1];
            foreach (var p in room.Beds.OrderBy(x => x.Name))
                Console.WriteLine(p.Name);
        }

        public void PrintDoctor(string doctorName)
        {
            if (!doctors.ContainsKey(doctorName)) return;
            foreach (var p in doctors[doctorName].Patients.OrderBy(x => x.Name))
                Console.WriteLine(p.Name);
        }
    }
}
