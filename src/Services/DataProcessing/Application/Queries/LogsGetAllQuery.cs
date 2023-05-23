using DataProcessing.Application.Dtos.LogErrorTimeData;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Repositories;

namespace DataProcessing.Application.Queries;
public class LogsGetAllQuery : IGetAllQuery<LogQueryResultDto>
{
    private readonly ILogProcessedRepository _repository;
    public LogsGetAllQuery(ILogProcessedRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<LogQueryResultDto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
