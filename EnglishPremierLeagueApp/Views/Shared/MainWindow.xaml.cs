using System.Linq;
using System.Windows;

namespace EnglishPremierLeagueApp.Views.Shared
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
            if (!App.Db.Users.Any(user => user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Password))
            {
                MessageBox.Show("Wrong login or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                App.CurrentUser = App.Db.Users.First(user => user.Login.Equals(textBoxLogin.Text));
                var role = App.CurrentUser.Role.Id;
                switch (role)
                {
                    case 1:
                        new Admin.AdminTabControlView().Show();
                        break;
                    case 3:
                        new User.UserTabControlView().Show();
                        break;
                    case 2:
                        new Manager.ManagerTabView().Show();
                        break;
                }
                Close();
            }
         
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();

        }
    }
}
