using Sportstatistik.Models;

namespace Sportstatistik.Services;

/// <summary>
/// Spelarpositioner: standardlistan och användarens egna (funktion 3).
/// </summary>
public interface IPositionService
{
    List<Position> GetAll();
    void Add(string name);

    /// <summary>Tar bort en egen position. Spelare med positionen flyttas till "Övrigt" (önskemål 3).</summary>
    void Delete(int positionId);
}
