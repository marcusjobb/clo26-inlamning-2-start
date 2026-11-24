namespace Sportstatistik.Models;

/// <summary>
/// Det största antalet spelare ett lag får ha under en säsong.
/// </summary>
public class SquadLimit
{
    public int TeamId { get; set; }
    public int Season { get; set; }
    public int MaxPlayers { get; set; }
}
