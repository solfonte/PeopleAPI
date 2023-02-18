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
}