using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class GamesRepositoryExtensionMethods
    {
        /// <summary>
        /// Returns a list of all played games
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetPlayedGames(this IRepository<Games> gamesRepository) 
            => gamesRepository
                .Find(
                    game =>
                        DateTime.Compare(game.DateOfGame, DateTime.Now) <= 0 && game.GuestTeamScore.HasValue &&
                        game.HomeTeamScore.HasValue)
                .ToList();

        /// <summary>
        /// Returns a list of played games by certain team based on id
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetPlayedGames(this IRepository<Games> gamesRepository, int id) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeamId == id || game.GuestTeamId == id) &&
                        DateTime.Compare(game.DateOfGame, DateTime.Now) < 0)
                .ToList();

        /// <summary>
        /// Returns a list of played games by certain team based on name of team
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetPlayedGames(this IRepository<Games> gamesRepository, string name) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeam.Name == name || game.GuestTeam.Name == name ) &&
                        DateTime.Compare(game.DateOfGame, DateTime.Now) < 0)
                .ToList();

        /// <summary>
        /// Returns a list of upcoming games by certain team based on id
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetUpcomingGames(this IRepository<Games> gamesRepository ,int id) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeamId == id || game.GuestTeamId == id)
                        && DateTime.Compare(game.DateOfGame, DateTime.Now) > 0)
                .ToList();

        /// <summary>
        /// Returns a list of upcoming games by certain team based on name
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetUpcomingGames(this IRepository<Games> gamesRepository, string name) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeam.Name == name || game.GuestTeam.Name == name)
                        && DateTime.Compare(game.DateOfGame, DateTime.Now) > 0)
                .ToList();

        /// <summary>
        /// Returns a list of all upcoming games
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetUpcomingGames(this IRepository<Games> gamesRepository) 
            => gamesRepository
                .Find(
                    game => DateTime.Compare(game.DateOfGame, DateTime.Now) > 0)
                .ToList();

        /// <summary>
        /// Returns a list of all games in selected date
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetGamesOnSelectedDate(this IRepository<Games> gamesRepository, DateTime selectedDate) 
            => gamesRepository
                .Find(
                    game => DateTime.Compare(game.DateOfGame, selectedDate) == 0)
                .ToList();

        /// <summary>
        /// Returns a list of games on selected date based on team id
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="selectedDate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetGamesOnSelectedDateOfSelectedTeam(this IRepository<Games> gamesRepository ,DateTime selectedDate, int id) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeamId == id || game.HomeTeamId == id) &&
                        DateTime.Compare(game.DateOfGame, selectedDate) == 0)
                .ToList();

        /// <summary>
        /// Returns a list of games on selected date based on team name
        /// </summary>
        /// <param name="gamesRepository"></param>
        /// <param name="selectedDate"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Games> GetGamesOnSelectedDateOfSelectedTeam(this IRepository<Games> gamesRepository, DateTime selectedDate, string name) 
            => gamesRepository
                .Find(
                    game =>
                        (game.HomeTeam.Name == name || game.HomeTeam.Name == name) &&
                        DateTime.Compare(game.DateOfGame, selectedDate) == 0)
                .ToList();


    }
}