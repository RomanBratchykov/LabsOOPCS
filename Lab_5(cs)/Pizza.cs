using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Pizza
    {
        private string name;
        private Dough dough;
        private List<Toppings> toppings;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("value cant be empty");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value cant be empty");
                }
                dough = value;
            }
        }
        public List<Toppings> Toppings { get { return toppings; } set { toppings = new List<Toppings>(); } }

        public Pizza(string name, Dough dough) {
            this.Dough = dough;
            this.Name = name;
            this.Toppings = new List<Toppings>();
        }
        public void AddToppings(Toppings toppings) 
        {
            if (toppings == null)
            {
                throw new ArgumentNullException("topping cant be null");
            }
            Toppings.Add(toppings);
        }
        public float Calories => calculateCalories();

        private float calculateCalories() 
        {
            float result = 0;
            float toppingCalories = 0;
            foreach (var topping in Toppings)
            {
                toppingCalories += (float)topping.Calories;
            }
            result = dough.Calories + toppingCalories;
            return result;
        }
    }
}
