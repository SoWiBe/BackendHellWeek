using MongoDB.Driver;

namespace TaskMicro.Infrastructure.MongoDb.Context;

public interface IMongoDbContext<T> : IDbContext<T>
{
    IMongoCollection<T> GetCollection();
}

public interface IDbContext<out T> : IEnumerable<T>
{
}