using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;
using MassTransit;
using Shared.Models.Logs;

public class LogConsumer : IConsumer<LogRaw>
{
    private readonly ILogger<LogConsumer> _logger;
    private readonly ICreateCommand<LogProcessRequestDto> _createCommand;
    public LogConsumer(ILogger<LogConsumer> logger, ICreateCommand<LogProcessRequestDto> createCommand)
    {
        _logger = logger;
        _createCommand = createCommand;
    }
    
    public async Task Consume(ConsumeContext<LogRaw> context)
    {
        await Console.Out.WriteLineAsync($"Info: Received log from DataCollector API");
        await Console.Out.WriteLineAsync($"      --- Log ID: {context.Message.Id}"); 
        await Console.Out.WriteLineAsync($"      --- Log content: {context.Message.Content}");

        try
        {
            var dto = new LogProcessRequestDto(context.Message.Id, context.Message.Content);
            await _createCommand.Create(dto);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
        }
    }
}