# Data

Här ligger databaskopplingen. Ni väljer databas själva, och motiverar valet i reflektionen.

Krav på all databaskod i den här uppgiften:

- **Connectionstring** kommer från user-secrets, under nyckeln `DB_CONNECTION`. Den står aldrig i koden eller i repot.
- **Vid första start** skapar programmet databasen och tabellerna/collections, och lägger in exempeldata (seed) om databasen är tom. Ingen manuell SQL eller migrering för att komma igång.
- **ADO.NET** används inte.

`exempel_mongo_context.md` visar en MongoDB-koppling som exempel. Om ni väljer en annan databas bygger ni motsvarande klass själva.
