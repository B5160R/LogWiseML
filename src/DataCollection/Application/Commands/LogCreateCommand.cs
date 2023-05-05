using System.Threading.Tasks;
using DataCollection.Domain.Models;
using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Dtos;
using DataCollection.Application.Repositories;

namespace DataCollection.Application.Commands;

public class LogCreateCommand<T> : ICreateCommand<LogCreateRequestDto> where T : class
{
    private readonly ILogRepository _repository;
    private readonly ILogParserCommand _logParserCommand;

    public LogCreateCommand(ILogRepository repository, ILogParserCommand logParserCommand)
    {
        _repository = repository;
        _logParserCommand = logParserCommand;
    }

    void ICreateCommand<LogCreateRequestDto>.Create(LogCreateRequestDto dto)
    {
        var separatedLogs = _logParserCommand.SeperateLogs(dto.Content);

        foreach (var log in separatedLogs)
        {
            _repository.CreateAsync(new LogModel(log));
        }
    }
}