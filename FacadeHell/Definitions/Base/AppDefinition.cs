

namespace TaskMicro.Definitions.Base;

public abstract class AppDefinition : IAppDefinition
{
    public virtual void ConfigureService(IServiceCollection services, IConfiguration configuration) { }


    public virtual void ConfigureApplication(WebApplication app, IWebHostEnvironment env) { }
}