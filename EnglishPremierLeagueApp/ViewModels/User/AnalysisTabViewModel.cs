using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.Commands;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.User
{
    class AnalysisTabViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Team> Teams => App.Db.Teams.ToList();

        private Team _selectedTeam;

        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged();
            }
        }
        
        private IEnumerable<Player> _resultOfPlayersSearch;
        
        public IEnumerable<Player> ResultOfPlayersSearch
        {
            get { return _resultOfPlayersSearch; }
            set
            {
                _resultOfPlayersSearch = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Game> _schedule;

        public IEnumerable<Game> Schedule
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }


        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        private string _playerNameToSearch;

        public string PlayerNameToSearch
        {
            get { return _playerNameToSearch; }
            set
            {
                _playerNameToSearch = value;
                OnPropertyChanged();
            }
        }


        private decimal _minPrice;

        public decimal MinPrice
        {
            get { return _minPrice; }
            set
            {
                _minPrice = value;
                OnPropertyChanged();
            }
        }

        private decimal _maxPrice;

        public decimal MaxPrice
        {
            get { return _maxPrice; }
            set
            {
                _maxPrice = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _search;

        public RelayCommand Search
            =>
                _search ??
                (_search = new RelayCommand(obj =>
                {
                    ResultOfPlayersSearch =
                        ResultOfPlayersSearch.Where(player => player.Name.StartsWith(_playerNameToSearch)).OrderByDescending(player => player.Name).ToList();
                }, condition => !string.IsNullOrEmpty(_playerNameToSearch)));

        private RelayCommand _searchAccordingPriceGap;

        public RelayCommand SearchAccordingPriceGap
            => _searchAccordingPriceGap ?? (_searchAccordingPriceGap = new RelayCommand(obj =>
            {
                ResultOfPlayersSearch =
                    App.Db.Players.Where(player => player.Fee >= _minPrice && player.Fee <= _maxPrice).OrderByDescending(player => player.Fee).ToList();
            }, condotion => _minPrice <= _maxPrice));

        private RelayCommand _refreshTable;
        
        public RelayCommand RefreshTable => _refreshTable ?? (_refreshTable = new RelayCommand(obj =>
        {
            ResultOfPlayersSearch = App.Db.Players.OrderByDescending(player => player.Fee).ToList();
            PlayerNameToSearch = "";
        }));

        private RelayCommand _getScheduleOfSelectedDateAndForSelectedTeam;

        public RelayCommand GetScheduleOfSelectedDateAndForSelectedTeam
            =>
                _getScheduleOfSelectedDateAndForSelectedTeam ??
                (_getScheduleOfSelectedDateAndForSelectedTeam = new RelayCommand(
                    obj =>
                    {
                        Schedule = _selectedTeam == null ? App.Db.Games.Where(game => DateTime.Compare(game.DateOfGame, _selectedDate) == 0)
                                    .ToList() :
                        App.Db.Games.Where(
                            game =>
                                (game.HomeTeamId == _selectedTeam.Id || game.HomeTeamId == _selectedTeam.Id) &&
                                DateTime.Compare(game.DateOfGame, _selectedDate) == 0).ToList();

                    }, condition => DateTime.Compare(App.Db.Games.Min(game => game.DateOfGame), SelectedDate) <= 0));

        private RelayCommand _showFullSchedule;

        public RelayCommand ShowFullSchedule => _showFullSchedule ?? (_showFullSchedule = new RelayCommand(obj =>
        {
            SelectedTeam = null;
            SelectedDate = DateTime.MinValue;
            Schedule = App.Db.Games.ToList();
        }));
        
        
        public AnalysisTabViewModel()
        {
            _resultOfPlayersSearch = App.Db.Players.OrderByDescending(player => player.Fee).ToList();
            _schedule = App.Db.Games.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
