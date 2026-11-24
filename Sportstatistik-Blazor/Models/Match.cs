using MongoDB.Bson;

namespace Sportstatistik.Models;

/// <summary>
/// En spelad match. Minimal modell: bara det som README:n kräver.
/// </summary>
public class Match
{
    public ObjectId Id { get; set; }
    public ObjectId HomeTeamId { get; set; }
    public ObjectId AwayTeamId { get; set; }
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }

    // Du behöver bygga ut detta mer.
    // Fundera på om ni vill spara lagens namn här, eller slå upp dem via HomeTeamId och AwayTeamId.
    // När ni lägger till fälten: uppdatera även formuläret i Components/Pages/Matches/MatchCreate.razor så att användaren kan fylla i dem.
}
