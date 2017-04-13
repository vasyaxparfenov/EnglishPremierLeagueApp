using System.Windows.Controls;
using EnglishPremierLeagueApp.ViewModels.User;

namespace EnglishPremierLeagueApp.Views.User
{
    /// <summary>
    /// Interaction logic for UserTeamTab.xaml
    /// </summary>
    public partial class UserTeamTab : UserControl
    {
        public UserTeamTab()
        {
            InitializeComponent();
            DataContext = new UserTeamViewModel();
        }
        
    }
}
