using System.Collections.Generic;
using System.Linq;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class PlayersRepositoryExtensionMethods
    {
        /// <summary>
        /// Returns a list of top goal scorers based on minimum number of goals and in certain season
        /// </summary>
        /// <param name="playersRepository"></param>
        /// <param name="minimumNumberOfGoals"></param>
        /// <param name="seasonName"></param>
        /// <returns></returns>
        public static IEnumerable<Players> GetTopGoalScorers(this IRepository<Players> playersRepository ,int minimumNumberOfGoals, string seasonName) 
            => playersRepository
                .Find(
                     player =>
                        player.Goals.Count > minimumNumberOfGoals &&
                        player.Goals.Where(goal => goal.Game.Season.Name == seasonName).ToList().Count > 0)
                .OrderByDescending(player => player.Goals.Count)
                .ToList();

        /// <summary>
        /// Returns a list of players based on query of search
        /// </summary>
        /// <param name="playersRepository"></param>
        /// <param name="keyToSearch"></param>
        /// <returns></returns>
        public static IEnumerable<Players> Search(this IRepository<Players> playersRepository ,string keyToSearch) 
            => playersRepository
                .Find(player => player.Name.StartsWith(keyToSearch))
                .OrderByDescending(player => player.Name)
                .ToList();
        
        /// <summary>
        /// Returns a list of players based on price gap
        /// </summary>
        /// <param name="playersRepository"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        public static IEnumerable<Players> SearchAccordingPriceGap(this IRepository<Players> playersRepository ,decimal minPrice, decimal maxPrice) 
            => playersRepository
                .Find(player => player.Fee >= minPrice && player.Fee <= maxPrice)
                .OrderByDescending(player => player.Fee)
                .ToList();
        /// <summary>
        /// Returns a roster (list of players) of certain team based on id
        /// </summary>
        /// <param name="playersRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Players> GetPlayersFromTeam(this IRepository<Players> playersRepository ,int id) 
            => playersRepository
                .Find(player => player.TeamId == id)
                .ToList();
        /// <summary>
        /// Returns a roster (list of players) of certain team based on name
        /// </summary>
        /// <param name="playersRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Players> GetPlayersFromTeam(this IRepository<Players> playersRepository, string name) 
            => playersRepository
                .Find(player => player.Team.Name == name)
                .ToList();

    }
}