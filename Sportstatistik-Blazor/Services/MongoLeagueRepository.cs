using MongoDB.Bson;
using MongoDB.Driver;
using Sportstatistik.Data;
using Sportstatistik.Models;

namespace Sportstatistik.Services;

public class MongoLeagueRepository(SportDatabase database) : ILeagueRepository
{
    public List<Team> GetAllTeams() =>
        database.Teams.Find(Builders<Team>.Filter.Empty).ToList();

    public Team? GetTeam(ObjectId id) =>
        database.Teams.Find(team => team.Id == id).FirstOrDefault();

    public void AddTeam(Team team) =>
        database.Teams.InsertOne(team);

    public List<Player> GetPlayers(ObjectId teamId) =>
        database.Players.Find(player => player.TeamId == teamId).ToList();

    public void AddPlayer(Player player) =>
        database.Players.InsertOne(player);

    public List<Match> GetAllMatches() =>
        database.Matches.Find(Builders<Match>.Filter.Empty).ToList();

    public Match? GetMatch(ObjectId id) =>
        database.Matches.Find(match => match.Id == id).FirstOrDefault();

    public void AddMatch(Match match) =>
        database.Matches.InsertOne(match);

    public void DeleteMatch(ObjectId id) =>
        database.Matches.DeleteOne(match => match.Id == id);
}