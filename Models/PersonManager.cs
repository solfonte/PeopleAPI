
namespace Models;

public class PersonManager {
    private readonly IPeopleRepository _peopleRepository;

    public PersonManager (IPeopleRepository peopleRepository) {
        _peopleRepository = peopleRepository;
    }

    public List<Person> GetPeople() {
        return _peopleRepository.GetPeople();
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