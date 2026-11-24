using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Kontraktet mellan gränssnittet och datalagret. Sidorna känner bara till det här interfacet,
/// så ni kan byta InMemoryLeagueRepository mot en riktig databas utan att röra sidorna.
/// </summary>
public interface ILeagueRepository
{
    List<Team> GetAllTeams();
    Team? GetTeam(int id);
    void AddTeam(Team team);

    List<Player> GetPlayers(int teamId);
    void AddPlayer(Player player);

    List<Match> GetAllMatches();
    Match? GetMatch(int id);
    void AddMatch(Match match);
    void DeleteMatch(int id);

    // Du behöver bygga ut detta mer: metoder för positioner och truppgränser när ni sparar dem i databasen.
}
