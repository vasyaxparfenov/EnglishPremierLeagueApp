using System.Windows;
using EnglishPremierLeagueApp.Views.Shared;
namespace EnglishPremierLeagueApp.Views.User
{
    /// <summary>
    /// Interaction logic for UserTabControlView.xaml
    /// </summary>
    public partial class UserTabControlView : Window
    {
        public UserTabControlView()
        {
            InitializeComponent();
            MainItem.Content = new MainTab();
            TeamItem.Content = new UserTeamTab();
            NewsItem.Content = new NewsView();
            AnalysisItem.Content = new AnalysisTabView();
            
        }
    }
}
