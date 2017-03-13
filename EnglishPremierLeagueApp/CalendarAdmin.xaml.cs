using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishPremierLeagueApp
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
