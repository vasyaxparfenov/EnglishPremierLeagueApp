using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnglishPremierLeagueApp
{
    class TransferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IEnumerable<Team> _teams;
        private IEnumerable<Player> _players;
        private Team _selectedTeam;
        private Player _selectedPlayer;
        private Visibility _playersTableVisibility;
        private Visibility _propositionGridVisibility;
        private RelayCommand _showPlayersListView;
        private RelayCommand _showPropositionGrid;
        private string _proposedPrice;
        private IEnumerable<Transfer> _transfers;



        public IEnumerable<Transfer> Transfers
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

        public IEnumerable<Team> Teams
        {
            get
            {
                return _teams;
            }
            set
            {
                _teams = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Player> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                OnPropertyChanged();
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
            Players = App.Db.Players.Where(player => player.TeamId == SelectedTeam.Id).ToList();
            PlayersTableVisibility = Visibility.Visible;
            PropositionGridVisibility = Visibility.Hidden;
        }));

        public RelayCommand ShowPropositionGrid => _showPropositionGrid ?? (_showPropositionGrid = new RelayCommand(
                                                       obj =>
                                                       {
                                                           ProposedPrice = SelectedPlayer?.Fee.ToString("##,###");
                                                           PropositionGridVisibility = Visibility.Visible;
                                                       }));

        public TransferViewModel(BindingList<Transfer> transfers )
        {
            App.Db.Teams.Load();
            App.Db.Players.Load();
            _teams = App.Db.Teams.Local.ToBindingList();
            _transfers = transfers;
            PlayersTableVisibility = Visibility.Hidden;
            PropositionGridVisibility = Visibility.Hidden;
            
        }


        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
