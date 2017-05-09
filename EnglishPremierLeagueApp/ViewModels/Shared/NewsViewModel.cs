using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.Shared
{
    class NewsViewModel : INotifyPropertyChanged 
    {
        private readonly BindingList<Transfer> _transfers;
        private readonly BindingList<Game> _games;

        private IEnumerable<Transfer> _pendingTransfers;

        public IEnumerable<Transfer> PendingTransfers
        {
            get
            {
                return _pendingTransfers;
            }
            set
            {
                _pendingTransfers = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Transfer> _doneTransfers;

        public IEnumerable<Transfer> DoneTransfers
        {
            get
            {
                return _doneTransfers;
            }
            set
            {
                _doneTransfers = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Game> _gameResults;

        public IEnumerable<Game> GameResults
        {
            get
            {
                return _gameResults;
            }
            set
            {
                _gameResults = value;
                OnPropertyChanged();
            }
        }

        public NewsViewModel()
        {
            _gameResults = App.Db.Games.Where(game => DateTime.Compare(game.DateOfGame, DateTime.Now) <= 0 && game.GuestTeamScore.HasValue && game.HomeTeamScore.HasValue).ToList();
            _pendingTransfers = App.Db.Transfers.Where(transfer => transfer.Status.StartsWith("Pending")).ToList();
            _doneTransfers = App.Db.Transfers.Where(transfer => transfer.Status.StartsWith("Accepted")).ToList();
        }

        public NewsViewModel(BindingList<Game> games ) : this()
        {
            _games = games;
            _games.ListChanged += GamesOnListChanged;
        }

        public NewsViewModel(BindingList<Transfer> transfers) : this()
        {
            _transfers = transfers;
            _transfers.ListChanged += TransfersOnListChanged;
        }

        private void TransfersOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            DoneTransfers = _transfers.Where(transfer => transfer.Status.StartsWith("Accepted")).ToList();
            PendingTransfers = _transfers.Where(transfer => transfer.Status.StartsWith("Pending")).ToList();
        }

        private void GamesOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            GameResults = _games.Where(game => DateTime.Compare(game.DateOfGame, DateTime.Now) <= 0 && game.GuestTeamScore.HasValue && game.HomeTeamScore.HasValue).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
