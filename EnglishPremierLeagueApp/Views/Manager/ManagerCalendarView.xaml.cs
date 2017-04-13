using System.Windows.Controls;
using EnglishPremierLeagueApp.ViewModels.Manager;

namespace EnglishPremierLeagueApp.Views.Manager
{
    /// <summary>
    /// Interaction logic for ManagerCalendarView.xaml
    /// </summary>
    public partial class ManagerCalendarView : UserControl
    {
        public ManagerCalendarView()
        {
            InitializeComponent();
            DataContext = new ManagerCalendarViewModel();
        }
    }
}
