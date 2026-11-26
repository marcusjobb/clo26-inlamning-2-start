using MongoDB.Bson;
using Sportstatistik.Models;

namespace Sportstatistik.Services;

public class PositionService : IPositionService
{
    public List<Position> GetAll() =>
    [
        new Position { Id = ObjectId.Parse("000000000000000000000001"), Name = "Målvakt" },
        new Position { Id = ObjectId.Parse("000000000000000000000002"), Name = "Back" },
        new Position { Id = ObjectId.Parse("000000000000000000000003"), Name = "Mittfält" },
        new Position { Id = ObjectId.Parse("000000000000000000000004"), Name = "Forward" },
        new Position { Id = ObjectId.Parse("000000000000000000000005"), Name = "Övrigt" },
    ];

    public void Add(string name) => throw new NotImplementedException();

    public void Delete(ObjectId positionId) => throw new NotImplementedException();
}