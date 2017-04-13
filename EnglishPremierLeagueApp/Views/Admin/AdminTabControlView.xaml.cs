using System.Windows;
using EnglishPremierLeagueApp.ViewModels.Admin;
using EnglishPremierLeagueApp.Views.Shared;

namespace EnglishPremierLeagueApp.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminTabControlView.xaml
    /// </summary>
    public partial class AdminTabControlView : Window
    {
        public AdminTabControlView()
        {
            InitializeComponent();
            DataContext = new AdminTabControlViewModel();
            MainItem.Content = new MainTab(((AdminTabControlViewModel)DataContext).Goals);
            CalendarItem.Content = new CalendarAdmin(((AdminTabControlViewModel)DataContext).Games, ((AdminTabControlViewModel)DataContext).Goals);
            NewsItem.Content = new NewsView(((AdminTabControlViewModel)DataContext).Games);
        }
    }
}
