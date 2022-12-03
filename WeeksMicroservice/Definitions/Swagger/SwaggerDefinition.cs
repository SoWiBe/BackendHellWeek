using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Swagger;

public class SwaggerDefinition : AppDefinition
{ 
    private const string _swaggerConfig = "/swagger/v1/swagger.json";

    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        app.UseSwagger();
        app.UseSwaggerUI(settings =>
        {
            settings.DefaultModelExpandDepth(0);
            settings.DefaultModelRendering(ModelRendering.Model);
            settings.DefaultModelsExpandDepth(0);
            settings.DocExpansion(DocExpansion.None);
            settings.OAuthScopeSeparator(" ");
            settings.OAuthClientId("client_id_sts");
            settings.OAuthClientSecret("client_secret_sts");
            settings.DisplayRequestDuration();
        });
    }

    public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.ResolveConflictingActions(x => x.First());
            //var url = configuration.GetSection("AuthServer").GetValue<string>("Url");

            //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //{
            //    Type = SecuritySchemeType.OAuth2,
            //    Flows = new OpenApiOAuthFlows
            //    {
            //        Password = new OpenApiOAuthFlow
            //        {
            //            TokenUrl = new Uri($"{url}/connect/token", UriKind.Absolute),
            //            Scopes = new Dictionary<string, string>
            //            {
            //            { "api", "Default scope" }
            //            }
            //        }
            //    }
            //});
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                },
                new List<string>()
            }
            });
        });
    }
}