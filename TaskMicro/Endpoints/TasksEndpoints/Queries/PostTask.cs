using Calabonga.OperationResults;
using MediatR;
using TaskMicro.Infrastructure.MongoDb;
using Task = TaskMicro.Models.Task;

namespace TaskMicro.Endpoints.TasksEndpoints.Queries;

public record PostTaskRequest(Models.Task Task) : IRequest<OperationResult<Models.Task>>;
public class PostTaskRequestHandler : IRequestHandler<PostTaskRequest, OperationResult<Models.Task>>
{
    private readonly IDbWorker<Models.Task> _repository;

    public PostTaskRequestHandler(IDbWorker<Models.Task> repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult<Models.Task>> Handle(PostTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddNewRecord(request.Task);
        }
        catch (Exception ex)
        {
            return new OperationResult<Task> { Error = ex };
        }

        return new OperationResult<Task>
        {
            Result = new Models.Task
            {
                Id = request.Task.Id,
                Description = request.Task.Description, 
                Status = request.Task.Status, 
                Tag = request.Task.Status,
                Title = request.Task.Title
            }
        };
    }
}