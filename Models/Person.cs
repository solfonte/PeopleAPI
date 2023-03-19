

namespace Models;

public class Person {
    private string id = default!;
    private string firstName;
    private string lastName;
    private string nationalID;
    private uint? age;
    private string? ageStage;

    public Person (string firstName, string lastName, string nationalID, uint? age){
        this.firstName = firstName;
        this.lastName = lastName;
        this.nationalID = nationalID;
        this.age = age;
        this.ageStage = ageStage;
    }

    public string GetId(){
        return id;
    }
    public string GetFirstName(){
        return firstName;
    }
    public string GetLastName(){
        return lastName;
    }
    public string GetNationalID(){
        return nationalID;
    }
    public uint? GetAge(){
        return age;
    }
    public string GetAgeStage(){
        return ageStage != null? ageStage : "";
    }
    public void SetAgeStage (string ageStage){
        this.ageStage = ageStage;
    }
    public void SetId(string id){
        this.id = id;
    }
}
