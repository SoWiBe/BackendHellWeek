using Calabonga.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeeksMicroservice.Definitions.Base;
using WeeksMicroservice.Endpoints.TasksEndpoints.Queries;
using Week = WeeksMicroservice.Models.Week;

namespace WeeksMicroservice.Endpoints.TasksEndpoints;

public class WeeksEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
    {
        app.MapGet("/api/get-week/{id}", GetWeek);
        app.MapPost("/api/add-week/", PostWeek);
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    private async Task<OperationResult<Week>> GetWeek([FromServices] IMediator mediator, HttpContext context, string id)
        => await mediator.Send(new GetWeekRequest(id), context.RequestAborted);
    
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    private async Task<OperationResult<Week>> PostWeek([FromServices] IMediator mediator, HttpContext context, Week week)
        => await mediator.Send(new PostWeekRequest(week), context.RequestAborted);

}