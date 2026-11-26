using Sportstatistik.Models;

namespace Sportstatistik.Services;

///<summary>
///reglerna för en match som ska registreras: båda lagen finns, lagen är olika.
///antalet mål är giltigt och datumet är känt. reglerna finns bara här 
///</summary>
public class MatchValidator(ILeagueRepository repository) : IMatchValidator
{
    public const int MaxGoals = 99;

    private static readonly DateTime EarliestDate = new(2000, 1, 1);
    private static readonly DateTime LatestDate = new(2100, 12, 31);

    public List<string> Validate(Match match)
    {
        var errors = new List<string>();

        ValidateTeams(match, errors);
        ValidateGoals(match, errors);
        ValidateDate(match, errors);

        return errors;
    }

    private void ValidateTeams(Match match, List<string> errors)
    {
        bool homeTeamExists = repository.GetTeam(match.HomeTeamId) is not null;
        bool awayTeamExists = repository.GetTeam(match.AwayTeamId) is not null;

        if (!homeTeamExists)
        {
            errors.Add("Välj ett hemmalag.");
        }
        if (!awayTeamExists)
        {
            errors.Add("Välj ett bortalag.");
        }
        if (homeTeamExists && awayTeamExists && match.HomeTeamId == match.AwayTeamId)
        {
            errors.Add("ett lag kan inte möta sig själv. Välj två olika lag.");
        }
    }

    private static void ValidateGoals(Match match, List<string> errors)
    {
        if (!IsValidGoalCount(match.HomeGoals))
        {
            errors.Add($"Antal mål hemma måste vara ett heltal mellan 0 och {MaxGoals}.");
        }
        if (!IsValidGoalCount(match.AwayGoals))
        {
            errors.Add($"Antal mål borta måste vara ett heltal mellan 0 och {MaxGoals}.");
        }
    }

    private static bool IsValidGoalCount(int goals) => goals is >= 0 and <= MaxGoals;

    private static void ValidateDate(Match match, List<string> errors)
    {
        if (match.Date == default)
        {
            errors.Add("Välj ett datum för matchen.");
        }
        else if (match.Date < EarliestDate || match.Date > LatestDate)
        {
            errors.Add($"Datumet måste vara mellan {EarliestDate:yyyy-MM-dd} och {LatestDate:yyyy-MM-dd}.");
        }
    }
}