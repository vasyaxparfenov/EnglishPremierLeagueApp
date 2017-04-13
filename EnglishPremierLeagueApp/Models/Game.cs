//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using EnglishPremierLeagueApp.Properties;

namespace EnglishPremierLeagueApp.Models
{
    using System;
    using System.Collections.Generic;
    

    public partial class Game :INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Goals = new HashSet<Goal>();
        }

        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }

        private int? _homeTeamScore;

        public Nullable<int> HomeTeamScore
        {
            get
            {
                return _homeTeamScore;
            }
            set
            {
                _homeTeamScore = value;
                OnPropertyChanged();
            }
        }

        private int? _guestTeamScore;

        public Nullable<int> GuestTeamScore
        {
            get
            {
                return _guestTeamScore;
            }
            set
            {
                _guestTeamScore = value;
                OnPropertyChanged();
            }
        }

        public System.DateTime DateOfGame { get; set; }
        public int SeasonId { get; set; }

        public virtual Team GuestTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual Season Season { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}