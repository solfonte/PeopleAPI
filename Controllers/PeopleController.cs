using Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Exceptions;

namespace Controllers;

[ApiController]
[Route("[controller]")]

public class PeopleController : ControllerBase {

    private readonly PersonManager _personManager;

    public PeopleController (PersonManager personManager) =>
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
        List<PersonSchema> peopleResponse = new List<PersonSchema>();
        foreach (Person p in people){
            peopleResponse.Add(new PersonSchema(){
                Id = p.GetId(),
                FirstName = p.GetFirstName(),
                LastName = p.GetLastName(),
                NationalID = p.GetNationalID(),
                Age = p.GetAge(),
                AgeStage = p.GetAgeStage()
            });
        }

        return Ok(peopleResponse);
    } 

    [HttpPost]
    public IActionResult SavePerson(PersonSchema personToSave) {
        try {
            Person person = new Person(personToSave.FirstName, personToSave.LastName, 
                                        personToSave.NationalID, personToSave.Age);
            Person p = _personManager.SavePerson(person);
            personToSave.Id = p.GetId();
            return Ok(personToSave);
        }catch (MissingArgumentException) {
            return UnprocessableEntity("Faltan argumentos");
        }catch(PersonAlreadyExistsException) {
            return Conflict();
        }
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult DeletePerson(String id) {
        _personManager.DeletePerson(id);
        return Ok();
    }
    
    [HttpPatch("{id:length(24)}")]
    public IActionResult PatchPerson(String id, PersonSchema personToPatch) {

        try {
            Person person = new Person(personToPatch.FirstName, personToPatch.LastName, 
                                        personToPatch.NationalID, personToPatch.Age);
            person.SetAgeStage(personToPatch.AgeStage);
            person.SetId(id);
            Person updatedPerson = _personManager.PatchPerson(id, person);
            PersonSchema personResponse = new PersonSchema(){
                Id = id,
                FirstName = updatedPerson.GetFirstName(),
                LastName = updatedPerson.GetLastName(),
                NationalID = updatedPerson.GetNationalID(),
                Age = updatedPerson.GetAge(),
                AgeStage = updatedPerson.GetAgeStage()
            };
            return Ok(personResponse);
        }catch (MissingArgumentException e) {
            return UnprocessableEntity(e.Message);
        }catch(PersonNotFound e){
            return NotFound(e.Message);
        }catch(PersonAlreadyExistsException){
            return Conflict();
        }
    }
}