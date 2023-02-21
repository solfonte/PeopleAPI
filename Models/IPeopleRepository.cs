using Models;

public interface IPeopleRepository {

    List<Person> GetPeople();

    Person SavePerson(Person person);

    void DeletePerson(String id);
}