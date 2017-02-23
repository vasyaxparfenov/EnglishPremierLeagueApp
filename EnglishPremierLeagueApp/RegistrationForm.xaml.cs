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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            using (var db = new FootballLeagueEntities())
            {
                db.Users.Add(new User() {Login = textBoxLogin.Text, Password = textBoxPassword.Password, RoleId = 3});
                db.SaveChanges();
            }

            Close();
        }
    }
}
