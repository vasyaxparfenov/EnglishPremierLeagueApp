using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeagueApp
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
        //    _leagueTables.ListChanged += SaveChanges;
        //    _goals.ListChanged += SaveChanges;
        //    _games.ListChanged += SaveChanges;
        //    _transfers.ListChanged += SaveChanges;
        }

        private void SaveChanges(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            App.Db.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
