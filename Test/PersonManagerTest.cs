using Xunit;
using Models;
using MockClasses;
using Exceptions;

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
        Person person = new Person("John", "Doe", "2222222", 23);
        personManager.SavePerson(person);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Single(people);
        Assert.Equal(person.GetFirstName(), people[0].GetFirstName());
        Assert.Equal(person.GetLastName(), people[0].GetLastName());
        Assert.Equal(person.GetAge(), people[0].GetAge());
        Assert.Equal(person.GetNationalID(), people[0].GetNationalID());
        Assert.Equal("Adulto", people[0].GetAgeStage());
    }

    [Fact]
    public void whenSavingTwoPeopleThePersonManagerSavesItCorrectly() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person("John", "Doe", "2222222", 23);
        Person personTwo = new Person("John", "Roe", "33333333", 98);
        personManager.SavePerson(personOne);
        personManager.SavePerson(personTwo);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Equal(2, people.Count);
    }

    [Fact]
    public void whenFilteringByFirstNameThePersonManagerReturnsTwoPeople() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person("John", "Doe", "2222222", 23);
        Person personTwo = new Person("John", "Roe", "33333333", 98);       
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
        Person personOne = new Person("John", "Doe", "2222222", 23);
        Person personTwo = new Person("John", "Roe", "33333333", 98);
        personManager.SavePerson(personOne);
        personManager.SavePerson(personTwo);
        Dictionary<String, String> nameFilter = new Dictionary<string, string>();
        nameFilter.Add("FirstName", "John");
        nameFilter.Add("LastName", "Jo");
        List<Person> people = personManager.GetPeople(nameFilter);
        Assert.Equal(0, people.Count);
    }

    [Fact]
     public void whenTryingToSaveAPersonWithANationalIdAlreadyExistingThePersonManagerThrowsException() {
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person person = new Person("John", "Doe", "2222222", 23);
        Person copyOfPerson = new Person("John", "Doe", "2222222", 23);

        personManager.SavePerson(person);

        Assert.Throws<PersonAlreadyExistsException>(() => personManager.SavePerson(copyOfPerson));
    }

    [Fact]
    public void whenTryingToEditAPersonTheResultIsCorrect(){
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person person = new Person("John", "Doe", "2222222", 23);
        Person patchPerson = new Person("John", "Doe", "3333333", 24);

        Person personResult = personManager.SavePerson(person);

        patchPerson.SetId(personResult.GetId());
        Person editedPerson = personManager.PatchPerson(personResult.GetId(), patchPerson);

        Assert.Equal("John", editedPerson.GetFirstName());
        Assert.Equal("Doe", editedPerson.GetLastName());
        Assert.Equal("3333333", editedPerson.GetNationalID());
        Assert.Equal(24, editedPerson.GetAge());
    }

    [Fact]
    public void whenTryingToEditAPersonWithAnAlreadyExistingNationalIdThePersonManagerThrowsException(){
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person personOne = new Person("John", "Doe", "2222222", 23);
        Person personTwo = new Person("Robert", "Doe", "99", 45);
        Person patchPersonTwo = new Person("Robert", "Doe", "2222222", 45);

        personManager.SavePerson(personOne);
        Person personTwoResult = personManager.SavePerson(personTwo);

        patchPersonTwo.SetId(personTwoResult.GetId());
        Assert.Throws<PersonAlreadyExistsException>(() => personManager.PatchPerson(personTwoResult.GetId(), patchPersonTwo));
    }

    [Fact]
    public void whenTryingToDeleteAPersonThatWasSavedThePersonManagerRemovesItCorrectly(){
        PersonManager personManager = new PersonManager(new PeopleRepositoryMock());
        Person person = new Person("John", "Doe", "2222222", 23);
        Person personResult = personManager.SavePerson(person);

        personManager.DeletePerson(personResult.GetId());
        Person result = personManager.GetPerson(personResult.GetId());
        //Assert.Throws<PersonNotFound>(() => personManager.GetPerson(personResult.GetId()));
        Assert.Equal(result.GetFirstName(), "");
        Assert.Equal(result.GetLastName(), "");
        Assert.Equal(result.GetNationalID(), "");
        Assert.Equal(result.GetAge(), 0);
    }

}