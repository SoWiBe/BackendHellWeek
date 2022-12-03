using Calabonga.OperationResults;
using MongoDB.Driver;

namespace TaskMicro.Infrastructure.MongoDb;

public class MongoDbWorker<T> : IDbWorker<T> where T : IMongoModel
{
    private readonly IMongoCollection<T> _collection;
    private readonly ILogger<MongoDbWorker<T>> _logger;

    public MongoDbWorker(IMongoClient client, MongoDbSettings settings, ILogger<MongoDbWorker<T>> logger)
    {
        _logger = logger;
        _collection = client.GetDatabase(settings.DatabaseName).GetCollection<T>(settings.CollectionName);
    }
    
    public async Task<OperationResult<T>> GetRecordsByFilter(Func<T, bool> predicate)
    {
        var result = new OperationResult<T>();

        try
        {
            var tmp =  _collection.AsQueryable().Where(predicate).FirstOrDefault();
            if (tmp == null)
            {
                var errorMessage = "Can't find an object";
                _logger.LogError(errorMessage);
                result.AddError(new Exception(errorMessage));
            }

            result.Result = tmp!;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            result.AddError(e);
        }

        return result;
    }

    public async Task<OperationResult<bool>> AddNewRecord(T record)
    {
        OperationResult<bool> result = new OperationResult<bool>();
        try
        {
            await _collection.InsertOneAsync(record);
            result.Result = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            result.Result = false;
            result.AddError(ex.Message);
        }

        return result;
    }

    public async Task<OperationResult<bool>> AddNewRecordsRange(IEnumerable<T> records)
    {
        OperationResult<bool> result = new OperationResult<bool>();
        try
        {
            await _collection.InsertManyAsync(records);
            result.Result = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            result.Result = false;
            result.AddError(e.Message);
        }

        return result;
    }

    public async Task<OperationResult<bool>> UpdateRecord(T record)
    {
        var result = new OperationResult<bool>();

        try
        {
            var filter = Builders<T>.Filter.Eq("_id", record.Id);
            var updateResult = await _collection.ReplaceOneAsync(filter, record);

            result.Result = updateResult.IsModifiedCountAvailable;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            result.AddError(e);
        }

        return result;
    }
}