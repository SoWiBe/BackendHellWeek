using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WeeksMicroservice.Infrastructure.MongoDb;

namespace WeeksMicroservice.Models;

public class Week : IMongoModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("Title")]
    public string Title { get; set; }
    
    [BsonElement("Description")]
    public string Description { get; set; }
    
    [BsonElement("Days")]
    public IEnumerable<Day> Days { get; set; }
    
    [BsonElement("Users")]
    public IEnumerable<User> Users { get; set; }

    [BsonElement("StartDate")]
    public string StartDate { get; set; }
    
    [BsonElement("EndDate")]
    public string EndDate { get; set; }
    
    [BsonElement("IsPrivate")]
    public string IsPrivate { get; set; }
}