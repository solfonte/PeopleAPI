
namespace Models;

public class PersonManager {
    private readonly PeopleRepository _peopleRepository;

    public PersonManager (PeopleRepository peopleRepository) {
        _peopleRepository = peopleRepository;
    }

    public async Task<List<Person>> GetPeople() {
        return await _peopleRepository.GetPeople();
    }
}