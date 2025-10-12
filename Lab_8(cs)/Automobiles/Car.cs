using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Automobiles

{
    internal class Car : Automobile
    {
        public Car(decimal amountOfFuel, decimal litersPerKm, decimal tankVolume) 
        {
            TamkVolume = tankVolume;
            FuelConsumptionPerKm = litersPerKm + 0.9m;
            if (amountOfFuel > tankVolume)
            {
                AmountOfFuel = 0;
            }
            else
                AmountOfFuel = amountOfFuel;
        }
        public decimal AmountOfFuel { get; set; }
        public decimal FuelConsumptionPerKm { get; set; }
        public decimal TamkVolume { get; set; }
        public decimal MaxDistance
        {
            get
            {
                return AmountOfFuel / FuelConsumptionPerKm;
            }
        }
        public void Refuel(decimal liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Liters must be greater than zero.");
            }
            if (AmountOfFuel + liters > TamkVolume)
            {
                throw new InvalidOperationException("Cannot refuel beyond tank volume.");
            }
            AmountOfFuel += liters;
            Console.WriteLine($"Car was filled with {liters} l");
        }
        public void Drive(decimal km)
        {
            if (km <= 0)
            {
                throw new ArgumentException("Distance must be greater than zero.");
            }
            decimal requiredFuel = km * FuelConsumptionPerKm;
            if (requiredFuel > AmountOfFuel)
            {
                               throw new InvalidOperationException("Not enough fuel to drive the requested distance.");
            }
            AmountOfFuel -= requiredFuel;
            Console.WriteLine($"Car drove {km} km");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Car Info: Amount of Fuel = {AmountOfFuel:F2} liters, Fuel Consumption = {FuelConsumptionPerKm:F2} liters/km, Tank Volume = {TamkVolume:F2} liters, Max Distance = {MaxDistance:F2} km");
        }
    }
}
