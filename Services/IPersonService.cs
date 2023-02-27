using Models;
namespace Services;

public interface IPersonService {

    Task<List<Person>> getPeople();
    Task savePerson(Person person);
    Task<Person> getPersonWithNationalID(string NationalID);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Person updatedPerson);
    Task<Person> GetPersonWithId(string id);
}