using Calabonga.OperationResults;
using MediatR;
using WeeksMicroservice.Infrastructure.MongoDb;
using Week = WeeksMicroservice.Models.Week;

namespace WeeksMicroservice.Endpoints.TasksEndpoints.Queries;

public record PostWeekRequest(Models.Week Week) : IRequest<OperationResult<Models.Week>>;
public class PostWeekRequestHandler : IRequestHandler<PostWeekRequest, OperationResult<Models.Week>>
{
    private readonly IDbWorker<Models.Week> _repository;

    public PostWeekRequestHandler(IDbWorker<Models.Week> repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult<Models.Week>> Handle(PostWeekRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddNewRecord(request.Week);
        }
        catch (Exception ex)
        {
            return new OperationResult<Week> { Error = ex };
        }

        return new OperationResult<Week>
        {
            Result = new Models.Week
            {
                Id = request.Week.Id,
                Title = request.Week.Title,
                Description = request.Week.Description,
                
            }
        };
    }
}