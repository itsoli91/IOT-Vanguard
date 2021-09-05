using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Dapr.Client;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using Microsoft.Extensions.Logging;
using Transport.MQTT.Models;

namespace Transport.MQTT.Controllers
{
    [ApiController]
    [Route("")]
    public class TelemetryController : ControllerBase
    {
        private readonly ILogger<TelemetryController> _logger;
        private readonly DaprClient _daprClient;

        public TelemetryController(ILogger<TelemetryController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        //[HttpPost("v1/telemetry/publish")]
        //public async Task<ActionResult> Publish(TelemetryDataModel telemetry)
        //{
        //    try
        //    {
        //        _logger.LogInformation(telemetry.ToString());
        //        await _daprClient.PublishEventAsync(DaprEventBusConstants.PubSubInternal,
        //            EventBusTopics.TelemetryPublish,
        //            new TelemetryPublishEvent(telemetry.DeviceId, telemetry.Timestamp, telemetry.Data));
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error occurred while processing telemetry publish");
        //        return StatusCode(500);
        //    }
        //}
    }
}