using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Transport.MQTT.Models
{
    public class TelemetryDataModel
    {
        [JsonPropertyName("DeviceId")] public Guid DeviceId { get; set; }
        [JsonPropertyName("Ts")] public long Timestamp { get; set; }
        [JsonPropertyName("Data")] public object Data { get; set; }

        public override string ToString()
        {
            return $"{nameof(DeviceId)}: {DeviceId}, {nameof(Timestamp)}: {Timestamp}, {nameof(Data)}: {Data}";
        }
    }
}