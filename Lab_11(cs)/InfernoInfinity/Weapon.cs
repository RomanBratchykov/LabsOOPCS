using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_cs_.InfernoInfinity
{
    public enum WeaponRarity
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 5
    }
    public enum WeaponType
    {
        Axe,
        Sword,
        Knife
    }
    public enum GemType 
    {
        Ruby,
        Emerald,
        Amethyst
    }
    public enum GemClarity
    {
        Chipped = 1,
        Regular = 2,
        Perfect = 5,
        Flawless = 10
    }
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", new string[] { "Петро","Степан"})]
    internal class Weapon
    {
        string name;
        WeaponType type;
        WeaponRarity rarity;
        int minDamage;
        int maxDamage;
        List<KeyValuePair<GemType, GemClarity>> gems;
        int agility;
        int vetality;
        int strength;
        int numberOfSockets;

        public string Name { get { return name; } set { name = value; } }
        public int MinDamage { get { return minDamage; } set { minDamage = value; } }
        public int MaxDamage { get { return maxDamage; } set { maxDamage = value; } }
        public List<KeyValuePair<GemType, GemClarity>> Gems { get { return gems; } set { gems = value; } }
        public int Agility { get { return agility; } set { agility= value; } }
        public int Vetality { get { return vetality; } set { vetality = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public int NumberOfSockets { get { return numberOfSockets; } set { numberOfSockets = value; } }
        public WeaponRarity Rarity { get { return rarity; } set { rarity = value; } }
        public WeaponType Type { get { return type; } set { type = value; } }
        public Weapon(string type, string name)
        {
            string[] weaponValue = type.Split();
            if (weaponValue.Length != 2)
            {
                throw new ArgumentException("Wrong input of type of weapon, should be 'rarity typeWeapon'");
            }

            if (Enum.TryParse<WeaponType>(weaponValue[1], out var parsedType))
            {
                this.Type = parsedType;
                if (parsedType.ToString() == "Axe")
                {
                    this.MinDamage = 5;
                    this.MaxDamage = 10;
                    this.NumberOfSockets = 4;
                }
                else if (parsedType.ToString() == "Sword")
                {
                    this.MinDamage = 4;
                    this.MaxDamage = 6;
                    this.NumberOfSockets = 3;
                }
                else if (parsedType.ToString() == "Knife")
                {
                    this.MinDamage = 3;
                    this.MaxDamage = 4;
                    this.NumberOfSockets = 2;
                }
            }
            else
            {
                throw new ArgumentException($"Invalid weapon type: {weaponValue[1]}");
            }

            if (Enum.TryParse<WeaponRarity>(weaponValue[0], out var parsedRarity))
            {
           
                this.Rarity = parsedRarity;
                int multiplier = (int)parsedRarity;
                this.MinDamage *= multiplier;
                this.MaxDamage *= multiplier;
            }
            else
            {
                throw new ArgumentException($"Invalid weapon rarity: {weaponValue[0]}");
            }

            this.Name = name;
            this.Gems = new List<KeyValuePair<GemType, GemClarity>>(this.NumberOfSockets);
            for (int i = 0; i < this.NumberOfSockets; i++)
            {
                this.Gems.Add(default);
            }
            this.Agility = 0;
            this.Vetality = 0;
            this.Strength = 0;
        }
        public void AddGem(int socketIndex, string gemInput)
        {
            if (socketIndex < 0 || socketIndex >= this.numberOfSockets)
            {
                throw new ArgumentException("Invalid socket index");
            }
            string[] gemValues = gemInput.Split();
            if (gemValues.Length != 2)
            {
                throw new ArgumentException("Wrong input of gem, should be 'gemType gemClarity'");
            }
            if (Enum.TryParse<GemType>(gemValues[0], out var parsedGemType) &&
                Enum.TryParse<GemClarity>(gemValues[1], out var parsedGemClarity))
            {
                var gem = new KeyValuePair<GemType, GemClarity>(parsedGemType, parsedGemClarity);
                Console.WriteLine(gem);
                if (parsedGemType.ToString() == "Ruby")
                {
                    this.Strength += (7 * (int)parsedGemClarity);
                    this.Vetality += (5 * (int)parsedGemClarity);
                    this.Agility += (2 * (int)parsedGemClarity);

                }
                else if (parsedGemType.ToString() == "Emerald")
                {
                    this.Strength += (1 * (int)parsedGemClarity);
                    this.Vetality += (9 * (int)parsedGemClarity);
                    this.Agility += (4 * (int)parsedGemClarity);
                }
                else if (parsedGemType.ToString() == "Amethyst")
                {
                    this.Strength += (2 * (int)parsedGemClarity);
                    this.Vetality += (4 * (int)parsedGemClarity);
                    this.Agility += (8 * (int)parsedGemClarity);
                }
                    this.gems[socketIndex] = gem;
            }
            else
            {
                throw new ArgumentException("Invalid gem type or clarity");
            }
        }
        public void RemoveGem(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex >= this.numberOfSockets)
            {
                throw new ArgumentException("Invalid socket index");
            }
            if (EqualityComparer<KeyValuePair<GemType, GemClarity>>.Default.Equals(gems[socketIndex], default(KeyValuePair<GemType, GemClarity>)))
            {
                Console.WriteLine("No gem to remove in this socket");
                return;
            }
            var gemToRemove = this.gems[socketIndex];
            var gemType = gemToRemove.Key;
            var gemClarity = gemToRemove.Value;
            if (gemType.ToString() == "Ruby")
            {
                this.Strength -= (7 * (int)gemClarity);
                this.Vetality -= (5 * (int)gemClarity);
                this.Agility -= (2 * (int)gemClarity);
            }
            else if (gemType.ToString() == "Emerald")
            {
                this.Strength -= (1 * (int)gemClarity);
                this.Vetality -= (9 * (int)gemClarity);
                this.Agility -= (4 * (int)gemClarity);
            }
            else if (gemType.ToString() == "Amethyst")
            {
                this.Strength -= (2 * (int)gemClarity);
                this.Vetality -= (4 * (int)gemClarity);
                this.Agility -= (8 * (int)gemClarity);
            }
            this.gems.RemoveAt(socketIndex);
        }
        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vetality} Vetality";
        }
    }
}
