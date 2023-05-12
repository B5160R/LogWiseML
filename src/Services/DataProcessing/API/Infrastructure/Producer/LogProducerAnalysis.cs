using DataProcessing.API.Infrastructure.Producer.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;
using DataProcessing.Application.Queries.Interfaces;
using MassTransit;

namespace DataProcessing.API.Infrastructure.Producer;
public class LogProducerAnalysis : IProducer
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
        var dtos = await _getAllQuery.GetAllAsync();
        var csvdata = _convertToCSV.ConvertAsync(dtos);

        // Send to Analysis API
    }
}


