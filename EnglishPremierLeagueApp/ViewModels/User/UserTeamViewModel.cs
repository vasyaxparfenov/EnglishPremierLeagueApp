using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.Commands;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.User
{
    class UserTeamViewModel : INotifyPropertyChanged
    {

        private Team _userTeam;

        public Team UserTeam
        {
            get { return _userTeam; }
            set
            {
                _userTeam = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Team> Teams => App.Db.Teams.Where(team => !team.Name.Equals(_userTeam.Name)).ToList();

        public IEnumerable<Player> Roster => App.Db.Players.Where(player => player.TeamId == _userTeam.Id).ToList();
       
        public IEnumerable<Game> Games => App.Db.Games.Where(game => game.HomeTeamId == _userTeam.Id || game.GuestTeamId == _userTeam.Id).ToList();
        
        public IEnumerable<Transfer> TeamTransferHistory
            =>
                App.Db.Transfers.Where(transfer => (transfer.FromId == _userTeam.Id || transfer.ToId == _userTeam.Id) && (transfer.Status == "Pending" || transfer.Status == "Accepted")).OrderByDescending(transfer => transfer.Status)
                    .ToList();

        private RelayCommand _changeTeam;

        public RelayCommand ChangeTeam
            => _changeTeam ?? (_changeTeam = new RelayCommand(obj =>
            {
                OnPropertyChanged(nameof(Games));
                OnPropertyChanged(nameof(Roster));
                OnPropertyChanged(nameof(TeamTransferHistory));
            }, condition => _userTeam != null));
        private RelayCommand _save;

        public RelayCommand Save => _save ?? (_save = new RelayCommand(obj =>
        {
            App.Db.SaveChanges();
        }, condition => _userTeam != null)); 



        public UserTeamViewModel()
        {
            _userTeam = App.CurrentUser.Team;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
