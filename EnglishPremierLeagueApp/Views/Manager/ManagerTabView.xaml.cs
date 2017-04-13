using System.Windows;
using EnglishPremierLeagueApp.ViewModels.Manager;
using EnglishPremierLeagueApp.Views.Shared;

namespace EnglishPremierLeagueApp.Views.Manager
{
    /// <summary>
    /// Interaction logic for ManagerTabView.xaml
    /// </summary>
    public partial class ManagerTabView : Window
    {
        public ManagerTabView()
        {
            InitializeComponent();
            DataContext = new ManagerTabViewModel();
            MainItem.Content = new MainTab();
            CalendarItem.Content = new ManagerCalendarView();
            TeamItem.Content = new ManagerTeamView(((ManagerTabViewModel)DataContext).Players, ((ManagerTabViewModel)DataContext).Transfers);
            NewsItem.Content = new NewsView(((ManagerTabViewModel)DataContext).Transfers);
            TransferItem.Content = new Transfers(((ManagerTabViewModel)DataContext).Transfers, ((ManagerTabViewModel)DataContext).Players);
        }
    }
}
