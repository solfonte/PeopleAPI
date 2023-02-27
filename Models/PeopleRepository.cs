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
        Task t = _deletePerson(id);
    }

    private async Task<Person> _patchPerson(String id, Person person){
        await _personService.UpdateAsync(id, person);
        Person updatedPerson = await _personService.GetPersonWithId(id);
        return updatedPerson;
    }

    public Person PatchPerson(String id, Person person){
        Task<Person> t = _patchPerson(id, person);
        return t.Result;
    }

    private async Task<Person> _getPerson(String id) {
        Person person = await _personService.GetPersonWithId(id);
        return person;
    }

    public Person GetPerson(String id){
        Task<Person> t = _getPerson(id);
        return t.Result;
    }

    private Task<Person> _getPersonWithNationalID (String nationalID){
        return _personService.getPersonWithNationalID(nationalID);
    }

    public Person GetPersonWithNationalID(String nationalID){
        Task<Person> t = _getPersonWithNationalID(nationalID);
        return t.Result;
    }
}