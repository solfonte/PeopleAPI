using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class Person {
    // TODO: cambiar para que sea abstracto
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string FirstName {get; set;} = default!;
    public string LastName {get; set;} = default!;
    public string NationalID {get; set;} = default!;
    public int Age {get; set;}
    public string AgeStage {get; set;} = default!;
}