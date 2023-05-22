using DataCollection.Application.Dtos;

namespace DataCollection.API.Infrastructure.Producer.Interfaces;
public interface IProducer
{
    Task ProduceAsync(LogQueryResultDto dto);
}