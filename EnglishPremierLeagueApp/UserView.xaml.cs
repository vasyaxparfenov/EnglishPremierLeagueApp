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
            MainItem.Content = new MainTab();
            CalendarItem.Content = new CalendarAdmin(); 
            TransferItem.Content = new TeamRostersForManager();
            TransferItem.Header = App.CurrentUser.Team.Name;
        }
    }
}
