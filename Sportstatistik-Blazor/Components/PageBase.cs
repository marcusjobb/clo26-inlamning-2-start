using Microsoft.AspNetCore.Components;

namespace Sportstatistik.Components;

/// <summary>
/// Basklass för sidorna. Kör anrop mot tjänsterna och gör om fel till meddelanden,
/// så att en sida aldrig kraschar. NotImplementedException blir "Inte implementerat ännu".
/// </summary>
public abstract class PageBase : ComponentBase
{
    protected bool NotImplemented { get; private set; }
    protected string? SuccessMessage { get; set; }
    protected string? WarningMessage { get; set; }
    protected string? ErrorMessage { get; set; }

    /// <summary>Kör en åtgärd. Returnerar true om den lyckades.</summary>
    protected bool TryRun(Action action)
    {
        ClearMessages();
        try
        {
            action();
            return true;
        }
        catch (NotImplementedException)
        {
            NotImplemented = true;
        }
        catch (ArgumentException ex)
        {
            // Felaktig inmatning som upptäcks i era services: kasta ArgumentException med ett
            // meddelande på svenska, så visas det på sidan i stället för att något kraschar.
            ErrorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Något gick fel: {ex.Message}";
        }
        return false;
    }

    /// <summary>Hämtar data. Returnerar fallback om anropet misslyckades.</summary>
    protected T TryGet<T>(Func<T> query, T fallback)
    {
        T result = fallback;
        TryRun(() => result = query());
        return result;
    }

    protected void ClearMessages()
    {
        NotImplemented = false;
        SuccessMessage = null;
        WarningMessage = null;
        ErrorMessage = null;
    }
}
