using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Citizen : IEnterable
    {
        string id;
        string age;
        string name;
        public string Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Age { get { return age; } set { age = value; } }
        public Citizen(string id, string age, string name) 
        {
            Id = id;
            Age = age;
            Name = name;
        }
    }
}
