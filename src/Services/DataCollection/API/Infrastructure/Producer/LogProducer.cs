using DataCollection.API.Infrastructure.Producer.Interfaces;
using DataCollection.Application.Dtos;
using MassTransit;
using Shared.Models.Logs;

namespace DataCollection.API.Infrastructure.Producer;
public class LogProducer : IProducer
{
    private readonly ILogger<LogProducer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public LogProducer(ILogger<LogProducer> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task ProduceAsync(LogQueryResultDto dto)
    {
        try
        {
            await Console.Out.WriteLineAsync($"Info: Sending log with id {dto.Id} to DataProcessing API");
            var logProcessedDto = new LogRaw(dto.Id, dto.Content);
            await _publishEndpoint.Publish<LogRaw>(logProcessedDto);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
        }
    }
}