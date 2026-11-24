namespace Sportstatistik.Services;

/// <summary>
/// Ska byggas av er. Båda metoderna fungerar redan, men fel, så att ni ser vad som ska rättas.
/// </summary>
public class ResultFormatter : IResultFormatter
{
    // Den här skriver "2-1" med bindestreck, i stället för "2–1" med tankstreck.
    // Du behöver bygga ut detta mer, så att den följer önskemål 1.
    public string FormatResult(int homeGoals, int awayGoals) => $"{homeGoals}-{awayGoals}";

    // Den här skriver "3" i stället för "+3".
    // Du behöver bygga ut detta mer, så att den följer önskemål 1.
    public string FormatGoalDifference(int goalDifference) => goalDifference.ToString();
}
