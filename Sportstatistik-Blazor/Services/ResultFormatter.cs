namespace Sportstatistik.Services;

/// <summary>
/// Ska byggas av er. Båda metoderna fungerar redan, men fel, så att ni ser vad som ska rättas.
/// </summary>
public class ResultFormatter : IResultFormatter
{
    // Den här skriver "2-1" med bindestreck, i stället för "2–1" med tankstreck.
    // Du behöver bygga ut detta mer, så att den följer önskemål 1.
    
    // Bygger ny med tankstreck istället för bindestreck. -max 
    public string FormatResult(int homeGoals, int awayGoals)
    {
       return $"{homeGoals}–{awayGoals}";  
    } 

    // Den här skriver "3" i stället för "+3".
    // Du behöver bygga ut detta mer, så att den följer önskemål 1.
    
    // Bygger nu enligt önskemål 1. Behöver inte göra en <0 för att den skriver redan ut.
    public string FormatGoalDifference(int goalDifference)
    {
        if (goalDifference > 0)
        { 
            return "+" + goalDifference.ToString();
        }

        return goalDifference.ToString();
    }
}
