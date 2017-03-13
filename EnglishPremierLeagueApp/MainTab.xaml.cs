using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using EnglishPremierLeagueApp.View_Models;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainTab : UserControl
        
    {
        
        public MainTab(BindingList<Goal> goals )
        {
            InitializeComponent();
            DataContext = new MainTabViewModel(goals);
        }
 
    }

       
}

