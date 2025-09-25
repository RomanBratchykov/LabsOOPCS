using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    internal class Room
    {
        private const int BedsCount = 3;
        public List<Patient> Beds { get; private set; }

        public Room()
        {
            Beds = new List<Patient>();
        }

        public bool HasFreeBed => Beds.Count < BedsCount;

        public void AddPatient(Patient patient)
        {
            if (HasFreeBed)
                Beds.Add(patient);
        }
    }
}
