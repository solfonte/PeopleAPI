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

    public void DeletePerson(String id){
        Person person = new Person("", "", "", 0);
        foreach(Person p in mockPeople){
            if (p.GetId() == id){
                person = p;
            }
        }
        if (!String.IsNullOrEmpty(person.GetNationalID())){
            mockPeople.Remove(person);
        }
    }


    public Person PatchPerson(String id, Person person){
        Person p = new Person("", "", "", 0);
        for(int i = 0; i < mockPeople.Count; i++){
            if (mockPeople[i].GetId() == id){
                mockPeople[i] = person;
            }
        }
        return person;
    }

    public Person GetPerson(String id){
        Person person = new Person("", "", "", 0);
        foreach(Person p in mockPeople){
            if (p.GetId() == id){
                person = p;
            }
        }
        return person;
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