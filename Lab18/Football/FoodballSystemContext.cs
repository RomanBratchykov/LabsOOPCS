using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P03_FootballBetting.Data
{
    internal class FootballSystemContext : DbContext
    {
        public FootballSystemContext()
        {
        }
        public FootballSystemContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<PlayerStatistics> PlayerStatistics { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=.;Database=FootballBettingBD;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(p =>
            {
                p.HasKey(p => p.PlayerId);
                p.Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired();
                p.Property(p => p.SquadNumber)
                .IsRequired();
                p.Property(p => p.IsInjured)
                .IsRequired();
                p.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
                p.HasOne(p => p.Position)
                .WithMany(pos => pos.Players)
                .HasForeignKey(p => p.PositionId);
            });
            modelBuilder.Entity<Game>(g => {
                g.HasKey(g => g.GameId);
                g.Property(g => g.DateTime);
                g.Property(g => g.HomeTeamGoals);
                g.Property(g => g.AwayTeamGoals);
                g.Property(g => g.Result);

                g.HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                g.HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                g.Property(g => g.AwayTeamId);
                g.Property(g => g.HomeTeamId);

            });
            modelBuilder.Entity<Country>(c =>
            {
                c.HasKey(c => c.CountryId);
                c.Property(c => c.Name);
            });
            modelBuilder.Entity<Town>(t => {
                t.HasKey(t => t.TownId);
                t.Property(t => t.Name);
                t.HasOne(t => t.Country)
               .WithMany(u => u.Towns)
               .HasForeignKey(b => b.CountryId);
            });
            modelBuilder.Entity<Position> (p =>
            {
                p.HasKey(p => p.PositionId);
                p.Property(p => p.Name);    
            });
            modelBuilder.Entity<Team> (
                t =>
                {
                    t.HasKey(t => t.TeamId);
                    t.Property(t => t.Budget);
                    t.Property(t => t.InitialsTeam);
                    t.Property(t => t.LogoUrl);
                    t.Property(t => t.Name);

                    t.HasOne(t => t.Town)
                    .WithMany(u => u.Teams)
                    .HasForeignKey(t => t.TownId);

                    t.HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                    t.HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
                }
                );
            modelBuilder.Entity<User> (
                u =>
                {
                    u.HasKey(u => u.UserId);
                    u.Property(u => u.Balance);
                    u.Property(u => u.Email);
                    u.Property(u => u.Name);
                    u.Property(u => u.Password);
                    u.Property(u => u.Username);
                }
                );
            modelBuilder.Entity<Bet> (b =>
            {
                b.HasKey(b => b.BetId);
                b.Property(b => b.Amount);
                b.Property(b => b.Prediction);
                b.Property(b => b.DateTime);
                b.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
                b.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
            });
            
            modelBuilder.Entity<PlayerStatistics>(
                ps =>
                {
                    ps.HasKey(ps => new { ps.GameId, ps.PlayerId });
                    ps.Property(ps => ps.ScoredGoals);
                    ps.Property(ps => ps.Assists);
                    ps.Property(ps => ps.MinutesPlayed);

                    ps.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);
                    ps.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);
                });
            modelBuilder.Entity<Color>
            ( c => 
            {
                c.HasKey(c => c.ColorId);
                c.Property(c => c.Name);
            }
            );

        }
    }
}
