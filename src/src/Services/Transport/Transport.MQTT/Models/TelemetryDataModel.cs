using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Transport.MQTT.Models
{
    public class TelemetryDataModel
    {
        public Guid DeviceId { get; set; }
        public long? Timestamp { get; set; }
        public object Model { get; set; }
    }
}