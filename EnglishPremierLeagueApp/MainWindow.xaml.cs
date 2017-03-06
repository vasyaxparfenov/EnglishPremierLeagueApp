using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void LogIn(object sender, RoutedEventArgs e)
        {
            using (var db = new FootballLeagueEntities())
            {
                if (!db.Users.Any(user => user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Password))
                {
                    MessageBox.Show("Wrong login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    App.CurrentUser = App.Db.Users.First(user => user.Login == textBoxLogin.Text);
                    var view = new UserView(textBoxLogin.Text);
                    view.Show();
                    Close();
                }

            }        
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();

        }
    }
}
