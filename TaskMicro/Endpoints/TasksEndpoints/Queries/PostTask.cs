using MediatR;
using TaskMicro.Services;

namespace TaskMicro.Endpoints.TasksEndpoints.Queries;

public record PostTaskRequest(Models.Task Task) : IRequest<Models.Task>;
public class PostTaskRequestHandler : IRequestHandler<PostTaskRequest, Models.Task>
{
    private readonly TasksService _service;

    public PostTaskRequestHandler(TasksService service)
    {
        _service = service;
    }
    public async Task<Models.Task> Handle(PostTaskRequest request, CancellationToken cancellationToken)
    {
        Models.Task task = new Models.Task();
        try
        {
            task = _service.Create(request.Task);
            return task;
        }
        catch (Exception ex)
        {
            return task;
        }
    }
}