using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Teams
    {
        public Teams()
        {
            GamesGuestTeam = new HashSet<Games>();
            GamesHomeTeam = new HashSet<Games>();
            LeagueTable = new HashSet<LeagueTable>();
            Players = new HashSet<Players>();
            TransfersFrom = new HashSet<Transfers>();
            TransfersTo = new HashSet<Transfers>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public virtual ICollection<Games> GamesGuestTeam { get; set; }
        public virtual ICollection<Games> GamesHomeTeam { get; set; }
        public virtual ICollection<LeagueTable> LeagueTable { get; set; }
        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<Transfers> TransfersFrom { get; set; }
        public virtual ICollection<Transfers> TransfersTo { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual Users Manager { get; set; }
    }
}
