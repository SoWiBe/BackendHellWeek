using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskMicro.Definitions.Base;
using TaskMicro.Infrastructure.MongoDb;

namespace TaskMicro.Definitions.Mongo;

public class MongoDbDefinition : AppDefinition
{
    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("mongo");

        services.AddTransient<IMongoClient>(provider => new MongoClient(connectionString));

        services.AddSingleton<IDbWorker<Models.Task>>(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            var settings = new MongoDbSettings()
            {
                ConnectionString = connectionString,
                CollectionName = configuration["Tasks:CollectionName"],
                DatabaseName = configuration["Tasks:DatabaseName"]
            };
            var logger = provider.GetRequiredService<ILogger<MongoDbWorker<Models.Task>>>();
            return new MongoDbWorker<Models.Task>(client, settings, logger);
        });
        
    }
}