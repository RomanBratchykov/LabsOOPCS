using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Car
    {
        string model;
        decimal fuelAmount;
        decimal fuelConsumptionPerKm;
        decimal distanceTraveled;
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKm { get; set; }
        public decimal DistanceTraveled { get; set; }
        public Car( string model, decimal fuelAmount, decimal fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            DistanceTraveled = 0;
        }
        public Car()
        {
            Model = "No model";
            FuelAmount = 0;
            FuelConsumptionPerKm = 0;
            DistanceTraveled = 0;
        }

        public bool canDrive(decimal distance)
        {
            decimal neededFuel = distance * FuelConsumptionPerKm;
            if (neededFuel <= FuelAmount)
            {
                FuelAmount -= neededFuel;
                DistanceTraveled += distance;
                return true;
            }
            else
            {
                return false;
            }
        } 
        public void showCar()
        {
            Console.WriteLine($"{Model} {FuelAmount:F2} {DistanceTraveled}");
        }
    }
}
