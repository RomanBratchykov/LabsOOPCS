using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_cs_
{
    enum DoughType
    {
        White, Wholegrain
    }
    enum BakingTechnique
    {
        Crispy, Chewy, Homemade
    }
    internal class Dough
    {
        private const decimal BaseCaloriesPerGram = 2m;
        private const decimal WhiteModifier = 1.5m;
        private const decimal WholegrainModifier = 1.0m;
        private const decimal CrispyModifier = 0.9m;
        private const decimal ChewyModifier = 1.1m;
        private const decimal HomemadeModifier = 1.0m;
        private DoughType doughType;
        private BakingTechnique bakingTechnique;
        private decimal weight;
        public DoughType DoughType
        {
            get { return doughType; }
            set
            {
                DoughType type;
                if (!Enum.TryParse<DoughType>(value.ToString(), true, out type))
                {
                    throw new ArgumentException("Invalid dough type");
                }
                else
                    doughType = value; 
            }
        }
        public BakingTechnique BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                BakingTechnique technique;
                if (!Enum.TryParse<BakingTechnique>(value.ToString(), true, out technique))
                {
                    throw new ArgumentException("Invalid technique type");
                }
                else
                    bakingTechnique = value; 
            }
        }
        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public decimal Calories => CalculateCalories();
        public Dough(DoughType doughType, BakingTechnique bakingTechnique, decimal weight)
        {
            this.DoughType = doughType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        private decimal CalculateCalories()
        {
            decimal typeModifier = doughType == DoughType.White ? WhiteModifier : WholegrainModifier;
            decimal techniqueModifier = bakingTechnique switch
            {
                BakingTechnique.Crispy => CrispyModifier,
                BakingTechnique.Chewy => ChewyModifier,
                BakingTechnique.Homemade => HomemadeModifier,
                _ => throw new ArgumentOutOfRangeException()
            };
            return BaseCaloriesPerGram * weight * typeModifier * techniqueModifier;
        }
    }
}
