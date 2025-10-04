using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

// First we need instance of context
using FootballLeagueDbContext context = new FootballLeagueDbContext();

// Select all teams
//await GetAllTeams();

// Select one team
//await GetOneTeam();

// Select all records that meet a condition
await GetFilteredTeams();

async Task GetAllTeams()
{
	// SELECT * FROM TEAMS
	List<Team> teams = await context.Teams.ToListAsync();

	teams.ForEach(t => Console.WriteLine(t.Name));
}

async Task GetOneTeam()
{
	// Selecting a single record - First one in the list
	Team? teamFirst = await context.Teams.FirstAsync();

	if(teamFirst != null)
	{
		Console.WriteLine(teamFirst.Name);
	}

	Team? teamFirstOrDefault = await context.Teams.FirstAsync();

	if(teamFirstOrDefault != null)
	{
		Console.WriteLine(teamFirstOrDefault.Name);
	}

	// Selecting a single record - First one in the list that meets a condition
	Team? teamFirstWithCondition = await context.Teams.FirstAsync(t => t.TeamId == 1);

	if(teamFirstWithCondition != null)
	{
		Console.WriteLine(teamFirstWithCondition.Name);
	}

	Team? teamFirstOrDefaultWithCondition = await context.Teams.FirstOrDefaultAsync(t => t.TeamId == 1);

	if(teamFirstOrDefaultWithCondition != null)
	{
		Console.WriteLine(teamFirstOrDefaultWithCondition.Name);
	}

	// Selecting a single record - Only one record should be returned
	Team? teamSingle = await context.Teams.SingleAsync(t => t.TeamId == 2);

	if(teamSingle != null)
	{
		Console.WriteLine(teamSingle.Name);
	}

	Team? teamSingleOrDefault = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == 2);

	if(teamSingleOrDefault != null)
	{
		Console.WriteLine(teamSingleOrDefault.Name);
	}

	// Selecting based on Primary Key Id value
	Team? teamBasedOnId = await context.Teams.FindAsync(3);

	if(teamBasedOnId != null)
	{
		Console.WriteLine(teamBasedOnId.Name);
	}
}

async Task GetFilteredTeams()
{
	Console.WriteLine("Enter desired team");
	string searchTerm = Console.ReadLine();

	List<Team> teamsFiltered = await context.Teams.Where(t => t.Name == searchTerm).ToListAsync();

	teamsFiltered.ForEach(t => Console.WriteLine(t.Name));

	List<Team> partialMatches = await context.Teams.Where(t => t.Name.Contains(searchTerm)).ToListAsync();

	partialMatches.ForEach(t => Console.WriteLine(t.Name));
}