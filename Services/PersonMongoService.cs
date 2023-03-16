using Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using MongoDB.Bson;

namespace Services;

public class PersonMongoService : IPersonService {

    private readonly IMongoCollection<MongoPerson> _personCollection;

    public PersonMongoService(
        IOptions<PeopleDatabaseSettings> peopleDatabaseSettings)
    {
        var mongoClient = new MongoClient(
             "mongodb+srv://admin:admin@peopleapi.8zfwkla.mongodb.net/?retryWrites=true&w=majority");

        var mongoDatabase = mongoClient.GetDatabase(
            "People_db");

        _personCollection = mongoDatabase.GetCollection<MongoPerson>(
            "People");
    }

    public async Task<List<Person>> getPeople() {
        List<MongoPerson> mongoPeople = await _personCollection.Find(_ => true).ToListAsync();
        List<Person> people = new List<Person>();

        foreach(MongoPerson p in mongoPeople){
            Person person = new Person(p.FirstName, p.LastName, p.NationalID, p.Age);
            person.SetAgeStage(p.AgeStage);
            person.SetId(p.Id);
            people.Add(person);
        }
        return people;
    }

    public async Task savePerson(Person person) {
        MongoPerson mongoPerson = new MongoPerson(){
            FirstName = person.GetFirstName(),
            LastName = person.GetLastName(),
            NationalID = person.GetNationalID(),
            Age = person.GetAge(),
            AgeStage = person.GetAgeStage(),
        };
        await _personCollection.InsertOneAsync(mongoPerson);
    }

    public async Task<Person> getPersonWithNationalID(string nationalID){
        try {
            MongoPerson mongoPerson = await _personCollection.Find(Builders<MongoPerson>.Filter.Eq("NationalID", nationalID)).Limit(1).SingleAsync();
            Person person = new Person(mongoPerson.FirstName, mongoPerson.LastName, mongoPerson.NationalID, mongoPerson.Age);
            person.SetAgeStage(mongoPerson.AgeStage);
            person.SetId(mongoPerson.Id);
            return person;
        }catch (Exception e){
            return new Person("","","",0); 
        }
    }

    public async Task RemoveAsync(string id) {
        await _personCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(string id, Person updatedPerson){
        MongoPerson updatedMongoPerson = new MongoPerson(){
            Id = updatedPerson.GetId(),
            FirstName = updatedPerson.GetFirstName(),
            LastName = updatedPerson.GetLastName(),
            NationalID = updatedPerson.GetNationalID(),
            Age = updatedPerson.GetAge(),
            AgeStage = updatedPerson.GetAgeStage(),
        };
        await _personCollection.ReplaceOneAsync(x => x.Id == id, updatedMongoPerson);
    }

    public async Task<Person> GetPersonWithId(string id){
        MongoPerson mongoPerson = await _personCollection.Find(Builders<MongoPerson>.Filter.Eq("Id", id)).Limit(1).SingleAsync();
        Person person = new Person(mongoPerson.FirstName, mongoPerson.LastName, mongoPerson.NationalID, mongoPerson.Age);
        person.SetAgeStage(mongoPerson.AgeStage);
        person.SetId(mongoPerson.Id);
        return person;
    }

    public async Task<List<Person>> GetPeopleWithName(string firstName, string lastName){
        var escapeFirstNameText = Regex.Escape(firstName);
        var firstNameRegex = new Regex(escapeFirstNameText, RegexOptions.IgnoreCase);
        var escapeLastNameText = Regex.Escape(lastName);
        var lastNameRegex = new Regex(escapeLastNameText, RegexOptions.IgnoreCase);
        
        var firstNamefilter = Builders<MongoPerson>.Filter.Regex("FirstName", BsonRegularExpression.Create(firstNameRegex));
        var lastNamefilter = Builders<MongoPerson>.Filter.Regex("LastName", BsonRegularExpression.Create(lastNameRegex));
        var nameFilter = Builders<MongoPerson>.Filter.And(firstNamefilter, lastNamefilter);

        List<MongoPerson> mongoPeople = await _personCollection.Find(nameFilter).ToListAsync();
        List<Person> people = new List<Person>();
        foreach(MongoPerson p in mongoPeople){
            Person person = new Person(p.FirstName, p.LastName, p.NationalID, p.Age);
            person.SetAgeStage(p.AgeStage);
            person.SetId(p.Id);
            people.Add(person);
        }
        return people;
    }

}