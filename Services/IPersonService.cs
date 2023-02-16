using Models;

namespace Services;

public interface IPersonService {

    Task<List<Person>> GetAsync();

    
}