using System.Windows;
using EnglishPremierLeagueApp.ModelsOLD;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static FootballLeagueEntities Db = new FootballLeagueEntities();
        public static User CurrentUser;
        protected override void OnExit(ExitEventArgs e)
        {
            Db.Dispose();
            base.OnExit(e);
        }
    }
    
}
