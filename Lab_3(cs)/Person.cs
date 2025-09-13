using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Person
    {
        private string? name;
        private int age;
        public string? Name {get; set; }
        public int Age { get; set; }
        public Person(string? name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person (int age)
        {
            this.Name = "No name";
            this.Age = age;
        }
    }
}
