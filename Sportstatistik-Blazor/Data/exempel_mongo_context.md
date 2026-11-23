# Exempel: en databaskoppling med MongoDB

Det här exemplet visar hur programmet ansluter till MongoDB och hämtar en collection. Det är ett exempel. Ni väljer databas själva.

Installera drivrutinen i projektmappen:

```
dotnet add package MongoDB.Driver
```

Klassen tar emot connectionstringen utifrån. Den läses från user-secrets i `Program.cs`, aldrig i koden:

```csharp
using MongoDB.Driver;

public class LibraryDatabase
{
    private readonly IMongoDatabase _database;

    public LibraryDatabase(string connectionString)
    {
        // Vakt: stanna tidigt om connectionstringen saknas
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DB_CONNECTION saknas. Se README, avsnittet om user-secrets.");
        }

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("bibliotek");
    }

    public IMongoCollection<Book> Books => _database.GetCollection<Book>("books");
}
```

Reflektion: en collection är som en tabell, men varje post är ett dokument. Klassen `Book` blir dokumentets form.

## Hela koden

```csharp
using MongoDB.Driver;

public class LibraryDatabase
{
    private readonly IMongoDatabase _database;

    public LibraryDatabase(string connectionString)
    {
        // Vakt: stanna tidigt om connectionstringen saknas
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DB_CONNECTION saknas. Se README, avsnittet om user-secrets.");
        }

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("bibliotek");
    }

    public IMongoCollection<Book> Books => _database.GetCollection<Book>("books");
}
```
