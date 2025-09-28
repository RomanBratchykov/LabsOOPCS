using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    enum ToppingEnum
    {
        Meat, 
        Vegetables,
        Cheese,
        Sause
    }
    internal class Toppings
    {
        private const float BaseCaloriesPerGram = 1.2f;
        private const float MeatModifier = 1.2f;
        private const float VegModifier = 0.8f;
        private const float CheeseModifier = 1.1f;
        private const float SauseModifier = 0.9f;
        private ToppingEnum toppingType;
        private float weight;
        public ToppingEnum ToppingType
        {
            get { return toppingType; }
            set
            {
                ToppingEnum type;
                if (!Enum.TryParse<ToppingEnum>(value.ToString(), true, out type))
                {
                    throw new ArgumentException($"Can't put {value.ToString()} on the top of your pizza");
                }
                else
                    toppingType = value;
            }
        }
        public float Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException("Topping weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public Toppings(ToppingEnum toppingType, float weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public float Calories => calculateCalories();
        private float calculateCalories()
        {
            float modifier = 0;
            switch (toppingType)
            {
                case ToppingEnum.Meat:
                    modifier = (float)MeatModifier;
                    break;
                case ToppingEnum.Vegetables:
                    modifier = (float)VegModifier;
                    break;
                case ToppingEnum.Cheese:
                    modifier = (float)CheeseModifier;
                    break;
                case ToppingEnum.Sause:
                    modifier = (float)SauseModifier;
                    break;
            }
            return BaseCaloriesPerGram * weight * modifier;
        }

    }
}
