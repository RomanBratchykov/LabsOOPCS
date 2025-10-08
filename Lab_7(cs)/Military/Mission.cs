using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Mission
    {
        private static readonly string[] validStates = { "inProgress", "Finished" };

        public string CodeName { get; }
        public string State { get; private set; }

        public Mission(string codeName, string state)
        {
            if (!validStates.Contains(state))
                throw new ArgumentException("Invalid mission state");

            CodeName = codeName;
            State = state;
        }

        public void CompleteMission() => State = "Finished";

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
