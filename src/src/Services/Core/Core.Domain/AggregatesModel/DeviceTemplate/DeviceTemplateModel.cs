using System.Collections;
using System.Collections.Generic;
using Common.Domain;

namespace Core.Domain.AggregatesModel.DeviceTemplate
{
    public class DeviceTemplateModel : EntityBase
    {
        public ICollection<Capability> Capabilities { get; set; }
        public long DeviceTemplateId { get; set; }
    }
}