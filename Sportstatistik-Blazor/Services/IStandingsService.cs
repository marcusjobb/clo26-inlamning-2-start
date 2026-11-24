using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Seriens tabell för en säsong. En säsong följer kalenderåret (önskemål 2).
/// </summary>
public interface IStandingsService
{
    /// <summary>
    /// Tabellen för en säsong (funktion 4), sorterad på poäng, sedan målskillnad,
    /// sedan gjorda mål, sedan lagnamn (funktion 7).
    /// </summary>
    List<StandingRow> GetStandings(int season);
}
