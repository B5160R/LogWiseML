using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Logs;

namespace DataInput.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataInputController : ControllerBase
    {
        private readonly ILogger<DataInputController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public DataInputController(ILogger<DataInputController> logger, IPublishEndpoint publishEndpoint )
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogInput dto)
        {
            await _publishEndpoint.Publish<LogInput>(dto);

            return Ok();
        }
    }
}