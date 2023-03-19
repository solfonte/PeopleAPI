using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class PersonSchema {
    public string? Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string NationalID {get; set;}
    public uint? Age {get; set;} = default!;
    public string? AgeStage {get; set;} = default!;
}