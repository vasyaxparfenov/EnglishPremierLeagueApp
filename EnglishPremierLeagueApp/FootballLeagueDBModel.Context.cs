﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnglishPremierLeagueApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FootballLeagueEntities : DbContext
    {
        public FootballLeagueEntities()
            : base("name=FootballLeagueEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Injury> Injuries { get; set; }
        public virtual DbSet<LeagueTable> LeagueTables { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
