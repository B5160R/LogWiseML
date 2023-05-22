using DataProcessing.Domain.Models;
using DataProcessing.Application.Dtos;
namespace DataProcessing.Application.Repositories;
public interface ILogProcessedRepository
{
    Task CreateAsync(LogProcessedModel entity);
    Task<IEnumerable<LogQueryResultDto>> GetAllAsync();
}