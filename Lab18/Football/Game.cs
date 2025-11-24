using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models

{
    internal class Game
    {
        public int GameId { get; set; }
        public DateTime DateTime { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; } = null!;
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = null!;
        public int HomeTeamBetRate { get; set; }

        public int DrawTeamBetRate { get; set; }
        public int AwayTeamBetRate { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public sbyte Result { get; set; }
        public ICollection<PlayerStatistics> PlayerStatistics { get; set; } = new HashSet<PlayerStatistics>();
        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();

    }
}
