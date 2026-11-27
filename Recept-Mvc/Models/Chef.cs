namespace Recept.Models;

/// <summary>
/// En kock, den som har skapat ett recept
/// Vi har sparat bara id och förnamn och inget i programmet behöver mer information (dataminimering)
/// </summary>
public class Chef
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
}
