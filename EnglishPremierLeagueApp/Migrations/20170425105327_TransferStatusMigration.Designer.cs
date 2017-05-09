using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.Migrations
{
    [DbContext(typeof(FootballLeagueContext))]
    [Migration("20170425105327_TransferStatusMigration")]
    partial class TransferStatusMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfGame")
                        .HasColumnType("date");

                    b.Property<int>("GuestTeamId");

                    b.Property<int?>("GuestTeamScore");

                    b.Property<int>("HomeTeamId");

                    b.Property<int?>("HomeTeamScore");

                    b.Property<int>("SeasonId");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Goals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("Minute");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Injury", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfInjured")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfRecover")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nchar(30)");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Injury");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.LeagueTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Points");

                    b.Property<int>("SeasonId");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("LeagueTable");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<decimal>("Fee")
                        .HasColumnType("money");

                    b.Property<bool>("IsInjured");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Position");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Roles", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Seasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasName("UQ__Teams__3BA2AAE0C6F71759");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Transfers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Fee")
                        .HasColumnName(" Fee ")
                        .HasColumnType("money");

                    b.Property<int>("FromId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Status")
                        .HasColumnName(" Status ")
                        .HasColumnType("nchar(15)");

                    b.Property<int>("ToId");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ToId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Games", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "GuestTeam")
                        .WithMany("GamesGuestTeam")
                        .HasForeignKey("GuestTeamId")
                        .HasConstraintName("FK_Games_ToTable_Teams_GuestTeam");

                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "HomeTeam")
                        .WithMany("GamesHomeTeam")
                        .HasForeignKey("HomeTeamId")
                        .HasConstraintName("FK_Games_ToTable_Teams_HomeTeam");

                    b.HasOne("EnglishPremierLeagueApp.Models.Seasons", "Season")
                        .WithMany("Games")
                        .HasForeignKey("SeasonId")
                        .HasConstraintName("FK_Games_ToTable_Seasons");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Goals", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Games", "Game")
                        .WithMany("Goals")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_Goals_ToTable_Games");

                    b.HasOne("EnglishPremierLeagueApp.Models.Players", "Player")
                        .WithMany("Goals")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_Goals_ToTable_Players");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Injury", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Players", "Player")
                        .WithMany("Injury")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_Injury_ToTable_Players");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.LeagueTable", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Seasons", "Season")
                        .WithMany("LeagueTable")
                        .HasForeignKey("SeasonId")
                        .HasConstraintName("FK_LeagueTable_ToTable_Seasons");

                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "Team")
                        .WithMany("LeagueTable")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_LeagueTable_ToTable_Teams");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Players", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_Players_ToTable_Teams");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Teams", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Users", "Manager")
                        .WithOne("ManagedTeam")
                        .HasForeignKey("EnglishPremierLeagueApp.Models.Teams", "ManagerId")
                        .HasConstraintName("FK_Teams_ToTable_Users");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Transfers", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "From")
                        .WithMany("TransfersFrom")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK_Transfers_ToTable_Teams_To");

                    b.HasOne("EnglishPremierLeagueApp.Models.Players", "Player")
                        .WithMany("Transfers")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_Transfers_ToTable_Players");

                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "To")
                        .WithMany("TransfersTo")
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK_Transfers_ToTable_Teams_From");
                });

            modelBuilder.Entity("EnglishPremierLeagueApp.Models.Users", b =>
                {
                    b.HasOne("EnglishPremierLeagueApp.Models.Roles", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Users_ToTable_Roles");

                    b.HasOne("EnglishPremierLeagueApp.Models.Teams", "FavoriteTeam")
                        .WithMany("Users")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_Users_ToTable_Teams");
                });
        }
    }
}
