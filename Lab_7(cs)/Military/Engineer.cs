using Lab_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7_cs_.Military
{
    internal class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<Repair> repairs;
        public IReadOnlyCollection<Repair> Repairs => repairs.AsReadOnly();

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<Repair>();
        }

        public void AddRepair(Repair r) => repairs.Add(r);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Corps:");
            sb.AppendLine("  " + Corps);
            sb.AppendLine("Repairs:");
            foreach (var r in repairs)
                sb.AppendLine("  " + r.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
