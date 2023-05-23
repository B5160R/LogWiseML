using DataProcessing.API.Infrastructure.Producer.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;
using MassTransit;
using Shared.Models.Logs;

public class LogConsumer : IConsumer<LogInput>
{
    private readonly ILogger<LogConsumer> _logger;
    private readonly ICreateCommand<LogProcessRequestDto> _createCommand;
    private readonly IPrepForAnalysis<LogProcessRequestDto> _prepForAnalysis;
    private readonly IProducerAnalysis _producerAnalysis;
    public LogConsumer(ILogger<LogConsumer> logger, 
                       ICreateCommand<LogProcessRequestDto> createCommand,
                       IPrepForAnalysis<LogProcessRequestDto> prepForAnalysis,
                       IProducerAnalysis producerAnalysis)
    {
        _logger = logger;
        _createCommand = createCommand;
        _prepForAnalysis = prepForAnalysis;
        _producerAnalysis = producerAnalysis;
    }
    
    public async Task Consume(ConsumeContext<LogInput> context)
    {
        await Console.Out.WriteLineAsync($"Info: Received log from DataCollector API");
        await Console.Out.WriteLineAsync($"      --- Log content: {context.Message.Content}");

        try
        {
            var dto = new LogProcessRequestDto(context.Message.Content);
            
            await _createCommand.CreateAsync(dto);

            var analysisDto = await _prepForAnalysis.Prep(dto);
            await _producerAnalysis.ProduceAsync(analysisDto);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
        }
    }
}