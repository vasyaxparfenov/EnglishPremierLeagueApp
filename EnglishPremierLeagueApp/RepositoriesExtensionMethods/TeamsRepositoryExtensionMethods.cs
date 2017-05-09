using System.Collections.Generic;
using System.Linq;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class TeamsRepositoryExtensionMethods
    {
        /// <summary>
        /// Returns a list of teams except certain team based on name
        /// </summary>
        /// <param name="teamsRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Teams> GetAllTeamsExcept(this IRepository<Teams> teamsRepository ,string name) 
            => teamsRepository
                .Find(team => !team.Name.Equals(name))
                .ToList();
        /// <summary>
        /// Returns a list of teams except certain team based on id
        /// </summary>
        /// <param name="teamsRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Teams> GetAllTeamsExcept(this IRepository<Teams> teamsRepository, int id)
            => teamsRepository
                .Find(team => team.Id != id)
                .ToList();

        /// <summary>
        /// Returns a roster (list of players) of certain team based on id
        /// </summary>
        /// <param name="teamsRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Players> GetRoster(this IRepository<Teams> teamsRepository, int id) 
            => teamsRepository
                .SingleOrDefault(team => team.Id == id).Players
                .ToList();

        /// <summary>
        /// Returns a roster (list of players) of certain team based on name
        /// </summary>
        /// <param name="teamsRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Players> GetRoster(this IRepository<Teams> teamsRepository, string name) 
            => teamsRepository
                .SingleOrDefault(team => team.Name.Equals(name)).Players
            .ToList();

        /// <summary>
        /// Returns a team with certain name
        /// </summary>
        /// <param name="teamsRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Teams GetTeamByName(this IRepository<Teams> teamsRepository, string name) 
            => teamsRepository
                .SingleOrDefault(team => team.Name.Equals(name));
    }
}