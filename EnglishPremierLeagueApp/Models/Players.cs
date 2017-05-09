using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Players
    {
        public Players()
        {
            Goals = new HashSet<Goals>();
            Injury = new HashSet<Injury>();
            Transfers = new HashSet<Transfers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public decimal Fee { get; set; }
        public string Position { get; set; }
        public bool IsInjured { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Goals> Goals { get; set; }
        public virtual ICollection<Injury> Injury { get; set; }
        public virtual ICollection<Transfers> Transfers { get; set; }
        public virtual Teams Team { get; set; }
    }
}
