using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
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
        private const float BaseCaloriesPerGram = 2f;
        private const float WhiteModifier = 1.5f;
        private const float WholegrainModifier = 1.0f;
        private const float CrispyModifier = 0.9f;
        private const float ChewyModifier = 1.1f;
        private const float HomemadeModifier = 1.0f;
        private DoughType doughType;
        private BakingTechnique bakingTechnique;
        private float weight;
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
        public float Weight
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
        public float Calories => CalculateCalories();
        public Dough(DoughType doughType, BakingTechnique bakingTechnique, float weight)
        {
            this.DoughType = doughType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        private float CalculateCalories()
        {
            float typeModifier = doughType == DoughType.White ? WhiteModifier : WholegrainModifier;
            float techniqueModifier = bakingTechnique switch
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
