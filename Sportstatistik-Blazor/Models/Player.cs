using MongoDB.Bson;

namespace Sportstatistik.Models;

/// <summary>
/// En spelare, som hör till ett lag.
/// Fälten kommer från beställarens gamla Excel-ark. Utvärdera vart och ett i README:ns
/// avsnitt "Fält och data", och ta bort de fält som programmet inte behöver.
/// </summary>
public class Player
{
    public ObjectId Id { get; set; }
    public ObjectId TeamId { get; set; }
    public string Position { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateOnly BirthDate { get; set; }
    public int WeightKg { get; set; }
    public int HeightCm { get; set; }

    // Du behöver bygga ut detta mer.
    // Fundera på om ni vill spara positionens namn här, eller ett PositionId.
}
