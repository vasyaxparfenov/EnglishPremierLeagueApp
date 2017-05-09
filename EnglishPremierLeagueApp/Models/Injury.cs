using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Injury
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfInjured { get; set; }
        public DateTime DateOfRecover { get; set; }

        public virtual Players Player { get; set; }
    }
}
