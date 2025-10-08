using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Repair
    {
        public string PartName { get; }
        public int HoursWorked { get; }

        public Repair(string part, int hours)
        {
            PartName = part;
            HoursWorked = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
