using TaskMicro.Definitions.Base;

namespace TaskMicro.Definitions.Cors
{
    public class CorsDefinition : AppDefinition
    {
        public override void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:20001").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc();
        }
    }
}