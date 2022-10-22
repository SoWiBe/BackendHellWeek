namespace TaskMicro.Models.DbSettings;

public interface IHellWeekDatabaseSettings
{
    string CollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}