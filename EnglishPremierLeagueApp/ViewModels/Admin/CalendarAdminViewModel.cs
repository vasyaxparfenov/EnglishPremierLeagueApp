using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using EnglishPremierLeagueApp.Commands;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.ViewModels.Admin
{
    class CalendarAdminViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Game> _schedule;

        public IEnumerable<Game> Schedule
        {
            get
            {
                return _schedule;
            }
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedCalendarDateTime;

        public DateTime SelectedCalendarDateTime
        {
            get
            {
                return _selectedCalendarDateTime;
            }
            set
            {
                _selectedCalendarDateTime = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Team> _homeTeamToChooseList;

        public IEnumerable<Team> HomeTeamToChooseList
        {
            get
            {
                return _homeTeamToChooseList;
            }
            set
            {
                _homeTeamToChooseList = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Team> _guestTeamToChooseList;

        public IEnumerable<Team> GuestTeamToChooseList
        {
            get
            {
                return _guestTeamToChooseList;
            }
            set
            {
                _guestTeamToChooseList = value;
                OnPropertyChanged();
            }
        }

        private Visibility _deleteButtonVisibility;

        public Visibility DeleteButtonVisibility
        {
            get
            {
                return _deleteButtonVisibility;
            }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        private Game _selectedGame;

        public Game SelectedGame
        {
            get
            {
                return _selectedGame;
            }
            set
            {
                _selectedGame = value;
                OnPropertyChanged();
            }
        }

        private Team _selectedHomeTeam;

        public Team SelectedHomeTeam
        {
            get
            {
                return _selectedHomeTeam;
            }
            set
            {
                _selectedHomeTeam = value;
                OnPropertyChanged();
            }
        }

        private Team _selectedGuestTeam;

        public Team SelectedGuestTeam
        {
            get
            {
                return _selectedGuestTeam;
            }
            set
            {
                _selectedGuestTeam = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Goal> _goals;

        private RelayCommand _homeTeamChoosing;

        public RelayCommand HomeTeamChoosing => _homeTeamChoosing ?? (_homeTeamChoosing = new RelayCommand(obj =>
                                                              {
                                                                  GuestTeamToChooseList = App.Db.Teams.Where(team => team.Id != _selectedHomeTeam.Id).ToList();
                                                              }));

        private RelayCommand _guestTeamChoosing;

        public RelayCommand GuestTeamChoosing => _guestTeamChoosing ?? (_guestTeamChoosing = new RelayCommand(obj =>
                                                               {
                                                                   HomeTeamToChooseList = App.Db.Teams.Where(team => team.Id != _selectedGuestTeam.Id).ToList();
                                                               }));

        private RelayCommand _addGameResultsCommand;

        public RelayCommand AddGameResultsCommand
            =>
                _addGameResultsCommand ??
                (_addGameResultsCommand = new RelayCommand(obj =>
                {
                    new Views.Admin.GameView(_goals, _selectedGame).ShowDialog();

                }, obj => SelectedGame != null));

        private RelayCommand _addGameCommand;

        public RelayCommand AddGameCommand => _addGameCommand ?? (_addGameCommand = new RelayCommand(obj =>
        {
           (_schedule as BindingList<Game>)?.Add(new Game
           {
               DateOfGame = SelectedCalendarDateTime,
               GuestTeamId = SelectedGuestTeam.Id,
               HomeTeamId = SelectedHomeTeam.Id,
               SeasonId = App.Db.Seasons.First(season => DateTime.Compare(season.BeginDate, SelectedCalendarDateTime) < 0 && DateTime.Compare(season.EndDate, SelectedCalendarDateTime) > 0).Id,
            });
            App.Db.SaveChanges();
        }, obj => SelectedHomeTeam != null && SelectedGuestTeam != null && SelectedCalendarDateTime != DateTime.MinValue));

        public CalendarAdminViewModel(BindingList<Game> games, BindingList<Goal> goals  )
        {
            _schedule = games;
            _goals = goals;
            _homeTeamToChooseList = _guestTeamToChooseList = App.Db.Teams.ToList();
            _deleteButtonVisibility = Visibility.Hidden;
         }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
