using Calabonga.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskMicro.Definitions.Base;
using TaskMicro.Endpoints.TasksEndpoints.Queries;
using Task = TaskMicro.Models.Task;

namespace TaskMicro.Endpoints.TasksEndpoints;

public class TasksEndpoint : AppDefinition
{
    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
    {
        app.MapGet("/api/get-task/{id}", GetTask);
        app.MapPost("/api/add-task/", PostTask);
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    private async Task<OperationResult<Task>> GetTask([FromServices] IMediator mediator, HttpContext context, string id)
        => await mediator.Send(new GetTaskRequest(id), context.RequestAborted);
    
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    private async Task<OperationResult<Task>> PostTask([FromServices] IMediator mediator, HttpContext context, Task task)
        => await mediator.Send(new PostTaskRequest(task), context.RequestAborted);

}