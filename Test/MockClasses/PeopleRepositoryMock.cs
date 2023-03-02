using Models;

namespace MockClasses;

class PeopleRepositoryMock : IPeopleRepository {

    private List<Person> mockPeople = new List<Person>();

    public PeopleRepositoryMock () {}

    public List<Person> GetPeople(){
        return mockPeople;
    }

    public Person SavePerson(Person person){
        mockPeople.Add(person);
        return person;
    }

    public void DeletePerson(String id){}

    public Person PatchPerson(String id, Person person){
        return new Person();
    }

    public Person GetPerson(String id){
        return new Person();

    }

    public Person GetPersonWithNationalID(String nationalID){ 
        Person person = new Person();
        foreach (Person p in mockPeople){
            if (p.NationalID == nationalID){
                person = p;
            }
        }
        return person;
    }
}