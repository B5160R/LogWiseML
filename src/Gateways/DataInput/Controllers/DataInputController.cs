using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Logs;

namespace DataInput.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DataInputController : ControllerBase
    {
        private readonly ILogger<DataInputController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public DataInputController(ILogger<DataInputController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogInput dto)
        {
            try
            {
                await _publishEndpoint.Publish<LogInput>(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending log");
                return BadRequest();
            }
        }
    }
}