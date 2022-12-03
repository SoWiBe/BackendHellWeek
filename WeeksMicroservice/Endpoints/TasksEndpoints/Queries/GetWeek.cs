using Calabonga.OperationResults;
using MediatR;
using WeeksMicroservice.Infrastructure.MongoDb;
using Week = WeeksMicroservice.Models.Week;

namespace WeeksMicroservice.Endpoints.TasksEndpoints.Queries;

public record GetWeekRequest(string id) : IRequest<OperationResult<Models.Week>>;

public class GetWeekRequestHandler : IRequestHandler<GetWeekRequest, OperationResult<Models.Week>>
{
    private readonly IDbWorker<Models.Week> _repository;

    public GetWeekRequestHandler(IDbWorker<Models.Week> service)
    {
        _repository = service;
    }
    public async Task<OperationResult<Models.Week>> Handle(GetWeekRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var weekFromDb = _repository.GetRecordsByFilter(x => x.Id == request.id);
            return await weekFromDb;
        }
        catch (Exception ex)
        {
            return new OperationResult<Week> {Error = ex};
        }
    }
}
