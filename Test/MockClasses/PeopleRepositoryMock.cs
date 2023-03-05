using Models;

namespace MockClasses;

class PeopleRepositoryMock : IPeopleRepository {

    private List<Person> mockPeople = new List<Person>();
    private string idGenerator = "0";

    public PeopleRepositoryMock () {}

    public List<Person> GetPeople(){
        return mockPeople;
    }

    public Person SavePerson(Person person){
        person.SetId(idGenerator);
        idGenerator += "a";
        mockPeople.Add(person);
        return person;
    }

    public void DeletePerson(String id){}

    public Person PatchPerson(String id, Person person){
        return new Person("","","",0);
    }

    public Person GetPerson(String id){
        return new Person("","","",0);
    }

    public Person GetPersonWithNationalID(string nationalID){ 
        Person person = new Person("","","",0);
        foreach (Person p in mockPeople){
            if (p.GetNationalID() == nationalID){
                person = p;
            }
        }
        return person;
    }
}