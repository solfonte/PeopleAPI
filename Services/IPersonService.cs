using Models;
namespace Services;

public interface IPersonService {

    Task<List<Person>> getPeople();
    Task savePerson(Person person);
    Task<Person> getPersonWithNationalID(int NationalID);
    Task RemoveAsync(string id);
}