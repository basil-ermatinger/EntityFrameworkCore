using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// Instance of context
using FootballLeagueDbContext context = new FootballLeagueDbContext();

/// Select all teams
// await GetAllTeams();
// await GetAllTeamsQuerySyntax();

/// Select one team
// await GetOneTeam();

/// Select all records that meet a condition
// await GetFilteredTeams();

/* 
 * Aggregate Methods 
 */

/// Count
int numberOfTeams = await context.Teams.CountAsync();
Console.WriteLine($"Number of Teams: {numberOfTeams}");

int numberOfTeamsWithCondition = await context.Teams.CountAsync(t => t.TeamId == 1);
Console.WriteLine($"Number of Teams with condition: {numberOfTeamsWithCondition}");

/// Max
int maxTeams = await context.Teams.MaxAsync(t => t.TeamId);
Console.WriteLine($"Max id of all teams: {maxTeams}");

/// Min
int minTeams = await context.Teams.MinAsync(t => t.TeamId);
Console.WriteLine($"Min id of all teams: {minTeams}");

/// Average
double avgTeams = await context.Teams.AverageAsync(t => t.TeamId);
Console.WriteLine($"Average of all ids of all teams: {avgTeams}");

/// Sum
int sumTeams = await context.Teams.SumAsync(t => t.TeamId);
Console.WriteLine($"Sum of all ids of all teams: {sumTeams}");

async Task GetAllTeams()
{
	// SELECT * FROM TEAMS
	List<Team> teams = await context.Teams.ToListAsync();

	teams.ForEach(t => Console.WriteLine(t.Name));
}

async Task GetAllTeamsQuerySyntax()
{
	Console.WriteLine("Enter Search Term");
	string searchTerm = Console.ReadLine();

	List<Team> teams = await (from team in context.Teams
														where EF.Functions.Like(team.Name, $"%{searchTerm}%")
														select team)
														.ToListAsync();

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