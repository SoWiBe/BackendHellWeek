using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Common;

public class CommonDefinition : AppDefinition
{
    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
                => app.UseHttpsRedirection();

    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
        services.AddMemoryCache();
    }
}