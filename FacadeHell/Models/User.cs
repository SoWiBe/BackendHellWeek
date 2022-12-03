using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WeeksMicroservice.Infrastructure.MongoDb;

namespace WeeksMicroservice.Models;

public class User : IMongoModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    [BsonElement("Email")]
    public string Email { get; set; }
    [BsonElement("Age")]
    public string Age { get; set; }
    [BsonElement("Gender")]
    public string Gender { get; set; }
    [BsonElement("Password")]
    public string Password { get; set; }
    [BsonElement("Bio")]
    public string Bio { get; set; }
    [BsonElement("Location")]
    public string Location { get; set; }
    [BsonElement("Level")]
    public string Level { get; set; }
}