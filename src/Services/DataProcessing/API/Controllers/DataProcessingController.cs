using DataProcessing.Application.Dtos;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataProcessing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataProcessingController
{
    private readonly IGetAllQuery<LogQueryResultDto> _getAllQuery;
    private readonly IConvertToCSV<LogQueryResultDto> _convertToCSV;
    public DataProcessingController(IGetAllQuery<LogQueryResultDto> getAllQuery, IConvertToCSV<LogQueryResultDto> convertToCSV)
    {
        _getAllQuery = getAllQuery;
        _convertToCSV = convertToCSV;
    }

    [HttpGet]
    public string GetAll()
    {
        var dtos = _getAllQuery.GetAll();
        return _convertToCSV.ConvertAsync(dtos).Result;
    }
}