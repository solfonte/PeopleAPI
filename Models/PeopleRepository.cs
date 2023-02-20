using Services;

namespace Models;

public class PeopleRepository {
    private readonly IPersonService _personService;

    public PeopleRepository(IPersonService personService) { 
        _personService = personService;
    }

    public async Task<List<Person>> GetPeople(){
        return await _personService.getPeople();
    }

    public async Task<Person> SavePerson(Person person){
        await _personService.savePerson(person);
        return await _personService.getPersonWithNationalID(person.NationalID);

    }
}