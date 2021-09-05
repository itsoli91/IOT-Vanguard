using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EventBus.Messages.Events
{
    public class TelemetryPublishEvent : IntegrationBaseEvent
    {
        public TelemetryPublishEvent()
        {
        }

        public TelemetryPublishEvent(Guid deviceId, long timestamp, object model)
        {
            DeviceId = deviceId;
            Timestamp = timestamp;
            Model = model;
        }

        public Guid DeviceId { get; set; }
        public long Timestamp { get; set; }
        public object Model { get; set; }
    }
}