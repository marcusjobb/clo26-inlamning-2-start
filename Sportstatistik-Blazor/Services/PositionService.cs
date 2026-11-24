using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Ska byggas av er. GetAll visar demodata så att sidan går att titta på.
/// Övriga metoder kastar NotImplementedException, och sidan visar då "Inte implementerat ännu".
/// </summary>
public class PositionService : IPositionService
{
    // DEMO: en fast lista som inte sparas någonstans. Ersätt med positioner från databasen.
    // Standardlistan ska alltid finnas: Målvakt, Back, Mittfält, Forward och Övrigt.
    public List<Position> GetAll() =>
    [
        new Position { Id = 1, Name = "Målvakt" },
        new Position { Id = 2, Name = "Back" },
        new Position { Id = 3, Name = "Mittfält" },
        new Position { Id = 4, Name = "Forward" },
        new Position { Id = 5, Name = "Övrigt" },
    ];

    // Tom position ska ge ett tydligt felmeddelande. Kasta ArgumentException, så visar sidan texten.
    public void Add(string name) => throw new NotImplementedException();

    // "Övrigt" får aldrig tas bort, och spelarna med positionen flyttas till "Övrigt" (önskemål 3).
    public void Delete(int positionId) => throw new NotImplementedException();
}
