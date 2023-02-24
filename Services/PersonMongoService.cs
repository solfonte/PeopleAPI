using Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Services;

public class PersonMongoService : IPersonService {

    private readonly IMongoCollection<Person> _personCollection;

    public PersonMongoService(
        IOptions<PeopleDatabaseSettings> peopleDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            peopleDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            peopleDatabaseSettings.Value.DatabaseName);

        _personCollection = mongoDatabase.GetCollection<Person>(
            peopleDatabaseSettings.Value.PersonCollectionName);
    }

    public async Task<List<Person>> getPeople() {
        return await _personCollection.Find(_ => true).ToListAsync();
    }

    public async Task savePerson(Person person) {
        await _personCollection.InsertOneAsync(person);
    }

    public async Task<Person> getPersonWithNationalID(ulong nationalID){
        return await _personCollection.Find(Builders<Person>.Filter.Eq("NationalID", nationalID)).Limit(1).SingleAsync();
    }

    public async Task RemoveAsync(string id) {
        await _personCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(string id, Person updatedPerson){
        await _personCollection.ReplaceOneAsync(x => x.Id == id, updatedPerson);
    }

    public async Task<Person> GetPersonWithId(string id){
        return await _personCollection.Find(Builders<Person>.Filter.Eq("Id", id)).Limit(1).SingleAsync();
    }

}