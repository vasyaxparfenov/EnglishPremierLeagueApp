﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for CalendarAdmin.xaml
    /// </summary>
    public partial class CalendarAdmin : UserControl
    {
        FootballLeagueEntities Db = new FootballLeagueEntities();
        public BindingList<Game> games;

        public CalendarAdmin()
        {
            InitializeComponent();
            Db.Teams.ToList().ForEach(team => comboBoxHomeTeam.Items.Add(new ComboBoxItem() { Content = team.Name}));
            Db.Teams.ToList().ForEach(team => comboBoxAwayTeam.Items.Add(new ComboBoxItem() { Content = team.Name}));
            Db.Games.Load();
            games = Db.Games.Local.ToBindingList();
            games.ListChanged += (sender, args) =>
            {
                Db.SaveChanges();
            };
            listView.ItemsSource = games;
            listView.MouseDoubleClick += (sender, args) =>
            {
                var gameInfo = new GameView((Game) listView.SelectedItem) {Owner = Window.GetWindow(this) };
                gameInfo.ShowDialog();
                

            };



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Calendar.SelectedDate != null)
                games.Add(new Game() {DateOfGame = Calendar.SelectedDate.Value.Date, GuestTeamId = Db.Teams.First(team => team.Name == ((ComboBoxItem)comboBoxAwayTeam.SelectedItem).Content).Id, HomeTeamId = Db.Teams.First(team => team.Name == ((ComboBoxItem)comboBoxHomeTeam.SelectedItem).Content).Id, SeasonId = Db.Seasons.First(season => DateTime.Compare(season.BeginDate, Calendar.SelectedDate.Value) < 0 && DateTime.Compare(season.EndDate, Calendar.SelectedDate.Value) > 0).Id});
                games.ResetBindings();
        }
        
    }
}
