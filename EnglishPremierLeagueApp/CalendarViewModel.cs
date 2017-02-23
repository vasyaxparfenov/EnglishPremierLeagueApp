using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeagueApp
{
    class CalendarViewModel
    {
        public int MatchId { get; set; }
        public string Home { get; set; }
        public string Guest { get; set; }

        public DateTime Date { get; set; }
    }
}
