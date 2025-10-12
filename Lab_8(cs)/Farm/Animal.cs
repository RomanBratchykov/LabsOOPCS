using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Farm
{
    internal abstract class Animal
    {
        string name;
        double weight;
        public string Name 
        { 
            get { return name; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be null or empty");
                }
                name = value; 
            } 
        }
        public double Weight { 
            get => weight; 
            set 
            {
                if (value <= 0)
                {
                   throw new Exception("Weight must be positive");
                }
                weight = value;
            } 
        }
        public int FoodEaten { get; set; }
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }
        public virtual void Eat(Food food)
        {

        }
        public override string ToString() { return $"name {Name}, weight {Weight}, food eaten {FoodEaten}"; }
    }
}
