using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Dtos;
using MassTransit;
using Shared.Models.Logs;

public class LogConsumer : IConsumer<LogInput>
{
    private readonly ILogger<LogConsumer> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICreateCommand<LogCreateRequestDto> _createCommand;
    
    public LogConsumer(ILogger<LogConsumer> logger, IPublishEndpoint publishEndpoint, ICreateCommand<LogCreateRequestDto> createCommand)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
        _createCommand = createCommand;
    }

    public async Task Consume(ConsumeContext<LogInput> context)
    {
        await Console.Out.WriteLineAsync($"Info: Received log from DataInput Gateway API");
        await Console.Out.WriteLineAsync($"      --- Log content: {context.Message.Content}");
        try
        {
            var savedLogDto = await _createCommand.CreateAsync(new LogCreateRequestDto(context.Message.Content));
            
            var logProcessedDto = new LogRaw(savedLogDto.Id, savedLogDto.Content);

            await Console.Out.WriteLineAsync($"Info: Sending log to DataProcessing API");

            await _publishEndpoint.Publish<LogRaw>(logProcessedDto);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
        }
    }
}