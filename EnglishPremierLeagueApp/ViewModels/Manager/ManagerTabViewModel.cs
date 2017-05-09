using System.ComponentModel;
using System.Data.Entity;
using EnglishPremierLeagueApp.ModelsOLD;

namespace EnglishPremierLeagueApp.ViewModels.Manager
{
    class ManagerTabViewModel
    {
        public BindingList<Transfer> Transfers => App.Db.Transfers.Local.ToBindingList();

        public BindingList<Player> Players => App.Db.Players.Local.ToBindingList();

        public ManagerTabViewModel()
        {
            App.Db.Transfers.Load();
            App.Db.Players.Load();
        }
    }
}
