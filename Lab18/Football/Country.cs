using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    internal class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}
