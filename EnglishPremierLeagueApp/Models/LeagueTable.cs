using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class LeagueTable
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int TeamId { get; set; }
        public int Points { get; set; }

        public virtual Seasons Season { get; set; }
        public virtual Teams Team { get; set; }
    }
}
