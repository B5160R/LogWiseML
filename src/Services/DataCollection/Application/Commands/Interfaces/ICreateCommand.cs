using DataCollection.Application.Dtos;
namespace DataCollection.Application.Commands.Interfaces
{
    public interface ICreateCommand<T>
    {
        Task<LogQueryResultDto> CreateAsync(T dto);
    }
}