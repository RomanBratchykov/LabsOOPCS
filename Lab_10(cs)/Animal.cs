using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class Animal
    {
        public string Name{get; set;}
        public int Age{get; set; }
        public string Species{get; set; }
        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
        }
    }
}
