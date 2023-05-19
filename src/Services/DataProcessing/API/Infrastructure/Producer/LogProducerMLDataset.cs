using DataProcessing.API.Infrastructure.Producer.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Dtos;
using MassTransit;

namespace DataProcessing.API.Infrastructure.Producer;
public class LogProducerMLDataset : IProducerMLDataset
{
    private readonly ILogger<LogProducerMLDataset> _logger;
    private readonly HttpClient _httpClient;
    private readonly IConvertToCSV<LogQueryResultDto> _convertToCSV;
    private readonly IGetAllQuery<LogQueryResultDto> _getAllQuery;

    public LogProducerMLDataset(ILogger<LogProducerMLDataset> logger,
                                IConvertToCSV<LogQueryResultDto> convertToCSV, 
                                IGetAllQuery<LogQueryResultDto> getAllQuery,
                                HttpClient httpClient)
    {
        _logger = logger;
        _convertToCSV = convertToCSV;
        _getAllQuery = getAllQuery;
        _httpClient = httpClient;
    }

    public async Task ProduceAsync()
    {
        try
        {
            await Console.Out.WriteLineAsync($"Info: Sending log to MLTrainer API");
            var dtos = await _getAllQuery.GetAllAsync();
            var dataset = await _convertToCSV.ConvertAsync(dtos);

            // Send to ML API
            var response = await _httpClient.PostAsJsonAsync("/api/dataset", dataset);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error while processing log");
            throw;;
        }
    }
}