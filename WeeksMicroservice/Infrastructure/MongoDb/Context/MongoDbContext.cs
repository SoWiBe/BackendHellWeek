using System.Collections;
using MongoDB.Driver;

namespace TaskMicro.Infrastructure.MongoDb.Context;

public class MongoDbContext<T> : IMongoDbContext<T>
{
    private readonly IMongoCollection<T> _collection;
    public MongoDbContext(MongoDbSettings settings, IMongoClient client) =>
        _collection = client.GetDatabase(settings.DatabaseName).GetCollection<T>(settings.CollectionName);
    
    public IMongoCollection<T> GetCollection() => _collection;
    public IEnumerator<T> GetEnumerator() => _collection.AsQueryable().AsEnumerable().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}