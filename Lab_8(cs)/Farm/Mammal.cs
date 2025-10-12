using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Farm
{
    internal class Mammal : Animal
    {
        string livingRegion;
        public string LivingRegion 
        { 
            get => livingRegion; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Living region cannot be null or empty");
                }
                livingRegion = value; 
            } 
        }
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public override string ToString()
        {
            return base.ToString() + $", living region {LivingRegion}";
        }
    }
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("Squeak");
            if (food is Vegetable or Fruit)
            {
                base.Eat(food);
                base.Weight += 0.1 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"Mouse does not eat {food.GetType}");
            }
        }
        public override string ToString()
        {
            return "Mouse: " + base.ToString();
        }
    }
    internal class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("Woof!");
            if (food is Meat)
            {
                base.Eat(food);
                base.Weight += 0.4 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"Dog does not eat {food.GetType}");
            }
        }
        public override string ToString()
        {
            return "Dog: " + base.ToString();
        }
    }
}
