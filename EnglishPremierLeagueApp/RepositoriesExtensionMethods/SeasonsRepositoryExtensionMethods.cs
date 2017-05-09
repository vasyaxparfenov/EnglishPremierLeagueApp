using System;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class SeasonsRepositoryExtensionMethods
    {
        /// <summary>
        /// Returns current season based on current date
        /// </summary>
        /// <param name="seasonsRepository"></param>
        /// <param name="selectedDateTime"></param>
        /// <returns></returns>
        public static Seasons GetCurrentSeason(this IRepository<Seasons> seasonsRepository, DateTime selectedDateTime)
            => seasonsRepository
                .SingleOrDefault(
                    season =>
                        DateTime.Compare(season.BeginDate, selectedDateTime) < 0 &&
                        DateTime.Compare(season.EndDate, selectedDateTime) > 0);

    }
}