using DataProcessing.Domain.Models;
namespace DataProcessing.Application.Repositories;
public interface ILogProcessedRepository
{
    Task CreateAsync(LogProcessedModel entity);
}