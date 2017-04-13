using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EnglishPremierLeagueApp.Models;

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
