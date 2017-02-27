using System;
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
       
        public BindingList<Game> Games;

        public CalendarAdmin()
        {
            InitializeComponent();
            App.Db.Teams.ToList().ForEach(team => comboBoxHomeTeam.Items.Add(new ComboBoxItem() { Content = team.Name}));
            App.Db.Teams.ToList().ForEach(team => comboBoxAwayTeam.Items.Add(new ComboBoxItem() { Content = team.Name}));
            App.Db.Games.Load();
            Games = App.Db.Games.Local.ToBindingList();
            Games.ListChanged += (sender, args) =>
            {
                App.Db.SaveChanges();
            };
            listView.ItemsSource = Games;
            listView.SelectionChanged += (sender, args) =>
            {
                deleteButton.Visibility = Visibility.Visible;
            };
            listView.MouseDoubleClick += (sender, args) =>
            {
                var gameInfo = new GameView((Game) listView.SelectedItem) {Owner = Window.GetWindow(this) };
                gameInfo.ShowDialog();
            };
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Calendar.SelectedDate != null)
                Games.Add(new Game() {DateOfGame = Calendar.SelectedDate.Value.Date, GuestTeamId = App.Db.Teams.First(team => team.Name == ((ComboBoxItem)comboBoxAwayTeam.SelectedItem).Content).Id, HomeTeamId = App.Db.Teams.First(team => team.Name == ((ComboBoxItem)comboBoxHomeTeam.SelectedItem).Content).Id, SeasonId = App.Db.Seasons.First(season => DateTime.Compare(season.BeginDate, Calendar.SelectedDate.Value) < 0 && DateTime.Compare(season.EndDate, Calendar.SelectedDate.Value) > 0).Id});
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Games.Remove(listView.SelectedItem as Game);
        }
    }
}
