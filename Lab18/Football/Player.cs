using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models

{
    internal class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = null!;
        public int SquadNumber { get; set; }
        public bool IsInjured { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
        public ICollection<PlayerStatistics> PlayerStatistics { get; set; } = new HashSet<PlayerStatistics>();

    }
}
