using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EnglishPremierLeagueApp.Annotations;

namespace EnglishPremierLeagueApp
{
    class GameViewModel : INotifyPropertyChanged
    {
        private Game _choosenGame;

        public Game ChoosenGame
        {
            get
            {
                return _choosenGame;
            }
            set
            {
                _choosenGame = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Player> _homeTeamRoster;


        public IEnumerable<Player> HomeTeamRoster
        {
            get
            {
                return _homeTeamRoster;
            }
            set
            {
                _homeTeamRoster = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Player> _guestTeamRoster;

        public IEnumerable<Player> GuestTeamRoster
        {
            get
            {
                return _guestTeamRoster;
            }
            set
            {
                _guestTeamRoster = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Goal> _homeTeamGoals;

        public BindingList<Goal> HomeTeamGoals
        {
            get
            {
                return _homeTeamGoals;
            }
            set
            {
                _homeTeamGoals = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Goal> _guestTeamGoals;

        public BindingList<Goal> GuestTeamGoals
        {
            get
            {
                return _guestTeamGoals;
            }
            set
            {
                _guestTeamGoals = value;
                OnPropertyChanged();
            }
        }

        private Player _selectedHomeTeamPlayer;

        public Player SelectedHomeTeamPlayer
        {
            get
            {
                return _selectedHomeTeamPlayer;
            }
            set
            {
                _selectedHomeTeamPlayer = value;
                OnPropertyChanged();
            }
        }

        private Player _selectedGuestTeamPlayer;

        public Player SelectedGuestTeamPlayer
        {
            get
            {
                return _selectedGuestTeamPlayer; 
            }
            set
            {
                _selectedGuestTeamPlayer = value;
                OnPropertyChanged();
            }
        }

        private string _minute;

        public string Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                OnPropertyChanged();
            }
        }

        private int? _homeTeamScore;

        public int? HomeTeamScore
        {
            get
            {
                return _homeTeamScore;
            }
            set
            {
                _homeTeamScore = value;
                OnPropertyChanged();
            }
        }

        private int? _guestTeamScore;

        public int? GuestTeamScore
        {
            get
            {
                return _guestTeamScore;
            }
            set
            {
                _guestTeamScore = value;
                OnPropertyChanged();
            }
        }

        private List<Goal> _scoredGoals = new List<Goal>();

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

        private RelayCommand _addHomeTeamGoalScorer;

        public RelayCommand AddHomeTeamGoalScorer
            =>
                _addHomeTeamGoalScorer ??
                (_addHomeTeamGoalScorer =
                    new RelayCommand(obj =>
                        {
                            var goalScored = new Goal
                            {
                                GameId = ChoosenGame.Id,
                                Minute = Int32.Parse(Minute),
                                Player = SelectedHomeTeamPlayer
                            };
                            HomeTeamGoals.Add(goalScored);
                            _scoredGoals.Add(goalScored);
                            ChoosenGame.HomeTeamScore = HomeTeamGoals.Count;
                            Minute = "";
                            SelectedHomeTeamPlayer = null;
                        },
                        obj => SelectedHomeTeamPlayer != null && Minute != ""));

        private RelayCommand _addGuestTeamGoalScorer;

        public RelayCommand AddGuestTeamGoalScorer
            =>
                _addGuestTeamGoalScorer ??
                (_addGuestTeamGoalScorer =
                    new RelayCommand(obj =>
                    {
                        var goalScored = new Goal
                        {
                            GameId = ChoosenGame.Id,
                            Minute = Int32.Parse(Minute),
                            Player = SelectedGuestTeamPlayer
                        };
                        GuestTeamGoals.Add(goalScored);
                        _scoredGoals.Add(goalScored);
                        Minute = "";
                        ChoosenGame.GuestTeamScore = GuestTeamGoals.Count;
                        SelectedGuestTeamPlayer = null;
                    }, obj => SelectedGuestTeamPlayer != null && Minute != ""));

        private RelayCommand _saveGameResults;

        public RelayCommand SaveGameResults
            =>
                _saveGameResults ??
                (_saveGameResults =
                    new RelayCommand(obj =>
                        {
                            _scoredGoals.ForEach(Goals.Add);
                            App.Db.SaveChanges();
                        }
                        ));


        public GameViewModel(Game game, BindingList<Goal> goals)
        {
            _goals = goals;
            _choosenGame = game;
            _homeTeamScore = game.HomeTeamScore;
            _guestTeamScore = game.GuestTeamScore;
            _homeTeamGoals = new BindingList<Goal>(_goals.Where(goal => goal.GameId == game.Id && goal.Player.TeamId == game.HomeTeamId).ToList());
            _guestTeamGoals = new BindingList<Goal>(_goals.Where(goal => goal.GameId == game.Id && goal.Player.TeamId == game.GuestTeamId).ToList());
            _homeTeamRoster = game.HomeTeam.Players;
            _guestTeamRoster = game.GuestTeam.Players;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
