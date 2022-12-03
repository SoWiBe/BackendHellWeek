using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WeeksMicroservice.Infrastructure.MongoDb;

namespace WeeksMicroservice.Models;

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