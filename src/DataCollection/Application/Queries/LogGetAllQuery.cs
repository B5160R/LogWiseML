using DataCollection.Application.Queries.Interfaces;
using DataCollection.Application.Repositories;
using DataCollection.Application.Dtos;
using System.Threading.Tasks;

namespace DataCollection.Application.Queries;
public class LogGetAllQuery : IGetAllQuery<IEnumerable<LogQueryResultDto>>
{
    private readonly ILogRepository _repository;
    public LogGetAllQuery(ILogRepository repository)
    {
        _repository = repository;
    }
   
    IEnumerable<LogQueryResultDto> IGetAllQuery<IEnumerable<LogQueryResultDto>>.LogGetAll()
    {
        return _repository.GetAllAsync();
    }
}