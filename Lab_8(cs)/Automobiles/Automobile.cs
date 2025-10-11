using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_cs_.Automobiles
{
    internal interface Automobile
    {
        public decimal AmountOfFuel { get; set; }
        public decimal FuelConsumptionPerKm{ get; set; }
        public decimal TamkVolume { get; set; }
        public decimal MaxDistance { get; }

        public void Refuel(decimal liters);

        public void Drive(decimal km);
        public void ShowInfo();
    }
}
