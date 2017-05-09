using System.ComponentModel;
using System.Windows.Controls;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.ViewModels.Shared;

namespace EnglishPremierLeagueApp.Views.Shared
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainTab : UserControl
        
    {
        public MainTab()
        {
            InitializeComponent();
            DataContext = new MainTabViewModel();
        }
        
        public MainTab(BindingList<Goal> goals )
        {
            InitializeComponent();
            DataContext = new MainTabViewModel(goals);
        }
 
    }

       
}

