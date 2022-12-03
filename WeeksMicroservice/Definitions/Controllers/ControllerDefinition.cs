using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Controllers;

public class ControllerDefinition : AppDefinition
{
    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
    }
}