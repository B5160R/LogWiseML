using DataProcessing.API.Infrastructure.Producer.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Dtos;
using MassTransit;

namespace DataProcessing.API.Infrastructure.Producer;
public class LogProducerMLDataset : IProducer
{
    private readonly ILogger<LogProducerMLDataset> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IConvertToCSV<LogQueryResultDto> _convertToCSV;
    private readonly IGetAllQuery<LogQueryResultDto> _getAllQuery;

    public LogProducerMLDataset(ILogger<LogProducerMLDataset> logger, 
                                IPublishEndpoint publishEndpoint, 
                                IConvertToCSV<LogQueryResultDto> convertToCSV, 
                                IGetAllQuery<LogQueryResultDto> getAllQuery)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
        _convertToCSV = convertToCSV;
        _getAllQuery = getAllQuery;
    }

    public async Task ProduceAsync()
    {
        try
        {
            await Console.Out.WriteLineAsync($"Info: Sending log to MLTrainer API");
            var dtos = await _getAllQuery.GetAllAsync();
            var dataset = await _convertToCSV.ConvertAsync(dtos);

            // Send to MLTrainer API
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
        }
    }
}