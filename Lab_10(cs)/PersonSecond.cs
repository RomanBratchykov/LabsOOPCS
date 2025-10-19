using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class PersonSecond
    {
        string? name;
        int age;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Name length cannot exceed 50 characters.");
                }
                name = value;
            }
        }
        public int Age 
        {
            get
            {   
                return age;
            }
            set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new Exception("Age must be between 1 and 99.");
                }
                age = value;
            }
        }
        public PersonSecond(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void PrintPerson()
        {
            Console.WriteLine($"{Name} {Age}");
        }

    }
}
