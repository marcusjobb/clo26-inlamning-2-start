using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Ska byggas av er. GetLimits visar demodata så att sidan går att titta på.
/// Övriga metoder kastar NotImplementedException, och sidan visar då "Inte implementerat ännu".
/// </summary>
public class SquadLimitService : ISquadLimitService
{
    // DEMO: samma påhittade gränser för varje säsong. Ersätt med gränserna från databasen.
    public List<SquadLimit> GetLimits(int season) =>
    [
        new SquadLimit { TeamId = 1, Season = season, MaxPlayers = 20 },
        new SquadLimit { TeamId = 2, Season = season, MaxPlayers = 18 },
        new SquadLimit { TeamId = 3, Season = season, MaxPlayers = 18 },
        new SquadLimit { TeamId = 4, Season = season, MaxPlayers = 5 },
    ];

    // En gräns under 1 ska ge ett tydligt felmeddelande. Kasta ArgumentException, så visar sidan texten.
    public void SetLimit(int teamId, int season, int maxPlayers) => throw new NotImplementedException();

    // Du behöver bygga ut detta mer: returnera en varning när laget når 80 % av gränsen, och en annan
    // vid 100 %. Samma 80 %-varning får inte visas igen förrän säsongen byts (önskemål 4).
    // Här passar till exempel mönstret Observer.
    public List<string> CheckSquadLimit(int teamId, int season) => throw new NotImplementedException();
}
