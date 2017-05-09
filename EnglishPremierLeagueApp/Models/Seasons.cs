using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Seasons
    {
        public Seasons()
        {
            Games = new HashSet<Games>();
            LeagueTable = new HashSet<LeagueTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Games> Games { get; set; }
        public virtual ICollection<LeagueTable> LeagueTable { get; set; }
    }
}
