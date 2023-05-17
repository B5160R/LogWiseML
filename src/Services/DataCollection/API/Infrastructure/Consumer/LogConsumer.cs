using DataCollection.API.Infrastructure.Producer.Interfaces;
using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Dtos;
using MassTransit;
using Shared.Models.Logs;

namespace DataCollection.API.Infrastructure.Consumer;
public class LogConsumer : IConsumer<LogInput>
{
    private readonly ILogger<LogConsumer> _logger;
    private readonly ICreateCommand<LogCreateRequestDto> _createCommand;
    private readonly IProducer _producer;
    
    public LogConsumer(ILogger<LogConsumer> logger, ICreateCommand<LogCreateRequestDto> createCommand, IProducer producer)
    {
        _logger = logger;
        _createCommand = createCommand;
        _producer = producer;
    }

    public async Task Consume(ConsumeContext<LogInput> context)
    {
        await Console.Out.WriteLineAsync($"Info: Received log from DataInput Gateway API");
        await Console.Out.WriteLineAsync($"      --- Log content: {context.Message.Content}");
        try
        {
            var savedLogDto = await _createCommand.CreateAsync(new LogCreateRequestDto(context.Message.Content));
            await _producer.ProduceAsync(savedLogDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing log");
        }
    }
}