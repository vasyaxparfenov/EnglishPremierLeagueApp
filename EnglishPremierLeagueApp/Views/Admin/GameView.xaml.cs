using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.ViewModels.Admin;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace EnglishPremierLeagueApp.Views.Admin
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public GameView(BindingList<Goal> goals, Game game )
        {
            InitializeComponent();
            DataContext = new GameViewModel(game, goals);

            
        }

        private void MinuteTextBoxOnKeyDownFilter(object sender, KeyEventArgs e)
        {
            
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
            }
           
        }

        
    }
}
