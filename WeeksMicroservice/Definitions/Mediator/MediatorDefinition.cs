using System.Reflection;
using MediatR;
using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Mediator;

public class MediatorDefinition : AppDefinition
{
    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}