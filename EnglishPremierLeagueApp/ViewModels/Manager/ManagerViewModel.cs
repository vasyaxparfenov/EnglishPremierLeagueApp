using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using EnglishPremierLeagueApp.Commands;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.Manager
{
    class ManagerViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Player> Roster => _players.Where(player => player.Team.Id == App.CurrentUser.TeamId);
        
        public IEnumerable<Transfer> TransferPropositions
            => _transfers.Where(transfer => transfer.FromId == App.CurrentUser.TeamId).ToList();

        public IEnumerable<Transfer> OutcomingTransferPropositions
            => _transfers.Where(transfer => transfer.ToId == App.CurrentUser.TeamId).ToList();

        private Visibility _transferDecisionGridVisibility;
        
        public Visibility TransferDecisionGridVisibility
        {
            get { return _transferDecisionGridVisibility; }
            set
            {
                _transferDecisionGridVisibility = value;
                OnPropertyChanged();
            }
        }

        private Transfer _selectedTransferProposition;

        public Transfer SelectedTransferProposition
        {
            get { return _selectedTransferProposition; }
            set
            {
                _selectedTransferProposition = value; 
                OnPropertyChanged();
            }
        }

        private RelayCommand _showTransferDecisionGrid;

        public RelayCommand ShowTransferDecisionGrid
            =>
                _showTransferDecisionGrid ??
                (_showTransferDecisionGrid =
                    new RelayCommand(obj =>
                    {
                        TransferDecisionGridVisibility = _selectedTransferProposition.Status.StartsWith("Pending")
                            ? Visibility.Visible
                            : Visibility.Hidden;
                    }, condition => _selectedTransferProposition.Status.StartsWith("Pending")));
        


        private RelayCommand _acceptTransferProposition;

        public RelayCommand AcceptTransferProposition
            =>
                _acceptTransferProposition ??
                (_acceptTransferProposition =
                    new RelayCommand(obj =>
                    {
                        SelectedTransferProposition.Status = "Accepted";
                        var playerToSell = _players.Single(player => player.Id == _selectedTransferProposition.PlayerId);
                        playerToSell.TeamId = _selectedTransferProposition.ToId;
                        App.Db.Entry(playerToSell).State = EntityState.Modified;
                        App.Db.SaveChanges();
                        TransferDecisionGridVisibility = Visibility.Hidden;
                    }, condition => _selectedTransferProposition != null ));

        private RelayCommand _declineTransferProposition;

        public RelayCommand DeclineTransferProposition
            => _declineTransferProposition ?? (_declineTransferProposition = new RelayCommand(
                   obj =>
                   {
                       SelectedTransferProposition.Status = "Declined";
                       TransferDecisionGridVisibility = Visibility.Hidden;
                       App.Db.SaveChanges();
                   }, condition => _selectedTransferProposition != null));
        


        private BindingList<Player> _players;

        private BindingList<Transfer> _transfers;
        public ManagerViewModel(BindingList<Player> players, BindingList<Transfer> transfers  )
        {
            _players = players;
            _transfers = transfers;
            _players.ListChanged += PlayersOnListChanged;
            _transfers.ListChanged += TransfersOnListChanged;
            _transferDecisionGridVisibility = Visibility.Hidden;
        }

        private void TransfersOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            OnPropertyChanged(nameof(OutcomingTransferPropositions));
            OnPropertyChanged(nameof(TransferPropositions));
        }
        
        private void PlayersOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            OnPropertyChanged(nameof(Roster));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
