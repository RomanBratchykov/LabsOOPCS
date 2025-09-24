using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    internal class Patient
    {
        private string name;
        Doctor doctor;
        DepartmentEnum department;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        public DepartmentEnum Department
        {
            get { return department; }
            set { department = value; }
        }
    }
}
