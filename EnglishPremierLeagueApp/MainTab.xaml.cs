using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using EnglishPremierLeagueApp.View_Models;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainTab : UserControl
        
    {
        public FootballLeagueEntities Db = new FootballLeagueEntities();
        public MainTab()
        {
            InitializeComponent();
            Db.Seasons.ToList().ForEach(season => SeasonsComboBox.Items.Add(new ComboBoxItem() {Content = season.Name}));
            SeasonsComboBox.SelectedItem = SeasonsComboBox.Items[SeasonsComboBox.Items.Count - 1];
            InitializeTable();
            SeasonsComboBox.SelectionChanged += (sender, args) =>
            {
                InitializeTable();
            };

        }

        public void InitializeTable()
        {
            Table.ItemsSource =
                    Db.LeagueTables.Where(
                            table =>
                                table.Season.Name ==
                                ((ComboBoxItem)SeasonsComboBox.SelectedItem).Content)
                        .Select(
                            table =>
                                new TableViewModel()
                                {
                                    NameOfTeam = table.Team.Name,
                                    Points = table.Points
                                })
                        .OrderByDescending(table => table.Points)
                        .ToList();
        }

       
    }

       
}

