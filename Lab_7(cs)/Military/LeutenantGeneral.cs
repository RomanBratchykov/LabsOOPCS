using Lab_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private readonly List<IPrivate> privates;
        public IReadOnlyCollection<IPrivate> Privates => privates.AsReadOnly();

        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public void AddPrivate(IPrivate p) => privates.Add(p);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var p in privates)
                sb.AppendLine("  " + p.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
