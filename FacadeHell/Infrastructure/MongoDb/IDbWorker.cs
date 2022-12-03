using Calabonga.OperationResults;

namespace TaskMicro.Infrastructure.MongoDb;

public interface IDbWorker<T>
{
    Task<OperationResult<T>> GetRecordsByFilter(Func<T, bool> predicate);
    Task<OperationResult<bool>> AddNewRecord(T record);
    Task<OperationResult<bool>> AddNewRecordsRange(IEnumerable<T> records);
    Task<OperationResult<bool>> UpdateRecord(T record);
}