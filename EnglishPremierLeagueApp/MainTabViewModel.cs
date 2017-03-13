using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeagueApp
{
    class MainTabViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Season> _seasons;

        public IEnumerable<Season> Seasons
        {
            get
            {
                return _seasons;
            }
            set
            {
                _seasons = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<LeagueTable> _leagueTableTeams;

        public IEnumerable<LeagueTable> LeagueTableTeams
        {
            get
            {
                return _leagueTableTeams;
            }
            set
            {
                _leagueTableTeams = value;
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
                OnPropertyChanged("GoalScorers");
            }
        }
        
        public IEnumerable<Player> GoalScorers
        {
            get
            {
                return App.Db.Players.Where(player => player.Goals.Count > 0 && player.Goals.Where(goal => goal.Game.Season.Name == SelectedSeason.Name).ToList().Count > 0).OrderByDescending(player => player.Goals.Count).ToList();
            }
        }

        private Season _selectedSeason;

        public Season SelectedSeason
        {
            get
            {
                return _selectedSeason;
            }
            set
            {
                _selectedSeason = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _updateTableAccordingToSeasonCommand;

        public RelayCommand UpdateTableAccordingToSeason
        {
            get
            {
                return _updateTableAccordingToSeasonCommand ?? (_updateTableAccordingToSeasonCommand = new RelayCommand(
                           obj =>
                           {
                               LeagueTableTeams =
                                   App.Db.LeagueTables.Where(table => table.Season.Name == SelectedSeason.Name).OrderByDescending(table => table.Points).ToList();
                               OnPropertyChanged(nameof(GoalScorers));
                           }));
                
            }
            
        }

        public MainTabViewModel(BindingList<Goal> goals)
        {
            _goals = goals;
            _goals.ListChanged += OnListChanged; 
            _seasons = App.Db.Seasons.ToList();
            _selectedSeason = _seasons.ElementAt(App.Db.Seasons.ToList().Count - 1);
            _leagueTableTeams =
                               App.Db.LeagueTables.Where(table => table.Season.Name == SelectedSeason.Name).OrderByDescending(table => table.Points).ToList();

        }

        private void OnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            OnPropertyChanged(nameof(GoalScorers));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
