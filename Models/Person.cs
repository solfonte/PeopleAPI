

namespace Models;

public class Person {
    private string id;
    private string firstName;
    private string lastName;
    private string nationalID;
    private int age;
    private string? ageStage;

    public Person (string firstName, string lastName, string nationalID, int age){
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
    public int GetAge(){
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
