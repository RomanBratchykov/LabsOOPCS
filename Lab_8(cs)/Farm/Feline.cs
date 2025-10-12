using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Farm
{
    internal class Feline : Mammal
    {
        string breed;
        public string Breed 
        { 
            get => breed; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Breed cannot be null or empty");
                }
                breed = value; 
            }
        }
        public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public override string ToString()
        {
            return base.ToString() + $", breed {Breed}";
        }
    }
    internal class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("Meow");
            if (food is Vegetable or Meat)
            {
                base.Eat(food);
                base.Weight += 0.3 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"Cat does not eat {food.GetType}");
            }
        }
        public override string ToString()
        {
            return "Cat: " + base.ToString();
        }
    }
    internal class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("ROAR!!!");
            if (food is Meat)
            {
                base.Eat(food);
                base.Weight += 1 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"Tiger does not eat {food.GetType}");
            }
        }
        public override string ToString()
        {
            return "Tiger: " + base.ToString();
        }
    }
}
