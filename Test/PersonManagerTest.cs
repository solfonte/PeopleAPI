using Xunit;
using Models;
using MockClasses;

public class PersonManagerTest {

    [Fact]
    public void whenAgeIsFourTheAgeStageValueIsCorrect() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        String ageStage = personManager.defineAgeStage(4);
        Assert.Equal("Niño", ageStage);
    }

    [Fact]
    public void whenAgeIsFifteenTheAgeStageValueIsCorrect() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        String ageStage = personManager.defineAgeStage(15);
        Assert.Equal("Adolescente", ageStage);
    }

    [Fact]
    public void whenAgeIsFourtyTheAgeStageValueIsCorrect() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        String ageStage = personManager.defineAgeStage(40);
        Assert.Equal("Adulto", ageStage);
    }

    [Fact]
    public void whenAgeIsNinetyFiveTheAgeStageValueIsCorrect() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        String ageStage = personManager.defineAgeStage(95);
        Assert.Equal("Octogenario", ageStage);
    }

    [Fact]
    public void whenSavingOnlyOnePersonThePersonManagerSavesItCorrectly() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person person = new Person() {
            FirstName = "John",
            LastName = "Doe",
            NationalID = "2222222",
            Age = 23,
        };
        personManager.SavePerson(person);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Single(people);
        Assert.Equal(person.FirstName, people[0].FirstName);
        Assert.Equal(person.LastName, people[0].LastName);
        Assert.Equal(person.Age, people[0].Age);
        Assert.Equal(person.NationalID, people[0].NationalID);
        Assert.Equal("Adulto", people[0].AgeStage);
    }

    [Fact]
    public void whenSavingTwoPeopleThePersonManagerSavesItCorrectly() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person() {
            FirstName = "John",
            LastName = "Doe",
            NationalID = "2222222",
            Age = 23,
        };
        Person personTwo = new Person() {
            FirstName = "John",
            LastName = "Roe",
            NationalID = "33333333",
            Age = 98,
        };
        personManager.SavePerson(personOne);
        personManager.SavePerson(personTwo);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Equal(2, people.Count);
    }

    [Fact]
    public void whenFilteringByFirstNameThePersonManagerReturnsTwoPeople() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person() {
            FirstName = "John",
            LastName = "Doe",
            NationalID = "2222222",
            Age = 23,
        };
        Person personTwo = new Person() {
            FirstName = "John",
            LastName = "Roe",
            NationalID = "33333333",
            Age = 98,
        };
        personManager.SavePerson(personOne);
        personManager.SavePerson(personTwo);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        nameFilter.Add("FirstName", "John");
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Equal(2, people.Count);
    }
    [Fact]
     public void whenFilteringByFirstNameAndLastNameThePersonManagerReturnsEmpty() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person() {
            FirstName = "John",
            LastName = "Doe",
            NationalID = "2222222",
            Age = 23,
        };
        Person personTwo = new Person() {
            FirstName = "John",
            LastName = "Roe",
            NationalID = "33333333",
            Age = 98,
        };
        personManager.SavePerson(personOne);
        personManager.SavePerson(personTwo);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        nameFilter.Add("FirstName", "John");
        nameFilter.Add("LastName", "Jo");
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Equal(0, people.Count);
    }
}