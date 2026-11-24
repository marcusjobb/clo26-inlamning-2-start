using MongoDB.Bson;

namespace Sportstatistik.Models;

/// <summary>
/// En spelarposition, till exempel "Målvakt" eller "Forward".
/// </summary>
public class Position
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = "";
    public bool IsProtected { get; set; }
}

// Du behöver bygga ut detta mer.
    // Beställningen kräver att användaren kan lägga till egna positioner,
