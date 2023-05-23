using DataProcessing.Application.Dtos;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataProcessing.API.Infrastructure.Producer.Interfaces;

namespace DataProcessing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataProcessingController
{
    private readonly IGetAllQuery<LogQueryResultDto> _getAllQuery;
    private readonly IConvertToCSV<LogQueryResultDto> _convertToCSV;
    private readonly IProducerAnalysis _producerAnalysis;
    private readonly IProducerMLDataset _producerMLDataset;
    public DataProcessingController(IGetAllQuery<LogQueryResultDto> getAllQuery, 
                                    IConvertToCSV<LogQueryResultDto> convertToCSV,
                                    IProducerAnalysis producerAnalysis,
                                    IProducerMLDataset producerMLDataset)
    {
        _getAllQuery = getAllQuery;
        _convertToCSV = convertToCSV;
        _producerAnalysis = producerAnalysis;
        _producerMLDataset = producerMLDataset;
    }

    [HttpGet]
    [Route("csv")]
    public async Task<string> GetAllAsCSV()
    {
        var dtos = await _getAllQuery.GetAllAsync();
        return await _convertToCSV.ConvertListAsync(dtos);
    }

    [HttpGet]
    public async Task<IEnumerable<LogQueryResultDto>> GetAll()
    {
        return await _getAllQuery.GetAllAsync();
    }

    [HttpGet]
    [Route("mldataset")]
    public async Task SendToMLTrainer()
    {
        await _producerMLDataset.ProduceAsync();
    }
}