using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private static readonly string[] validCorps = { "Airforces", "Marines" };
        public string Corps { get; }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            if (!validCorps.Contains(corps))
                throw new ArgumentException("Invalid corps");
            Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {Corps}";
        }
    }
}
