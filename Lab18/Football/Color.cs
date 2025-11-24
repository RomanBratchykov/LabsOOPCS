using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    internal class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Team> PrimaryKitTeams { get; set; } = null!;

        public ICollection<Team> SecondaryKitTeams { get; set; } = null!;
    }
}
