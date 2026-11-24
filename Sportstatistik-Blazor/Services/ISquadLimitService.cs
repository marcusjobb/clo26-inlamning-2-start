using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Truppgräns per lag och säsong (funktion 5), och varningar när ett lag närmar sig den (funktion 6).
/// </summary>
public interface ISquadLimitService
{
    List<SquadLimit> GetLimits(int season);

    /// <summary>Sätter största antalet spelare för ett lag under en säsong.</summary>
    void SetLimit(int teamId, int season, int maxPlayers);

    /// <summary>
    /// Anropas efter att en spelare lagts till. Returnerar de varningar användaren ska se,
    /// till exempel "Ummis IF är på 80 % av truppgränsen". Tom lista betyder inga varningar.
    /// </summary>
    List<string> CheckSquadLimit(int teamId, int season);
}
