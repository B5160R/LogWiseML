using DataProcessing.API.Infrastructure.Producer.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;
using DataProcessing.Application.Queries.Interfaces;
using MassTransit;
using Shared.Models.Logs;

namespace DataProcessing.API.Infrastructure.Producer;
public class LogProducerAnalysis : IProducerAnalysis
{
    private readonly ILogger<LogProducerAnalysis> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IConvertToCSV<LogQueryResultDto> _convertToCSV;
    private readonly IGetAllQuery<LogQueryResultDto> _getAllQuery;

    public LogProducerAnalysis(ILogger<LogProducerAnalysis> logger, 
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
            var dtos = await _getAllQuery.GetAllAsync();
            var csvdata = _convertToCSV.ConvertAsync(dtos);

            // Send to Analysis API
            await _publishEndpoint.Publish<LogCsv>(new
            {
                Content = csvdata
            });
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error while sending data to Analysis API");
        }
    }
}