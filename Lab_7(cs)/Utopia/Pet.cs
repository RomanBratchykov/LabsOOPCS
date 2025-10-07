using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Pet : IShowable, IBirthable
    {
        string name;
        public DateTime BirthDate { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public Pet(string name, DateTime dateTime)
        {
            Name = name;
            BirthDate = dateTime;
        }
        public void Show()
        {
            Console.WriteLine($"Pet {Name}");
        }
    }
}
