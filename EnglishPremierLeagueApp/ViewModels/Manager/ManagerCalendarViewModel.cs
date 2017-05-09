using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.Manager
{
    class ManagerCalendarViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Game> PlayedGames
            =>
                App.Db.Games.Where(
                    game =>
                        (game.HomeTeamId == App.CurrentUser.TeamId || game.GuestTeamId == App.CurrentUser.TeamId) &&
                        DateTime.Compare(game.DateOfGame, DateTime.Now) < 0).ToList();

        public IEnumerable<Game> UpcomingGames => App.Db.Games.Where(game => (game.HomeTeamId == App.CurrentUser.Id || game.GuestTeamId == App.CurrentUser.Id) && DateTime.Compare(game.DateOfGame, DateTime.Now) > 0).ToList();
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
