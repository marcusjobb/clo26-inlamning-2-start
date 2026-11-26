# Gruppen

> Fyll i det här innan ni börjar koda. Läraren använder filen för att veta vem som gjort vad.

## Grupp

- **Gruppnamn:** Hells Kitchen (Raman Tajerian och Martin Bäcklund)
- **Projekt:** Recept
- **Databas:** MongoDB. Vi valde MongoDB eftersom ett recept med sina ingredienser passar som ett enda dokument som alltid läses som en helhet, det ger enklare lagring och färre uppslag än i en relationsdatabas. Det är dessutom en databasserver, vilket gav oss möjlighet att jämföra med en fildatabas och lära oss en ny databastyp denna gången.
- **Databastyp i Inlämning 1 (fil eller server, för varje person):** Vi båda använde SQLite för inlämning 1
- **Gränssnitt:** MVC

## Medlemmar

| Namn | Roll i gruppen | Ansvar i koden (vilka klasser/delar) |
| ---- | -------------- | ------------------------------------ |
| Raman Tajerian | Projektledning, test och kvalitet av Martins kod, skriva kod, rapport | Modeller (Recipe, Ingredient, Category), IRecipeRepository och ICategoryRepository med Mongo-implementationer, anslutning och seed i Program.cs, RecipeService, PortionScaler, AmountFormatter, RecipeBuilder, RecipesController och CategoriesController med vyer |
| Martin Bäcklund | Kodskrivande, test och kvalitet av Ramans kod, rapport | Modeller (Chef, MealPlanEntry, Warning), IChefRepository, IMealPlanRepository och IWarningRepository med Mongo-implementationer, MealPlanService, ShoppingListService, WeekHelper, ILimitObserver och LimitWarningObserver, MealPlanController, ShoppingListController och ChefsController med vyer |

## Vem gjorde vad

| Namn | Git-namn (`user.name`) | Ansvar i koden | Ansvar i dokument (README, GRANSKNINGSNOTIS, log) |
|------|------------------------|----------------|---------------------------------------------------|
| Raman Tajerian | Raman Tajerian | Recept, kategorier, anslutning och seed, Builder | README: Fält och data, UML, beslutslogg. GRUPP.md, kanban |
| Martin Bäcklund | Martin | Veckoplan, inköpslista, Observer, varningar | README: gränssnittsplan, refactoring-logg. GRANSKNINGSNOTIS.md, peer_review_log.md |

## Kanban

- **Verktyg:** GitHub Projects
- **Länk:** https://github.com/users/raman-tajerian/projects/4/views/1
- **Inbjudan till `marcusjobb` bekräftad:** [X] ja

## Gruppregler

Skriv minst fem regler som ni faktiskt kommer att följa.

1. Hur ofta ni syncar (datum/tid): Varje dag med start 26/11 ungefär kvällstid. Runt 17-22. Vi gör pull och push vid varje arbetspass och skriver en kort status i chatten.
2. Hur ni gör branch och merge (till exempel en branch per uppgift, och ingen push direkt på `main` utan att den andra läst): En branch per uppgift. Ingen push direkt på `main` utan att den andra har läst koden (pull request eller genomgång tillsammans).
3. Hur ni fördelar uppgifter (kanban, och en uppgift per person i taget): Vi fördelar via kanban, och var och en har en uppgift i taget. Ett kort flyttas till In Progress när man börjar och till Done när det är testat.
4. Hur ni hanterar oenighet i kod (vem avgör, och vad gäller om ni inte blir överens): Vi provar båda förslagen kort och väljer det enklaste och mest läsbara. Är vi fortfarande oense avgör den som äger uppgiften, och beslutet skrivs i beslutsloggen med de alternativ vi valde bort. Vi har jobbat tidigare med varandra och är vana nu vid det.
5. Hur ni använder AI tillsammans (vad som får genereras, och hur ni granskar det): AI får användas till förklaringar och kodskelett. Inget klistras in utan att vi båda förstår det, och vi kontrollerar det genom att köra och testa koden. Den AI vi använt förs in i AI-deklarationen i README.md.

## Kanban-status vid inlämning

- Antal kort i Done: 
- Antal kort kvar i Backlog:
