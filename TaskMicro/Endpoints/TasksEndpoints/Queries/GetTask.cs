using MediatR;
using TaskMicro.Services;

namespace TaskMicro.Endpoints.TasksEndpoints.Queries;

public record GetTaskRequest(string id) : IRequest<Models.Task>;

public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, Models.Task>
{
    private readonly TasksService _service;

    public GetTaskRequestHandler(TasksService service)
    {
        _service = service;
    }
    public async Task<Models.Task> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {
        Models.Task task = new Models.Task();
        try
        {
            task = _service.Get(request.id);
            return task;
        }
        catch (Exception ex)
        {
            return task;
        }
    }
}
