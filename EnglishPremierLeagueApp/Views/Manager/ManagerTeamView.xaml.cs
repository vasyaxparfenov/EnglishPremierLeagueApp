using System.ComponentModel;
using System.Windows.Controls;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.ViewModels.Manager;

namespace EnglishPremierLeagueApp.Views.Manager
{
    /// <summary>
    /// Interaction logic for ManagerTeamView.xaml
    /// </summary>
    public partial class ManagerTeamView : UserControl
    {
        public ManagerTeamView(BindingList<Player> players, BindingList<Transfer> transfers)
        {
            InitializeComponent();
            DataContext = new ManagerViewModel(players, transfers);
        }
    }
}
