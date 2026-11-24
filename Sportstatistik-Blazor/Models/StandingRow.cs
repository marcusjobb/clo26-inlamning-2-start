namespace Sportstatistik.Models;

/// <summary>
/// En rad i seriens tabell för en säsong.
/// Vinst ger 3 poäng, oavgjort 1 och förlust 0.
/// </summary>
public class StandingRow
{
    public int TeamId { get; set; }
    public string TeamName { get; set; } = "";
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }
    public int Points { get; set; }
}
