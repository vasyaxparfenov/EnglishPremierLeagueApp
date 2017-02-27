using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using EnglishPremierLeagueApp.View_Models;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainTab : UserControl
        
    {
        
        public MainTab()
        {
            InitializeComponent();
            App.Db.Seasons.ToList().ForEach(season => SeasonsComboBox.Items.Add(new ComboBoxItem() {Content = season.Name}));
            SeasonsComboBox.SelectedItem = SeasonsComboBox.Items[SeasonsComboBox.Items.Count - 1];
            InitializeTables();
            SeasonsComboBox.SelectionChanged += (sender, args) =>
            {
                InitializeTables();
            };
            

            

        }

        public void InitializeTables()
        {
            Table.ItemsSource =
                    App.Db.LeagueTables.Where(
                            table =>
                                table.Season.Name ==
                                ((ComboBoxItem)SeasonsComboBox.SelectedItem).Content)
                        .OrderByDescending(table => table.Points)
                        .ToList();
            Scoreboard.ItemsSource =
                App.Db.Players.Where(
                        player =>
                            player.Goals.Count > 0 &&
                            player.Goals.Where(
                                    goal => goal.Game.Season.Name == ((ComboBoxItem) SeasonsComboBox.SelectedItem).Content)
                                .ToList()
                                .Count > 0)
                    .OrderByDescending(player => player.Goals.Count)
                    .ToList();
            

        }

        
    }

       
}

