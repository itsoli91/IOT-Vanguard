namespace Core.Domain.AggregatesModel.Device
{
    public enum DeviceAuthenticationType
    {
        AccessToken = 1,
        MqttX509 = 2,
        MqttBasic = 3
    }
}