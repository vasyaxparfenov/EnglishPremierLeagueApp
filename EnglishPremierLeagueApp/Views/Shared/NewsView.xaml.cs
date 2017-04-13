using System.ComponentModel;
using System.Windows.Controls;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.ViewModels.Shared;

namespace EnglishPremierLeagueApp.Views.Shared
{
    /// <summary>
    /// Interaction logic for NewsView.xaml
    /// </summary>
    public partial class NewsView : UserControl
    {
        public NewsView(BindingList<Game> games )
        {
            InitializeComponent();
            DataContext = new NewsViewModel(games);

        }
        public NewsView(BindingList<Transfer> transfers )
        {
            InitializeComponent();
            DataContext = new NewsViewModel(transfers);
        }
        public NewsView()
        {
            InitializeComponent();
            DataContext = new NewsViewModel();
        }
    }
}
