using System.ComponentModel;
using System.Data.Entity;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.ViewModels.Admin
{
    class AdminTabControlViewModel
    {
        public BindingList<Game> Games => App.Db.Games.Local.ToBindingList();

        public BindingList<Goal> Goals => App.Db.Goals.Local.ToBindingList();

        public AdminTabControlViewModel()
        {
            App.Db.Games.Load();
            App.Db.Goals.Load();
        }
    }
}
