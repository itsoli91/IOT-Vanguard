using System;
using Common.Domain;

namespace Core.Domain.AggregatesModel.DeviceTemplate
{
    public class DeviceTemplate : EntityBase
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Namespace { get; set; }
        public Guid OwnerId { get; set; }

        public DeviceTemplateModel Model { get; set; }
    }
}