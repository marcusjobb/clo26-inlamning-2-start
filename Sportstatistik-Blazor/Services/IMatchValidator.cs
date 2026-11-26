using Sportstatistik.Models;

namespace Sportstatistik.Services;

<summary>
//Kontrollerar att en match går att registrera
</summary>
public interface IMatchValidator
{
    ///<summary>returnerar ett meddelande på svenska för varje regel som matchen bryter. 
    // Tom lista betyder att matchen är giltig.</summary>
    List<string> Validate(Match match);
}