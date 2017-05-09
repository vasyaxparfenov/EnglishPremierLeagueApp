using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Games
    {
        public Games()
        {
            Goals = new HashSet<Goals>();
        }

        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? GuestTeamScore { get; set; }
        public DateTime DateOfGame { get; set; }
        public int SeasonId { get; set; }

        public virtual ICollection<Goals> Goals { get; set; }
        public virtual Teams GuestTeam { get; set; }
        public virtual Teams HomeTeam { get; set; }
        public virtual Seasons Season { get; set; }
    }
}
