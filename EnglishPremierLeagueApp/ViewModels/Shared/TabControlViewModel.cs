using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.ModelsOLD;

namespace EnglishPremierLeagueApp.ViewModels.Shared
{
    class TabControlViewModel : INotifyPropertyChanged
    {
        private BindingList<Game> _games;

        public BindingList<Game> Games
        {
            get
            {
                return _games;
            }
            set
            {
                _games = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Goal> _goals;

        public BindingList<Goal> Goals
        {
            get
            {
                return _goals;
            }
            set
            {
                _goals = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Transfer> _transfers;

        public BindingList<Transfer> Transfers
        {
            get
            {
                return _transfers;
            }
            set
            {
                _transfers = value;
                OnPropertyChanged();
            }
        }

        private BindingList<LeagueTable> _leagueTables;

        public BindingList<LeagueTable> LeagueTables
        {
            get
            {
                return _leagueTables;
            }
            set
            {
                _leagueTables = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Player> _players;

        public BindingList<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }


        public TabControlViewModel()
        {
            App.Db.Goals.Load();
            _goals = App.Db.Goals.Local.ToBindingList();
            App.Db.Games.Load();
            _games = App.Db.Games.Local.ToBindingList();
            App.Db.Transfers.Load();
            _transfers = App.Db.Transfers.Local.ToBindingList();
            App.Db.LeagueTables.Load();
            _leagueTables = App.Db.LeagueTables.Local.ToBindingList();
            App.Db.Players.Load();
            _players = App.Db.Players.Local.ToBindingList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
