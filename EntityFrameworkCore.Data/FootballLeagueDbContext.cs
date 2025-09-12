using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
	public class FootballLeagueDbContext : DbContext
	{
		public DbSet<Team> Teams { get; set; }
		public DbSet<Coach> Coaches { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Don't use EnableSensitiveDataLogging and EnableDetailedErrors in production workloads
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeague_EfCore; Encrypt=False").LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Team>().HasData(
				new Team
				{
					TeamId = 1,
					Name = "FC Basel",
					CreatedDate = new DateTime(2025, 9, 11)
				},
				new Team
				{
					TeamId = 2,
					Name = "Young Boys",
					CreatedDate = new DateTime(2025, 9, 11)
				},
				new Team
				{
					TeamId = 3,
					Name = "GCZ",
					CreatedDate = new DateTime(2025, 9, 11)
				});
		}
	}
}
