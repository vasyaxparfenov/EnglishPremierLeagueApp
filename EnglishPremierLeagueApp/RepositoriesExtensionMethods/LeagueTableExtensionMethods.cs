using System.Collections.Generic;
using System.Linq;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class LeagueTableExtensionMethods
    {
        /// <summary>
        /// Returns league table of certain season based on season name
        /// </summary>
        /// <param name="leagueTableRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<LeagueTable> GetSeasonLeagueTable(this IRepository<LeagueTable> leagueTableRepository, string name)
            => leagueTableRepository
                .Find(table => table.Season.Name.Equals(name))
                .OrderByDescending(table => table.Points)
                .ToList();
        /// <summary>
        /// Returns league table of certain season based on season id
        /// </summary>
        /// <param name="leagueTableRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<LeagueTable> GetSeasonLeagueTable(this IRepository<LeagueTable> leagueTableRepository, int id)
            => leagueTableRepository
                .Find(table => table.SeasonId == id)
                .OrderByDescending(table => table.Points)
                .ToList();

    }
}