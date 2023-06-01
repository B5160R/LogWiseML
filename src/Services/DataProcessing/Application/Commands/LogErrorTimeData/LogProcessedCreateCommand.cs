using DataProcessing.Domain.Models;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos.LogErrorTimeData;
using DataProcessing.Application.Repositories;

namespace DataProcessing.Application.Commands.LogErrorTimeData;
public class LogProcessedCreateCommand : ICreateCommand<LogProcessRequestDto>
{
    private readonly ILogProcessedRepository _repository;
    public LogProcessedCreateCommand(ILogProcessedRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(LogProcessRequestDto dto)
    {
        var entityProcessed = new LogProcessedModel("LogErrorTime", dto.Content);

        await _repository.CreateAsync(entityProcessed);
    }
}