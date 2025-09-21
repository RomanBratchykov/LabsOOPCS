using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Engine
    {
        string model;
        decimal power;
        decimal volume;
        string efficiency;
        public string Model { get; set; }
        public decimal Power { get; set; }
        public decimal Volume { get; set; }
        public string Efficiency { get; set; }
        public Engine(string model, decimal power, decimal volume, string efficiency)
        {
            Model = model;
            Power = power;
            Volume = volume;
            Efficiency = efficiency;
        }
        public Engine()
        {
            Model = "No model";
            Power = 0;
            Volume = 0;
            Efficiency = "n/a";
        }
        public Engine(string model, decimal power)
        {
            Model = model;
            Power = power;
            Volume = 0;
            Efficiency = "n/a";
        }
    }
}
