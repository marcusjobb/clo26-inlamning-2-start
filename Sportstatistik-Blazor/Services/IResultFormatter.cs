namespace Sportstatistik.Services;

/// <summary>
/// Formaterar resultat och målskillnad så att de går att läsa (önskemål 1).
/// </summary>
public interface IResultFormatter
{
    /// <summary>Till exempel "2–1", med tankstreck mellan målen.</summary>
    string FormatResult(int homeGoals, int awayGoals);

    /// <summary>Alltid med tecken: "+3", "-2" och "0".</summary>
    string FormatGoalDifference(int goalDifference);
}
