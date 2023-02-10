
namespace People.Models;

public class Person {
    public int Id {get; set;}
    public string? Name {get; set;}
    public string Nationality {get; set;} = default!;
    public int Age {get; set;}
    public string AgeStage {get; set;} = default!;
}