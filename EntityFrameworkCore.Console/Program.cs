using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

// First we need instance of context
using FootballLeagueDbContext context = new FootballLeagueDbContext();

// Select all teams
GetAllTeams();

// Selecting a single record - First one in the list
Team? teamOne = await context.Teams.FirstOrDefaultAsync();

// Selecting a single record - First one in the list that meets a condition
Team? teamTwo = await context.Teams.FirstOrDefaultAsync(t => t.TeamId == 1);

// Selecting a single record - Only one record should be returned
Team? teamThree = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == 2);

// Selecting based on Id
Team? teamBasedOnId = await context.Teams.FindAsync(3);

if(teamBasedOnId != null)
{
	Console.WriteLine(teamBasedOnId.Name);
}

void GetAllTeams()
{
	// SELECT * FROM TEAMS
	List<Team> teams = context.Teams.ToList();

	teams.ForEach(t => Console.WriteLine(t.Name));
}