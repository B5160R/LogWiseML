using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Dtos;
using DataCollection.Application.Queries.Interfaces;
using MassTransit;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataCollectionController : ControllerBase
{
    private readonly ILogger<DataCollectionController> _logger;
    private readonly IGetAllQuery<IEnumerable<LogQueryResultDto>> _getAllQuery;
    private readonly ICreateCommand<LogCreateRequestDto> _createCommand;
    private readonly IPublishEndpoint _publishEndpoint;

    public DataCollectionController(ILogger<DataCollectionController> logger, 
                                    IGetAllQuery<IEnumerable<LogQueryResultDto>> getAllQuery, 
                                    ICreateCommand<LogCreateRequestDto> createCommand,
                                    IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _getAllQuery = getAllQuery;
        _createCommand = createCommand;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public IEnumerable<LogQueryResultDto> GetAll()
    {
        try
        {
            return _getAllQuery.LogGetAll();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all logs");
            throw;
        }
    }

    // curl -X POST -H "Content-type: application/json" --data "{\"content\": \"cmdTest666\"}" http://localhost:5026/datacollection
    // [HttpPost]
    // public async Task<IActionResult> Post([FromBody] string Content)
    // {
    //     try
    //     {
    //         _createCommand.Create(new LogCreateRequestDto { Content = Content });
            
    //         // var test = new LogRaw { Content = Content };
    //         // await _publishEndpoint.Publish<LogRaw>(test);

    //         return Ok();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Error creating log");
    //         throw;
    //     }
    // }
}