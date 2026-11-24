using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Ska byggas av er. GetStandings visar demodata så att tabellen går att titta på.
/// </summary>
public class StandingsService : IStandingsService
{
    // DEMO: samma påhittade tabell för varje säsong. Den visar hur tabellen ska se ut för de sex
    // matcher som InMemoryLeagueRepository seedar, men den räknas inte fram ur dem.
    // Du behöver bygga ut detta mer: räkna fram tabellen ur säsongens matcher. Vinst ger 3 poäng,
    // oavgjort 1 och förlust 0. Bara matcher med datum från 1 januari till och med 31 december räknas.
    // Sortera på poäng, sedan målskillnad, sedan gjorda mål, sedan lagnamn.
    public List<StandingRow> GetStandings(int season) =>
    [
        new StandingRow { TeamId = 1, TeamName = "Ummis IF", Played = 3, Won = 2, Drawn = 1, Lost = 0, GoalsFor = 5, GoalsAgainst = 3, GoalDifference = 2, Points = 7 },
        new StandingRow { TeamId = 2, TeamName = "Bryggeriet BK", Played = 3, Won = 1, Drawn = 1, Lost = 1, GoalsFor = 6, GoalsAgainst = 5, GoalDifference = 1, Points = 4 },
        new StandingRow { TeamId = 4, TeamName = "Lagret United", Played = 3, Won = 0, Drawn = 2, Lost = 1, GoalsFor = 3, GoalsAgainst = 4, GoalDifference = -1, Points = 2 },
        new StandingRow { TeamId = 3, TeamName = "Kontoret FF", Played = 3, Won = 0, Drawn = 2, Lost = 1, GoalsFor = 2, GoalsAgainst = 4, GoalDifference = -2, Points = 2 },
    ];
}
