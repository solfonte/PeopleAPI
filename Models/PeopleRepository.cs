using Services;

namespace Models;

public class PeopleRepository: IPeopleRepository {
    private readonly IPersonService _personService;

    public PeopleRepository(IPersonService personService) { 
        _personService = personService;
    }

    private async Task<List<Person>> _getPeople(){
        return await _personService.getPeople();
    }

    public List<Person> GetPeople(){
        Task<List<Person>> task =_personService.getPeople();
        return task.Result;
    }

    private async Task<Person> _savePerson(Person person){
        await _personService.savePerson(person);
        return await _personService.getPersonWithNationalID(person.NationalID);
    }
    public Person SavePerson(Person person){
        Task<Person> task = _savePerson(person);
        return task.Result;
    }

    private async Task _deletePerson(String id){
        await _personService.RemoveAsync(id);
    }

    public void DeletePerson(String id) {
        Task t =_deletePerson(id);
    }
}