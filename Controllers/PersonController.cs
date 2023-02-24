using Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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
    public List<Person> GetAll() {
        Dictionary<String, String> nameFilter;
        nameFilter = makeNameFilter(this.Request.QueryString);
        List<Person> people = _personManager.GetPeople(nameFilter);
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

    [HttpGet("{id:length(24)}")]
    public Person GetPerson(String id) {
        return _personManager.GetPerson(id);
    }

    [HttpPatch("{id:length(24)}")]
    public void PatchPerson(String id, Person person) {
        person.Id = id;
        Console.Write("aca entra?");

         _personManager.PatchPerson(id, person);
        
    }
}