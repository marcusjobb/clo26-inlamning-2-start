using Sportstatistik.Models;
using MongoDB.Bson;
namespace Sportstatistik.Services;

/// <summary>
/// Kontraktet mellan gränssnittet och datalagret. Sidorna känner bara till det här interfacet,
/// så ni kan byta InMemoryLeagueRepository mot en riktig databas utan att röra sidorna.
/// </summary>
public interface ILeagueRepository
{
List<Team> GetAllTeams();
Team? GetTeam(ObjectId id);
void AddTeam(Team team);

    List<Player> GetPlayers(ObjectId teamId);
    void AddPlayer(Player player);

    List<Match> GetAllMatches();
    Match? GetMatch(ObjectId id);
    void AddMatch(Match match);
    void DeleteMatch(ObjectId id);

    // Du behöver bygga ut detta mer: metoder för positioner och truppgränser när ni sparar dem i databasen.
}
