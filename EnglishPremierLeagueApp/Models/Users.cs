using System;
using System.Collections.Generic;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? TeamId { get; set; }

        public virtual Teams ManagedTeam { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Teams FavoriteTeam { get; set; }
    }
}
