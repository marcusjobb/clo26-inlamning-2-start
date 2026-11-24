using System.Globalization;

namespace Sportstatistik.Components;

/// <summary>
/// Tolkar text från formulären. Formulären binder till text, så att felaktig inmatning
/// kan visas som ett meddelande i stället för att tyst bli 0.
/// </summary>
public static class InputParser
{
    private static readonly CultureInfo Swedish = CultureInfo.GetCultureInfo("sv-SE");

    /// <summary>Godkänner både "2,5" och "2.5".</summary>
    public static bool TryParseDecimal(string? text, out decimal value) =>
        decimal.TryParse((text ?? "").Trim().Replace('.', ','), NumberStyles.Number, Swedish, out value);

    public static bool TryParseInt(string? text, int min, int max, out int value) =>
        int.TryParse((text ?? "").Trim(), out value) && value >= min && value <= max;
}
