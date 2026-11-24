using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Låtsasdatabas: allt ligger i listor i minnet och försvinner när programmet stängs.
/// Den finns bara för att sidorna ska gå att köra från dag ett.
/// Ersätt den med en egen klass som implementerar ILeagueRepository mot er databas,
/// och byt sedan en enda rad i Program.cs (registreringen av ILeagueRepository).
/// </summary>
public class InMemoryLeagueRepository : ILeagueRepository
{
    private readonly List<Team> _teams = new();
    private readonly List<Player> _players = new();
    private readonly List<Match> _matches = new();
    private int _nextTeamId = 1;
    private int _nextPlayerId = 1;
    private int _nextMatchId = 1;

    public InMemoryLeagueRepository()
    {
        Seed();
    }

    public List<Team> GetAllTeams() => _teams.ToList();

    public Team? GetTeam(int id) => _teams.FirstOrDefault(t => t.Id == id);

    public void AddTeam(Team team)
    {
        // Du behöver bygga ut detta mer: fundera på om två lag får heta samma sak.
        team.Id = _nextTeamId++;
        _teams.Add(team);
    }

    public List<Player> GetPlayers(int teamId) => _players.Where(p => p.TeamId == teamId).ToList();

    public void AddPlayer(Player player)
    {
        player.Id = _nextPlayerId++;
        _players.Add(player);
    }

    public List<Match> GetAllMatches() => _matches.ToList();

    public Match? GetMatch(int id) => _matches.FirstOrDefault(m => m.Id == id);

    public void AddMatch(Match match)
    {
        // Du behöver bygga ut detta mer: ett lag får inte möta sig självt (story 6).
        // Kasta ArgumentException med ett meddelande på svenska, så visar sidan texten.
        match.Id = _nextMatchId++;
        _matches.Add(match);
    }

    public void DeleteMatch(int id) => _matches.RemoveAll(m => m.Id == id);

    // Exempeldata, så att det finns något att titta på direkt.
    // Er riktiga databas ska seeda sig själv på samma sätt vid första start, om den är tom.
    // Här passar till exempel mönstret Builder: en match med lag, mål och datum blir lättare att läsa om den
    // byggs steg för steg, till exempel .Home(ummis).Away(lagret).Score(2, 1).
    private void Seed()
    {
        AddTeam(new Team { Name = "Ummis IF" });
        AddTeam(new Team { Name = "Bryggeriet BK" });
        AddTeam(new Team { Name = "Kontoret FF" });
        AddTeam(new Team { Name = "Lagret United" });

        AddPlayer(new Player { TeamId = 1, FirstName = "Alex", LastName = "Exempelsson", Position = "Målvakt" });
        AddPlayer(new Player { TeamId = 1, FirstName = "Robin", LastName = "Påhittad", Position = "Back" });
        AddPlayer(new Player { TeamId = 1, FirstName = "Kim", LastName = "Testsson", Position = "Mittfält" });
        AddPlayer(new Player { TeamId = 1, FirstName = "Sam", LastName = "Demosson", Position = "Forward" });
        AddPlayer(new Player { TeamId = 2, FirstName = "Charlie", LastName = "Exempelsson", Position = "Målvakt" });
        AddPlayer(new Player { TeamId = 2, FirstName = "Noa", LastName = "Påhittad", Position = "Forward" });
        AddPlayer(new Player { TeamId = 3, FirstName = "Love", LastName = "Testsson", Position = "Back" });
        AddPlayer(new Player { TeamId = 3, FirstName = "Mika", LastName = "Demosson", Position = "Övrigt" });
        AddPlayer(new Player { TeamId = 4, FirstName = "Ellis", LastName = "Exempelsson", Position = "Mittfält" });
        AddPlayer(new Player { TeamId = 4, FirstName = "Juno", LastName = "Påhittad", Position = "Back" });
        AddPlayer(new Player { TeamId = 4, FirstName = "Tove", LastName = "Testsson", Position = "Forward" });
        AddPlayer(new Player { TeamId = 4, FirstName = "Vide", LastName = "Demosson", Position = "Målvakt" });

        // Samma sex matcher som demotabellen i StandingsService visar.
        AddMatch(new Match { HomeTeamId = 1, AwayTeamId = 2, HomeGoals = 2, AwayGoals = 1 });
        AddMatch(new Match { HomeTeamId = 3, AwayTeamId = 4, HomeGoals = 0, AwayGoals = 0 });
        AddMatch(new Match { HomeTeamId = 2, AwayTeamId = 3, HomeGoals = 3, AwayGoals = 1 });
        AddMatch(new Match { HomeTeamId = 4, AwayTeamId = 1, HomeGoals = 1, AwayGoals = 2 });
        AddMatch(new Match { HomeTeamId = 1, AwayTeamId = 3, HomeGoals = 1, AwayGoals = 1 });
        AddMatch(new Match { HomeTeamId = 4, AwayTeamId = 2, HomeGoals = 2, AwayGoals = 2 });
    }
}
