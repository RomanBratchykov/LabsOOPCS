using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Automobile
    {
        string model;
        Engine engine;
        decimal weight;
        string color;
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public Automobile(string model, Engine engine, decimal weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public Automobile()
        {
            Model = "No model";
            Engine = new Engine();
            Weight = 0;
            Color = "n/a";
        }
        public Automobile(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 1000;
            Color = "n/a";
        }
        public void showAutomobile()
        {
            Console.WriteLine($"{Model}:");
            Console.WriteLine($"  {Engine.Model}:");
            Console.WriteLine($"    Power: {Engine.Power}");
            if (Engine.Volume == 0)
            {
                Console.WriteLine($"    Volume: n/a");
            }
            else
            {
                Console.WriteLine($"    Volume: {Engine.Volume}");
            }
            Console.WriteLine($"    Efficiency: {Engine.Efficiency}");
            if (Weight == 0)
            {
                Console.WriteLine($"  Weight: n/a");
            }
            else
            {
                Console.WriteLine($"  Weight: {Weight}");
            }
            Console.WriteLine($"  Color: {Color}");
        }
    }
}
