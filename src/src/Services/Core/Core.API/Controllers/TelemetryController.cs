using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using Microsoft.Extensions.Logging;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly ILogger<TelemetryController> _logger;

        public TelemetryController(ILogger<TelemetryController> logger)
        {
            _logger = logger;
        }

        [Topic(DaprEventBusConstants.PubSubInternal, EventBusTopics.TelemetryPublish)]
        public IActionResult Publish(TelemetryPublishEvent telemetry)
        {
            _logger.LogInformation(telemetry.ToString());
            return Ok();
        }
    }
}