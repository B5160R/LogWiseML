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
    private readonly HttpClient _httpClient;

    public LogProducerAnalysis(ILogger<LogProducerAnalysis> logger, 
                                HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
    public async Task ProduceAsync(string dto)
    {
        try
        {
            // Send to ML API for analysis
            Console.WriteLine("***********************");
            Console.WriteLine(dto);
            Console.WriteLine("***********************");
            var response = await _httpClient.PostAsJsonAsync("/api/run/testmodel", dto);
            if(response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Successfully sent data to Analysis API");
            }
            else
            {
                _logger.LogError("* Error while sending data to Analysis API");
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error while sending data to Analysis API");
        }
    }
}