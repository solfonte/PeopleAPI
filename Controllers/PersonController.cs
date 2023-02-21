using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]

public class PersonController : ControllerBase {

    private readonly PersonManager _personManager;

    public PersonController (PersonManager personManager) =>
        _personManager = personManager;
        
    [HttpGet]
    public List<Person> GetAll() {
        List<Person> people =_personManager.GetPeople();
        return people;
    } 

    [HttpPost]
    public Person SavePerson(Person person) {
        return _personManager.SavePerson(person);
    }

    [HttpDelete("{id:length(24)}")]
    public void DeletePerson(String id) {
        _personManager.DeletePerson(id);
    }
}