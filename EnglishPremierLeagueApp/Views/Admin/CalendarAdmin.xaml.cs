using System.ComponentModel;
using System.Windows.Controls;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.ViewModels.Admin;

namespace EnglishPremierLeagueApp.Views.Admin
{
    /// <summary>
    /// Interaction logic for CalendarAdmin.xaml
    /// </summary>
    public partial class CalendarAdmin : UserControl
    {
       
        public BindingList<Game> Games;

        public CalendarAdmin(BindingList<Game> games, BindingList<Goal> goals )
        {
            InitializeComponent();
            DataContext = new CalendarAdminViewModel(games, goals);
        }

    }
}
