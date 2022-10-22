using Swashbuckle.AspNetCore.SwaggerUI;
using TaskMicro.Definitions.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefinitions(builder, typeof(Program));

var app = builder.Build();

app.UseDefinitions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();