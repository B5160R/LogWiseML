using System.Threading.Tasks;
using DataCollection.Domain.Models;
using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Dtos;
using DataCollection.Application.Repositories;

namespace DataCollection.Application.Commands;

public class LogCreateCommand<T> : ICreateCommand<LogCreateRequestDto> where T : class
{
    private readonly ILogRepository _repository;

    public LogCreateCommand(ILogRepository repository)
    {
        _repository = repository;
    }

    async Task<LogQueryResultDto> ICreateCommand<LogCreateRequestDto>.CreateAsync(LogCreateRequestDto dto)
    {
        var returnDto = await _repository.CreateAsync(new LogModel(dto.Content));
        return returnDto;
    }
}