using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnglishPremierLeagueApp
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
            TransferItem.Content = new Transfers(((TabControlViewModel) UserTabControl.DataContext).Transfers);
            TransferItem.Header = App.CurrentUser.Team.Name;
        }
        
        
    }
}
