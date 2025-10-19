using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class Person : IComparable<Person>
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Town { get; set; } = string.Empty;
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                throw new ArgumentException("Object is not a Person");
            }
            int nameComparison = this.Name.CompareTo(other.Name);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            int ageComparison = this.Age.CompareTo(other.Age);
            if (ageComparison != 0)
            {
                return ageComparison;
            }
            return this.Town.CompareTo(other.Town);
        }
        int IComparable<Person>.CompareTo(Person? other)
        {   
            if (other == null)
            {
                throw new ArgumentException("Object is not a Person");
            }
            int nameComparison = this.Name.CompareTo(other.Name);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            int ageComparison = this.Age.CompareTo(other.Age);
            if (ageComparison != 0)
            {
                return ageComparison;
            }
            return this.Town.CompareTo(other.Town);
        }
    }
}
