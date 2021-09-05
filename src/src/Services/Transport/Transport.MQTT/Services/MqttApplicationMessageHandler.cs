using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dapr.Client;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using MQTTnet;
using MQTTnet.Client.Receiving;
using Transport.MQTT.Models;

namespace Transport.MQTT.Services
{
    public class MqttApplicationMessageHandler : IMqttApplicationMessageReceivedHandler
    {
        private readonly DaprClient _daprClient;

        public MqttApplicationMessageHandler()
        {
            _daprClient = new DaprClientBuilder().Build();
        }

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            switch (eventArgs.ApplicationMessage.Topic)
            {
                case "v1/telemetry/publish":
                    var telemetry =
                        JsonSerializer.Deserialize<TelemetryDataModel>(eventArgs.ApplicationMessage.Payload);
                    if (telemetry != null)
                    {
                        var message = new TelemetryPublishEvent(telemetry.DeviceId,
                            telemetry.Timestamp ?? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), telemetry.Model);
                        await _daprClient.PublishEventAsync(DaprEventBusConstants.PubSubInternal,
                            EventBusTopics.TelemetryPublish, message);
                      
                    }

                    break;
            }
        }
    }
}