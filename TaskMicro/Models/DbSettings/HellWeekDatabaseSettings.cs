

namespace TaskMicro.Models.DbSettings;

public class HellWeekDatabaseSettings : IHellWeekDatabaseSettings
{
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}