using System;

namespace EventBus.Messages.Events
{
    public class TelemetryPublishEvent : IntegrationBaseEvent
    {
        public TelemetryPublishEvent()
        {
        }

        public TelemetryPublishEvent(Guid deviceId, long timestamp, object data)
        {
            DeviceId = deviceId;
            Timestamp = timestamp;
            Data = data;
        }

        public Guid DeviceId { get; set; }
        public long Timestamp { get; set; }
        public object Data { get; set; }
    }
}