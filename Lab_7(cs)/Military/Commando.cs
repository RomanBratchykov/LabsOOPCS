using Lab_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<Mission> missions;
        public IReadOnlyCollection<Mission> Missions => missions.AsReadOnly();

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<Mission>();
        }

        public void AddMission(Mission m) => missions.Add(m);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Corps:");
            sb.AppendLine("  " + Corps);
            sb.AppendLine("Missions:");
            foreach (var m in missions)
                sb.AppendLine("  " + m.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
