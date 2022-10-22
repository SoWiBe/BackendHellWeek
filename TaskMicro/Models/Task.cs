using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TaskMicro.Infrastructure.MongoDb;

namespace TaskMicro.Models;

public class Task : IMongoModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("Title")]
    public string Title { get; set; }
    
    [BsonElement("Description")]
    public string Description { get; set; }
    
    [BsonElement("Tag")]
    public string Tag { get; set; }
    
    [BsonElement("Status")]
    public string Status { get; set; }
}