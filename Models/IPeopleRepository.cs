using Models;

public interface IPeopleRepository {

    List<Person> GetPeople();

    Person SavePerson(Person person);

    void DeletePerson(String id);

    Person PatchPerson(String id, Person person);

    Person GetPerson(String id);
    
    Person GetPersonWithNationalID(String nationalID);


}