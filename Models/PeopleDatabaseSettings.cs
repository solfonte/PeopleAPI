namespace Models;

public class PeopleDatabaseSettings {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PersonCollectionName { get; set; } = null!;
}