using System.Windows;
using EnglishPremierLeagueApp.ModelsOLD;

namespace EnglishPremierLeagueApp.Views.Shared
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
                db.Users.Add(new ModelsOLD.User() {Login = textBoxLogin.Text, Password = textBoxPassword.Password, RoleId = 3});
                db.SaveChanges();
            }

            Close();
        }
    }
}
