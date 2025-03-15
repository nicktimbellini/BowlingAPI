using Microsoft.EntityFrameworkCore;
using BowlingAPI.Models;

namespace BowlingAPI.Data
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany()
                .HasForeignKey(b => b.TeamID);
        }
    }
}
