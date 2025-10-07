using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Rebel : IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
