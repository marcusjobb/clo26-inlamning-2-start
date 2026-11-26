using Microsoft.Extensions.Primitives;
using Sportstatistik.Models;

namespace Sportstatistik.Services;

public class StandingsService(ILeagueRepository repository) : IStandingsService
{
    public List<StandingRow> GetStandings(int season)
    {
        // Hämtar lagen och matcherna
        var teams = repository.GetAllTeams();
        var matches = repository.GetAllMatches();
        var standings = new List<StandingRow>();
        
        // Skapar en tom tabellrad för varje lag. Statistik börjar på noll.
        foreach (var team in teams)
        {
            var row = new StandingRow
            {
                TeamId = team.Id,
                TeamName = team.Name,
            };
            
            standings.Add(row);
        }

        foreach (var match in matches)
        {
            // Matcher från andra säsonger ska inte påverka tabellen.
            if (season != match.Date.Year)
            {
                continue;
            }

            // Hittar tabellraden som hör till matchens hemmalag.
            StandingRow? homeRow = null;
            foreach (var row in standings)
            {
                if (row.TeamId == match.HomeTeamId)
                {
                    homeRow = row;
                    break;
                }
            }
            // En mer kompakt version. Behåller som exempel.
            var awayRow = standings.FirstOrDefault(row => row.TeamId == match.AwayTeamId);

            
            // Hoppar över matchen om något av lagen saknar en tabellrad.
            if (homeRow is null || awayRow is null)
            {
                continue;
            }
            
            // Räknar spelade matcher och gjorda respektive insläppta mål för båda lagen.
            homeRow.Played++;
            awayRow.Played++;

            homeRow.GoalsFor += match.HomeGoals;
            homeRow.GoalsAgainst += match.AwayGoals;

            awayRow.GoalsFor += match.AwayGoals;
            awayRow.GoalsAgainst += match.HomeGoals;

            // Tilldelar vinst/förlust och poäng utifrån matchresultatet.
            if (match.HomeGoals > match.AwayGoals)
            {
                homeRow.Won++;
                homeRow.Points += 3;
                awayRow.Lost++;
            }

            else if (match.AwayGoals > match.HomeGoals)
            {
                awayRow.Won++;
                awayRow.Points += 3;
                homeRow.Lost++;
            }
            
            // Vid oavgjort får båda lagen en oavgjord match och en poäng.
            else
            {
                awayRow.Drawn++;
                homeRow.Drawn++;
                awayRow.Points++;
                homeRow.Points++;
            }
        }
        
        // Räknar målskillnaden efter att alla säsongens matcher har behandlats.
        foreach (var row in standings)
        {
            row.GoalDifference = row.GoalsFor - row.GoalsAgainst;
        }
        
        // Jämför varje tabellrad med raderna efter den för att sortera tabellen.
        for (int currentIndex = 0; currentIndex < standings.Count - 1; currentIndex++)
        {
            for (int comparisonIndex = currentIndex + 1; comparisonIndex < standings.Count; comparisonIndex++)
            {
                StandingRow firstRow = standings[currentIndex];
                StandingRow secondRow = standings[comparisonIndex];

                // Sorteringsordning: poäng, målskillnad, gjorda mål och lagnamn.
                if (secondRow.Points > firstRow.Points)
                {
                    // Mer kompakt version. Behåller detta som exempel och låter resterande vara.
                    (standings[currentIndex], standings[comparisonIndex]) = (standings[comparisonIndex], standings[currentIndex]);
                }
                else if (secondRow.GoalDifference > firstRow.GoalDifference && secondRow.Points == firstRow.Points)
                {
                    StandingRow temp = standings[currentIndex];
                    standings[currentIndex] = standings[comparisonIndex];
                    standings[comparisonIndex] = temp;
                }
                else if (secondRow.Points == firstRow.Points && secondRow.GoalDifference == firstRow.GoalDifference && secondRow.GoalsFor > firstRow.GoalsFor)
                {
                    StandingRow temp = standings[currentIndex];
                    standings[currentIndex] = standings[comparisonIndex];
                    standings[comparisonIndex] = temp;
                }
                else if (secondRow.Points == firstRow.Points && secondRow.GoalDifference == firstRow.GoalDifference && secondRow.GoalsFor == firstRow.GoalsFor && String.Compare(secondRow.TeamName, firstRow.TeamName, StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    StandingRow temp = standings[currentIndex];
                    standings[currentIndex] = standings[comparisonIndex];
                    standings[comparisonIndex] = temp;
                }
            }
        }

        // Returnerar tabellraderna i sorterad ordning.
        return standings;
    }
}