using MongoDB.Bson.Serialization.Attributes;
using WeeksMicroservice.Infrastructure.MongoDb;

namespace WeeksMicroservice.Models;

public class Day : IMongoModel
{
    [BsonElement("Id")]
    public string Id { get; set; }
    [BsonElement("Title")]
    public string Title { get; set; }
    [BsonElement("Description")]
    public string Description { get; set; }
    [BsonElement("Tasks")]
    public IEnumerable<Task> Tasks { get; set; }
}