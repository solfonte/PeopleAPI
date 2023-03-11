using Exceptions;

namespace Models;

public class PersonManager {
    private readonly IPeopleRepository _peopleRepository;

    public PersonManager (IPeopleRepository peopleRepository) {
        _peopleRepository = peopleRepository;
    }

    private List<Person> getFilteredPeople (List<Person> people, Dictionary<String, String> nameFilter){
        string firstName = nameFilter.ContainsKey("FirstName")? nameFilter["FirstName"] : "";
        string lastName = nameFilter.ContainsKey("LastName")? nameFilter["LastName"] : "";
        return _peopleRepository.GetPeopleWithName(firstName, lastName);
    }

    public List<Person> GetPeople(Dictionary<String, String> nameFilter) {
        List<Person> people = _peopleRepository.GetPeople();
        if (nameFilter.Count == 0) return people;
        return getFilteredPeople(people, nameFilter);
    }

    public String defineAgeStage (int? age) {
        List<String> ageStages = new List<String> {"Niño", "Adolescente", "Adulto", "Octogenario"};
        String stage = "";

        if (age == default) return stage;

        if (age < 11) {
                stage = ageStages[0];
        } else if (11 <= age && age < 18) {
                stage = ageStages[1];
        } else if (18 <= age && age < 80) {
                stage = ageStages[2];
        }else {
                stage = ageStages[3];
        }
        return stage;
    }
    private bool missingArguments (Person person) {
        return (String.IsNullOrEmpty(person.GetFirstName()) ||
                String.IsNullOrEmpty(person.GetLastName()) ||
                String.IsNullOrEmpty(person.GetNationalID()));
    }
    private bool personAlreadyExists (Person person) {
        
        bool personExists = false;

        Person p = _peopleRepository.GetPersonWithNationalID(person.GetNationalID());  
        if (p.GetNationalID() == person.GetNationalID() && person.GetId() != p.GetId()){
            personExists = true;
        }
        return personExists;
    }

    public Person SavePerson(Person person) {
        if (missingArguments(person)){
            throw new MissingArgumentException();
        }
        if (personAlreadyExists(person)) {
            throw new PersonAlreadyExistsException();
        }
        person.SetAgeStage(defineAgeStage(person.GetAge()));
        return _peopleRepository.SavePerson(person);
    }

    public void DeletePerson(String id) {
        _peopleRepository.DeletePerson(id);
    }

    public Person PatchPerson(String id, Person person) {
        if (missingArguments(person)){
            throw new MissingArgumentException();
        }
        if (personAlreadyExists(person)) {
            throw new PersonAlreadyExistsException();
        }
        person.SetAgeStage(defineAgeStage(person.GetAge()));
        return _peopleRepository.PatchPerson(id, person);
    }

    public Person GetPerson(String id){
        return _peopleRepository.GetPerson(id);
    }
}