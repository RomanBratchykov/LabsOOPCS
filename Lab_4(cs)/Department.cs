using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    internal class Department
    {
        private const int RoomCount = 20;
        public DepartmentEnum DepartmentType { get; private set; }
        public List<Room> Rooms { get; private set; }

        public Department(DepartmentEnum departmentType)
        {
            DepartmentType = departmentType;
            Rooms = new List<Room>();
            for (int i = 0; i < RoomCount; i++)
                Rooms.Add(new Room());
        }

        public bool TryAddPatient(Patient patient)
        {
            foreach (var room in Rooms)
            {
                if (room.HasFreeBed)
                {
                    room.AddPatient(patient);
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Patient> GetAllPatientsInOrder()
        {
            return Rooms.SelectMany(r => r.Beds);
        }
    }
}
