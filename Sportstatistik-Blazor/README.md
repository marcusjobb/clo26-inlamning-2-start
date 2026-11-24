# Sportstatistik, blazor

Blazor Web App. **Gränssnittet är färdigt.** Ni bygger det som ligger bakom: databas, repository och logik. Se avsnittet [Så är koden uppbyggd](#så-är-koden-uppbyggd).

## Så kör du

1. Gör en `dotnet user-secrets init` och sätt `DB_CONNECTION` (se nedan).
2. Kör: `dotnet run --project Sportstatistik-Blazor`

Vid första start skapar programmet databasen och seedar den, om den är tom.

## Connectionstring (user-secrets)

Connectionstringen sparas i en secrets-fil på er dator. Den ligger aldrig i koden eller i repot.

```bash
dotnet user-secrets init --project Sportstatistik-Blazor
dotnet user-secrets set "DB_CONNECTION" "<er connectionstring>" --project Sportstatistik-Blazor
```

Kontrollera med `dotnet user-secrets list --project Sportstatistik-Blazor`. Kommandot visar värdet, så dela inte skärmbilden.
Läraren kör er kod mot sin egen Docker-server och sätter connectionstringen själv. Er kod måste därför bygga och seeda hela databasen vid första start.

---


En korpserie registrerar lag, spelare och matcher, ser tabellen för en säsong och får varning när ett lag närmar sig truppgränsen. Beställningen finns i uppgiftsdokumentet `bestallning_sportstatistik.md`.

## Minsta menyval (måste finnas)

```
1. Lista lag
2. Lägg till lag
3. Registrera match (hemmalag, bortalag, mål hemma, mål borta)
4. Visa tabell (poäng, vinster, oavgjorda, förluster, målskillnad)
5. Lägg till spelare i ett lag
0. Avsluta
```

## Minimal modell (måste byggas ut)

- `Lag`: `Id`, `Namn`
- `Match`: `Id`, `Hemmalag`, `Bortalag`, `MalHemma`, `MalBorta`
- `Spelare`: `Id`, `Position`, `Fornamn`, `Efternamn`, `Fodelsedatum`, `HairColor`, `HeightCm`, `Religion` (hör till ett lag)

Lägg till: säsong, positioner, truppgräns per lag, och det som beställaren vill ha.

---

## Så är koden uppbyggd

Programmet går att köra direkt, utan databas. Sidorna är färdiga och ska inte behöva ändras, förutom där en kommentar säger det.

| Mapp | Innehåll | Vad ni gör |
|------|----------|------------|
| `Components/Pages/` | Sidor och formulär. Pratar bara med interface i `Services/`. | Lägger till fält i formulären när ni bygger ut modellerna. |
| `Components/` (`PageBase`, `InputParser`, `Shared/`) | Gör om fel till meddelanden, bland annat "Inte implementerat ännu", och tolkar inmatning. | Inget. |
| `Models/` | Minimala modeller, bara det som README:n kräver, plus det sidorna behöver. | Bygger ut med fälten beställningen kräver, och tar bort de som inte behövs. |
| `Services/` | Interface och klasser som sidorna anropar. | Bygger allt som kastar `NotImplementedException` eller är märkt `DEMO`. |
| `Data/` | Tom. | Er databaskoppling. |

### Vad fungerar redan?

- **Lag, spelare och matcher** (lista, lägga till, visa, ta bort match) fungerar mot `InMemoryLeagueRepository`. Den är en låtsasdatabas: data ligger i listor och försvinner när programmet stängs.
- **Tabell, positioner och truppgränser** visar demodata från `StandingsService`, `PositionService` och `SquadLimitService`: hårdkodade listor som inte sparas och inte räknas fram. Allt som ändrar något (lägga till eller ta bort position, sätta truppgräns, varna vid truppgränsen) kastar `NotImplementedException`, och då visas *"Inte implementerat ännu"*.
- **Demodatan visar hur sidorna ska se ut** när ni är klara, men den är hårdkodad. Demotabellen visar till exempel samma tabell för alla säsonger, och ändras inte när ni registrerar en match. Ersätt allt som är märkt `DEMO` med riktig logik.
- **Två saker är fel med flit:** resultat visas som `2-1` i stället för `2–1`, och målskillnad visas som `2` i stället för `+2` (önskemål 1). Båda rättas i `ResultFormatter`.
- **Det här saknas med flit:** en match har inget datum och ingen anteckning än, och ett lag kan möta sig självt. Det bygger ni (se kommentarerna i `Models/Match.cs` och `InMemoryLeagueRepository`).

Sök efter `Du behöver bygga ut detta mer` i koden för att hitta alla ställen ni ska bygga vidare på.

### Byt låtsasdatabasen mot en riktig

1. Skriv en klass, till exempel `MongoLeagueRepository` eller `EfLeagueRepository`, som implementerar `ILeagueRepository`.
2. Låt den skapa databasen och seeda exempeldata vid första start, om den är tom.
3. Byt registreringen av `InMemoryLeagueRepository` i `Program.cs` mot er klass.
4. Ta bort `InMemoryLeagueRepository.cs` när ni inte behöver den längre.

Felaktig inmatning som upptäcks i era services: kasta `ArgumentException` med ett meddelande på svenska. Sidan visar meddelandet i stället för att krascha.

### Svenska namn i README, engelska i koden

| README | Koden |
|--------|-------|
| `Lag` (`Namn`) | `Team` (`Name`) |
| `Match` (`Hemmalag`, `Bortalag`, `MalHemma`, `MalBorta`) | `Match` (`HomeTeamId`, `AwayTeamId`, `HomeGoals`, `AwayGoals`) |
| `Spelare` (`Position`, `Fornamn`, `Efternamn`, `Fodelsedatum`, `HairColor`, `HeightCm`, `Religion`, hör till ett lag) | `Player` (`Position`, `FirstName`, `LastName`, `BirthDate`, `HairColor`, `HeightCm`, `Religion`, `TeamId`) |
