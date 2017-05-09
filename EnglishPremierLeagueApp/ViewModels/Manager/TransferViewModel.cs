using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using EnglishPremierLeagueApp.Commands;
using EnglishPremierLeagueApp.ModelsOLD;

namespace EnglishPremierLeagueApp.ViewModels.Manager
{
    class TransferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BindingList<Player> _players;
        private IEnumerable<Player> _selectedTeamPlayers;
        private Team _selectedTeam;
        private Player _selectedPlayer;
        private Visibility _playersTableVisibility;
        private Visibility _propositionGridVisibility;
        private RelayCommand _showPlayersListView;
        private RelayCommand _showPropositionGrid;
        private RelayCommand _proposeTransfer;
        private string _proposedPrice;
        private BindingList<Transfer> _transfers;

        public IEnumerable<Team> Teams => App.Db.Teams.Where(team => team.Id != App.CurrentUser.TeamId.Value).ToList();

        public IEnumerable<Player> SelectedTeamPlayers
        {
            get
            {
                return _selectedTeam != null ? App.Db.Players.Where(player => player.TeamId == _selectedTeam.Id).ToList() : _selectedTeamPlayers;
            }
            
        }


        public Player SelectedPlayer
        {
            get
            {
                return _selectedPlayer;
            }
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged();
            }
        }

        public Team SelectedTeam
        {
            get
            {
                return _selectedTeam;
            }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged();
            }
        }

        public Visibility PlayersTableVisibility
        {
            get
            {
                return _playersTableVisibility;
            }
            set
            {
                _playersTableVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility PropositionGridVisibility
        {
            get
            {
                return _propositionGridVisibility;
            }
            set
            {
                _propositionGridVisibility = value;
                OnPropertyChanged();
            }
        }

        public string ProposedPrice
        {
            get { return _proposedPrice; }
            set
            {
                _proposedPrice = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ShowPlayersListView => _showPlayersListView ?? (_showPlayersListView = new RelayCommand(obj =>
        {
            OnPropertyChanged(nameof(SelectedTeamPlayers));
            PlayersTableVisibility = Visibility.Visible;
            PropositionGridVisibility = Visibility.Hidden;
        }));

        public RelayCommand ShowPropositionGrid => _showPropositionGrid ?? (_showPropositionGrid = new RelayCommand(obj =>
        {
            ProposedPrice = SelectedPlayer?.Fee.ToString("##,###");
            PropositionGridVisibility = Visibility.Visible;
        }));

        public RelayCommand ProposeTransfer => _proposeTransfer ?? (_proposeTransfer = new RelayCommand(obj =>
        {
            _transfers.Add(new Transfer
            {
                Player = SelectedPlayer,
                Fee = Convert.ToDecimal(_proposedPrice),
                FromId = SelectedTeam.Id,
                ToId = App.CurrentUser.TeamId.Value,
                Status = "Pending"
            });
            App.Db.SaveChanges();
            PropositionGridVisibility = Visibility.Hidden;
            MessageBox.Show("Proposition was successfully sent!");
        }));
        
        public TransferViewModel(BindingList<Transfer> transfers, BindingList<Player> players  )
        {
            _players = players;
            _players.ListChanged += PlayersOnListChanged;
            _transfers = transfers;
            PlayersTableVisibility = Visibility.Hidden;
            PropositionGridVisibility = Visibility.Hidden;
            
        }

        private void PlayersOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            OnPropertyChanged(nameof(SelectedTeamPlayers));
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
