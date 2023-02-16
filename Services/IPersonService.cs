using Models;

namespace Services;

interface IPersonService {

    Task<List<Person>> GetAsync();

    
}