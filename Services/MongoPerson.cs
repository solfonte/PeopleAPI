using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class MongoPerson {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get; set;} = default!;

    public string FirstName {get; set;} = default!;

    public string LastName {get; set;} = default!;

    public string NationalID {get; set;} = default!;

    public uint? Age {get; set;}

    public string? AgeStage {get; set;} = default!;
}