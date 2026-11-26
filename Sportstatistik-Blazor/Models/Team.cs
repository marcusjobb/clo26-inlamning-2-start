using MongoDB.Bson;

namespace Sportstatistik.Models;

/// <summary>
/// Ett lag i korpserien. Minimal modell: bara det som README:n kräver.
/// </summary>
public class Team
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = "";

    // Du behöver bygga ut detta mer.
    // Ett lag har spelare (se Player.TeamId), och beställningen kräver en truppgräns per lag och säsong.
}
