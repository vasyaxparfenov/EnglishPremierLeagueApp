using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Goals
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Minute { get; set; }

        public virtual Games Game { get; set; }
        public virtual Players Player { get; set; }
    }
}
