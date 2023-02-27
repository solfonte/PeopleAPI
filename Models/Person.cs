using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class Person {
    // TODO: cambiar para que sea abstracto
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string NationalID {get; set;}
    public int Age {get; set;}
    public string? AgeStage {get; set;}
}