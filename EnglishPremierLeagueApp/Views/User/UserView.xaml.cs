using System.Windows;
using EnglishPremierLeagueApp.ViewModels.Shared;
using EnglishPremierLeagueApp.Views.Admin;
using EnglishPremierLeagueApp.Views.Manager;
using EnglishPremierLeagueApp.Views.Shared;

namespace EnglishPremierLeagueApp.Views.User
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(string username)
        {
            InitializeComponent();
            Title = username;
            UserTabControl.DataContext = new TabControlViewModel();
            MainItem.Content = new MainTab(((TabControlViewModel)UserTabControl.DataContext).Goals);
            CalendarItem.Content = new CalendarAdmin(((TabControlViewModel)UserTabControl.DataContext).Games, ((TabControlViewModel)UserTabControl.DataContext).Goals); 
            TransferItem.Content = new Transfers(((TabControlViewModel) UserTabControl.DataContext).Transfers, ((TabControlViewModel)UserTabControl.DataContext).Players);
            TransferItem.Header = App.CurrentUser.Team.Name;
        }
        
        
    }
}
