using Microsoft.Extensions.Options;
using TaskMicro.Definitions.Base;
using TaskMicro.Models.DbSettings;
using TaskMicro.Services;

namespace TaskMicro.Definitions.Mongo;

public class MongoDbDefinition : AppDefinition
{
    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<HellWeekDatabaseSettings>(configuration.GetSection(nameof(HellWeekDatabaseSettings)));
        services.AddSingleton<IHellWeekDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<HellWeekDatabaseSettings>>().Value);
        
        services.AddSingleton<TasksService>();
        
    }
}