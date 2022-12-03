using MongoDB.Bson.Serialization.Attributes;

namespace TaskMicro.Infrastructure.MongoDb;

public interface IMongoModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
}