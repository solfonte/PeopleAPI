
namespace Models;

public class PersonManager {
    private readonly IPeopleRepository _peopleRepository;

    public PersonManager (IPeopleRepository peopleRepository) {
        _peopleRepository = peopleRepository;
    }

    private List<Person> getFilteredPeople (List<Person> people, Dictionary<String, String> nameFilter){
        List<Person> filteredPeople = new List<Person>();
        
        if (nameFilter.ContainsKey("FirstName")){
            String firstName = nameFilter["FirstName"];
            foreach (var person in people){
                if (person.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)){
                    filteredPeople.Add(person);
                }
            }
        }

        if (nameFilter.ContainsKey("LastName")){
            List<Person> filteredPeopleAux = new List<Person>();
            String lastName = nameFilter["LastName"];
            foreach (var person in filteredPeople){
                if (person.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)){
                    filteredPeopleAux.Add(person);
                }
            }
            filteredPeople = filteredPeopleAux;
        }

        return filteredPeople;
    }

    public List<Person> GetPeople(Dictionary<String, String> nameFilter) {
        List<Person> people = _peopleRepository.GetPeople();
        if (nameFilter.Count == 0) return people;
        return getFilteredPeople(people, nameFilter);
    }

    public String defineAgeStage (int age) {
        List<String> ageStages = new List<String> {"Niño", "Adolescente", "Adulto", "Octogenario"};
        String stage = "";

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

    public Person SavePerson(Person person) {
        person.AgeStage = defineAgeStage(person.Age);
        return _peopleRepository.SavePerson(person);
    }

    public void DeletePerson(String id) {
        _peopleRepository.DeletePerson(id);
    }

}