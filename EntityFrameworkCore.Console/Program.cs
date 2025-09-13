using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;

// First we need instance of context
FootballLeagueDbContext context = new FootballLeagueDbContext();

// Select all teams
// SELECT * FROM TEAMS

List<Team> teams = context.Teams.ToList();

teams.ForEach(t => Console.WriteLine(t.Name));