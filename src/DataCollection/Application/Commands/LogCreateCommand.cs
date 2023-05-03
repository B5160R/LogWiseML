using System.Threading.Tasks;
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

    void ICreateCommand<LogCreateRequestDto>.Create(LogCreateRequestDto dto)
    {
        _repository.CreateAsync(new Domain.Models.LogModel(dto.Content));
    }
}