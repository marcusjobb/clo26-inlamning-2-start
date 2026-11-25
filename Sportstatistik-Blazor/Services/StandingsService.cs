using Sportstatistik.Models;

namespace Sportstatistik.Services;

public class StandingsService(ILeagueRepository repository) : IStandingsService
{
    public List<StandingRow> GetStandings(int season)
    {
        // Demodata tills tabellen räknas fram från säsongens matcher.
        var demoRows = new List<StandingRow>
        {
            new() { TeamName = "Ummis IF", Played = 3, Won = 2, Drawn = 1, Lost = 0, GoalsFor = 5, GoalsAgainst = 3, GoalDifference = 2, Points = 7 },
            new() { TeamName = "Bryggeriet BK", Played = 3, Won = 1, Drawn = 1, Lost = 1, GoalsFor = 6, GoalsAgainst = 5, GoalDifference = 1, Points = 4 },
            new() { TeamName = "Lagret United", Played = 3, Won = 0, Drawn = 2, Lost = 1, GoalsFor = 3, GoalsAgainst = 4, GoalDifference = -1, Points = 2 },
            new() { TeamName = "Kontoret FF", Played = 3, Won = 0, Drawn = 2, Lost = 1, GoalsFor = 2, GoalsAgainst = 4, GoalDifference = -2, Points = 2 }
        };

        var teams = repository.GetAllTeams();
        var standings = new List<StandingRow>();

        foreach (var row in demoRows)
        {
            var team = teams.FirstOrDefault(team => team.Name == row.TeamName);
            if (team is null)
            {
                continue;
            }

            row.TeamId = team.Id;
            standings.Add(row);
        }

        return standings;
    }
}