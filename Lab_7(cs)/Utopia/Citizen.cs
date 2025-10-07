using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Citizen : IEnterable, IShowable, IBirthable, IBuyer
    {
        string id;
        string age;
        string name;
        public int Food { get; private set; } = 0;
        public DateTime BirthDate { get; set; }
        public string Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Age { get { return age; } set { age = value; } }
        public Citizen(string name, string age, string id)
        {
            Id = id;
            Age = age;
            Name = name;
        }
        public Citizen(string name, string age, string id, DateTime dateTime)
        {
            Id = id;
            Age = age;
            Name = name;
            BirthDate = dateTime;
            Food = 0;
        }
        public void Show()
        {
            Console.WriteLine($"Citizen {Id}, {Age}, {Name}");
        }
        public void BuyFood()
        {
            Food += 10;
        }
    }
}
