using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class Person {
    // TODO: cambiar para que sea abstracto
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string? Name {get; set;}
    public string Nationality {get; set;} = default!;
    public int Age {get; set;}
    public string AgeStage {get; set;} = default!;
}