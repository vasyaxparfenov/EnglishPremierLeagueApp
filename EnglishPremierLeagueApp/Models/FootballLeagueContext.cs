using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnglishPremierLeagueApp.Models
{
    public partial class FootballLeagueContext : DbContext
    {
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Injury> Injury { get; set; }
        public virtual DbSet<LeagueTable> LeagueTable { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FootballLeague;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.DateOfGame).HasColumnType("date");

                entity.HasOne(d => d.GuestTeam)
                    .WithMany(p => p.GamesGuestTeam)
                    .HasForeignKey(d => d.GuestTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Games_ToTable_Teams_GuestTeam");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.GamesHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Games_ToTable_Teams_HomeTeam");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Games_ToTable_Seasons");
            });

            modelBuilder.Entity<Goals>(entity =>
            {
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Goals_ToTable_Games");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Goals_ToTable_Players");
            });

            modelBuilder.Entity<Injury>(entity =>
            {
                entity.Property(e => e.DateOfInjured).HasColumnType("date");

                entity.Property(e => e.DateOfRecover).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(30)");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Injury)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Injury_ToTable_Players");
            });

            modelBuilder.Entity<LeagueTable>(entity =>
            {
                entity.HasOne(d => d.Season)
                    .WithMany(p => p.LeagueTable)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LeagueTable_ToTable_Seasons");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.LeagueTable)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LeagueTable_ToTable_Teams");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Players_ToTable_Teams");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Seasons>(entity =>
            {
                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasIndex(e => e.ManagerId)
                    .HasName("UQ__Teams__3BA2AAE0C6F71759")
                    .IsUnique();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Manager)
                    .WithOne(p => p.ManagedTeam)
                    .HasForeignKey<Teams>(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Teams_ToTable_Users");
            });

            modelBuilder.Entity<Transfers>(entity =>
            {
                entity.Property(e => e.Fee)
                    .HasColumnName("Fee")
                    .HasColumnType("money");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasColumnType("int");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.TransfersFrom)
                    .HasForeignKey(d => d.FromId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transfers_ToTable_Teams_To");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transfers_ToTable_Players");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.TransfersTo)
                    .HasForeignKey(d => d.ToId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Transfers_ToTable_Teams_From");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_ToTable_Roles");

                entity.HasOne(d => d.FavoriteTeam)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Users_ToTable_Teams");
            });
        }
    }
}