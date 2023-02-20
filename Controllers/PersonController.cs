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
    public async Task<List<Person>> GetAll() {
        return await _personManager.GetPeople();
    } 

    [HttpPost]
    public async Task<Person> SavePerson(Person person) {
        return await _personManager.SavePerson(person);
    }

}