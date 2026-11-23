# Exempel: ett Repository (här med MongoDB som exempel)

Repositoryt står mellan programmet och databasen. Resten av koden pratar med interfacet, och vet inte hur data sparas.

```csharp
using MongoDB.Bson;
using MongoDB.Driver;

public interface IBookRepository
{
    void Add(Book book);
    List<Book> GetAll();
    void Delete(ObjectId id);
}

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _books;

    public BookRepository(LibraryDatabase database)
    {
        _books = database.Books;
    }

    public void Add(Book book) => _books.InsertOne(book);

    public List<Book> GetAll() => _books.Find(_ => true).ToList();

    public void Delete(ObjectId id) => _books.DeleteOne(b => b.Id == id);
}
```

Reflektion: interfacet säger *vad*, inte *hur*. Byter ni databas senare behöver bara den här klassen ändras, inte programmet som använder den.
