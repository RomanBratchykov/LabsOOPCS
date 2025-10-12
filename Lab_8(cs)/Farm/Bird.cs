using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Farm
{
    internal class Bird : Animal
    {
        double wingSize;
        public double WingSize 
        { 
            get => wingSize;
            set 
            {
                if (value <= 0)
                {
                    throw new Exception("Wing size must be positive");
                }
                wingSize = value;
            } 
        }
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }
        public override string ToString()
        {
            return base.ToString() + $", wing size{WingSize}";
        }
    }
    internal class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("Hoot Hoot");
            if (food is Meat)
            {
                base.Eat(food);
                base.Weight +=0.25 * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"Owl does not eat {food.GetType}");
            }
        }
        public override string ToString() 
        {
            return "Owl: " + base.ToString();
        }
    }
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override void Eat(Food food)
        {
            Console.WriteLine("Cluck");
            base.Eat(food);
            base.Weight += 0.35 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return "Hen: " + base.ToString();
        }
    }
}
