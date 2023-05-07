using System.Threading.Tasks;
using DataCollection.Application.Dtos;
using DataCollection.Domain.Models;

namespace DataCollection.Application.Repositories;
public interface ILogRepository
{
    Task CreateAsync(LogModel entity);
    IEnumerable<LogQueryResultDto> GetAllAsync();
}