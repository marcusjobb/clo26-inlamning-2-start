using MongoDB.Bson;
using Sportstatistik.Models;

namespace Sportstatistik.Services;

public class SquadLimitService(ILeagueRepository repository) : ISquadLimitService
{
    // Demogränser tills de hämtas från databasen.
    private static readonly Dictionary<string, int> DemoLimits = new()
    {
        ["Ummis IF"] = 20,
        ["Bryggeriet BK"] = 18,
        ["Kontoret FF"] = 18,
        ["Lagret United"] = 5
    };

    public List<SquadLimit> GetLimits(int season)
    {
        var limits = new List<SquadLimit>();

        foreach (var team in repository.GetAllTeams())
        {
            if (DemoLimits.TryGetValue(team.Name, out var maxPlayers))
            {
                limits.Add(new SquadLimit
                {
                    TeamId = team.Id,
                    Season = season,
                    MaxPlayers = maxPlayers
                });
            }
        }

        return limits;
    }

    public void SetLimit(ObjectId teamId, int season, int maxPlayers) =>
        throw new NotImplementedException();

    public List<string> CheckSquadLimit(ObjectId teamId, int season) =>
        throw new NotImplementedException();
}