using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Farm
{
    internal abstract class Food
    {
        int quantity;
        public int Quantity {
            get => quantity;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Quantity must be positive");
                }
                quantity = value;
            } 
        }
        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
    internal class Vegetable : Food
    {
        public Vegetable(int quantity) : base(quantity) { }
    }
    internal class Meat : Food {
        public Meat(int quantity) : base(quantity) { }
    }
    internal class Fruit : Food 
    {
        public Fruit(int quantity) : base(quantity) { }
    }
    internal class Seed : Food 
    {
        public Seed(int quantity) : base(quantity)
        {
        }
    }
}
