namespace TaskMicro.Definitions.Base;

public interface IAppDefinition
{
    void ConfigureService(IServiceCollection services, IConfiguration configuration);
    void ConfigureApplication(WebApplication app, IWebHostEnvironment env);
}