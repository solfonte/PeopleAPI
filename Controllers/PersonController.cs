using Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Exceptions;

namespace Controllers;

[ApiController]
[Route("[controller]")]

public class PersonController : ControllerBase {

    private readonly PersonManager _personManager;

    public PersonController (PersonManager personManager) =>
        _personManager = personManager;


    private Dictionary<String, String> makeNameFilter(QueryString QueryString){
        var parsed = HttpUtility.ParseQueryString(this.Request.QueryString.ToString());
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();

        if (parsed["FirstName"] != null) {
            nameFilter.Add("FirstName", parsed["FirstName"]);
        }

        if (parsed["LastName"] != null) {
            nameFilter.Add("LastName", parsed["LastName"]);
        }

        return nameFilter;
    }
    
    [HttpGet]
    public IActionResult GetAll() {
        Dictionary<String, String> nameFilter;
        nameFilter = makeNameFilter(this.Request.QueryString);
        List<Person> people = _personManager.GetPeople(nameFilter);
        return Ok(people);
    } 

    [HttpPost]
    public IActionResult SavePerson(Person person) {
        try {
            Person p = _personManager.SavePerson(person);
            return Ok(p);
        }catch (MissingArgumentException MissingArgException) {
            return UnprocessableEntity();
        }catch(PersonAlreadyExistsException AlreadyExistsException) {
            return Conflict();
        }catch (Exception e){
            Console.Write("aca");
            return Ok();
        }
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult DeletePerson(String id) {
        _personManager.DeletePerson(id);
        return Ok();
    }
    
    [HttpPatch("{id:length(24)}")]
    public IActionResult PatchPerson(String id, Person person) {

        try {
            person.Id = id;
            Person p = _personManager.PatchPerson(id, person);
            return Ok(p);
        }catch (MissingArgumentException e) {
            return UnprocessableEntity(e.Message);
        }catch(PersonNotFound e){
            return NotFound(e.Message);
        }catch(PersonAlreadyExistsException e){
            return Conflict();
        }
    }
}