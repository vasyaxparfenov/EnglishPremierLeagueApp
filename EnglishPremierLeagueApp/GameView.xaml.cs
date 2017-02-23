using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public Game game;
        FootballLeagueEntities Db = new FootballLeagueEntities();
        ObservableCollection<Goal> homeGoals;
        ObservableCollection<Goal> guestGoals;
        BindingList<Goal> goals;

        public GameView(Game currentGame)
        {
            InitializeComponent();
            Db.Goals.Load();
            game = currentGame;
            Home.Content = game.HomeTeam.Name;
            HomeScore.Text = game.HomeTeamScore?.ToString();
            GuestScore.Text = game.GuestTeamScore?.ToString();
            Guest.Content = game.GuestTeam.Name;
            goals = Db.Goals.Local.ToBindingList();
            listBoxOfHomeGoals.ItemsSource =
                homeGoals =
                    new ObservableCollection<Goal>(
                        Db.Goals.Local.Where(goal => goal.GameId == game.Id && goal.Player.TeamId == game.HomeTeamId));
            listBoxOfGuestGoals.ItemsSource =
                guestGoals =
                    new ObservableCollection<Goal>(
                        Db.Goals.Local.Where(goal => goal.GameId == game.Id && goal.Player.TeamId == game.GuestTeamId));
            Db.Players.Where(player => player.TeamId == game.HomeTeamId)
                .ToList()
                .ForEach(player => HomeScorer.Items.Add(new ComboBoxItem() {Content = player.Name}));
            Db.Players.Where(player => player.TeamId == game.GuestTeamId)
                .ToList()
                .ForEach(player => GuestScorer.Items.Add(new ComboBoxItem() {Content = player.Name}));
            Enumerable.Range(1, 90).ToList().ForEach(num => Minute.Items.Add(new ComboBoxItem() {Content = num}));

        }

        private void HomeAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var goal = new Goal()
                {
                    GameId = game.Id,
                    Minute = (int) ((ComboBoxItem) Minute.SelectedItem).Content,
                    PlayerId =
                        Db.Players.First(player => player.Name == ((ComboBoxItem) HomeScorer.SelectedItem).Content).Id
                };
                homeGoals.Add(goal);
                goals.Add(goal);
                Db.SaveChanges();
                HomeScorer.SelectedIndex = -1;
                Minute.SelectedIndex = -1;

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You haven't choosen player or minute", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void GuestAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var goal = new Goal()
                {
                    GameId = game.Id,
                    Minute = (int) ((ComboBoxItem) Minute.SelectedItem).Content,
                    PlayerId =
                        Db.Players.First(player => player.Name == ((ComboBoxItem) GuestScorer.SelectedItem).Content).Id
                };
                guestGoals.Add(goal);
                goals.Add(goal);
                Db.SaveChanges();
                GuestScorer.SelectedIndex = -1;
                Minute.SelectedIndex = -1;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You haven't choosen player or minute", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(homeGoals.Count == int.Parse(HomeScore.Text) && guestGoals.Count == int.Parse(GuestScore.Text)))
                {
                    MessageBox.Show("Number of goals don't complies to number of scorers", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    game.HomeTeamScore = int.Parse(HomeScore.Text);
                    game.GuestTeamScore = int.Parse(GuestScore.Text);
                    ((Owner as UserView)?.CalendarItem.Content as CalendarAdmin)?.games.ResetItem(((Owner as UserView).CalendarItem.Content as CalendarAdmin).games.IndexOf(game));
                    Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Input score", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
