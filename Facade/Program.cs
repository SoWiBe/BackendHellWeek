using Serilog;
using Serilog.Events;
using TaskMicro.Definitions.Base;

try
{
    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .CreateLogger();
    // created builder
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDefinitions(builder, typeof(Program));

    
    // create application
    var app = builder.Build();
    app.UseDefinitions();
    app.UseCors("ApiCorsPolicy");

    // start application
    app.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
