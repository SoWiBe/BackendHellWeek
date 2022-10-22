using MongoDB.Driver;
using TaskMicro.Models.DbSettings;

namespace TaskMicro.Services;

public class TasksService
{
    private readonly IMongoCollection<Models.Task> _tasks;

    public TasksService(IHellWeekDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _tasks = database.GetCollection<Models.Task>(settings.CollectionName);
    }

    public List<Models.Task> Get() => _tasks.Find(task => true).ToList();
    public Models.Task Get(string id) => _tasks.Find<Models.Task>(task => task.Id == id).FirstOrDefault();

    public Models.Task Create(Models.Task task)
    {
        _tasks.InsertOne(task);
        return task;
    }

    public void Update(string id, Models.Task taskIn) => _tasks.ReplaceOne(task => task.Id == id, taskIn);
    public void Remove(Models.Task taskIn) => _tasks.DeleteOne(task => task.Id == taskIn.Id);
    public void Remove(string id) => _tasks.DeleteOne(task => task.Id == id);
}