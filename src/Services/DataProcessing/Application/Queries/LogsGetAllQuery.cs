using DataProcessing.Application.Dtos;
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
    public IEnumerable<LogQueryResultDto> GetAll()
    {
        return _repository.GetAll();
    }
}
