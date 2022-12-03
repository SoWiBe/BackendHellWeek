
using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Docs;

public class DocsDefinition : AppDefinition
{
    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseReDoc();
    }

    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

}