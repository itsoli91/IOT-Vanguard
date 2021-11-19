using System;
using System.Buffers.Text;
using System.Text;
using Common.Domain;

namespace Core.Domain.AggregatesModel.Device
{
    public class Device : EntityBase
    {
        public void NewToken()
        {
            DeviceAccessKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        }

        public string Name { get; set; }
        public DeviceAuthenticationType AuthenticationType { get; set; }
        public string RsaPublicKey { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DeviceAccessKey { get; set; }
        public long DeviceTemplateId { get; set; }
        public DeviceTemplate.DeviceTemplate DeviceTemplate { get; set; }
    }
}