using Calabonga.OperationResults;
using MediatR;
using TaskMicro.Infrastructure.MongoDb;
using Task = TaskMicro.Models.Task;

namespace TaskMicro.Endpoints.TasksEndpoints.Queries;

public record GetTaskRequest(string id) : IRequest<OperationResult<Models.Task>>;

public class GetTaskRequestHandler : IRequestHandler<GetTaskRequest, OperationResult<Models.Task>>
{
    private readonly IDbWorker<Models.Task> _repository;

    public GetTaskRequestHandler(IDbWorker<Models.Task> service)
    {
        _repository = service;
    }
    public async Task<OperationResult<Models.Task>> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var taskFromDb = _repository.GetRecordsByFilter(x => x.Id == request.id);
            return await taskFromDb;
        }
        catch (Exception ex)
        {
            return new OperationResult<Task> {Error = ex};
        }
    }
}
