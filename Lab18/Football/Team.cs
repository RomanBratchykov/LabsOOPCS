using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models

{
    internal class Team
    {
        public enum Initials
        {
            JUV,
            LIV,
            ARS
        }
        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public Initials InitialsTeam { get; set; }
        public decimal Budget { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; } = null!;
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; } = null!;
        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
