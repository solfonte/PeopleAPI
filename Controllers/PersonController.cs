using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]

public class PersonController : ControllerBase {

    private readonly PeopleRepository _peopleRepository;

    public PersonController (PeopleRepository peopleRepository) =>
        _peopleRepository = peopleRepository;
        
    [HttpGet]
    public async Task<List<Person>> GetAll() {
        return await _peopleRepository.getPeople();
    } 



}