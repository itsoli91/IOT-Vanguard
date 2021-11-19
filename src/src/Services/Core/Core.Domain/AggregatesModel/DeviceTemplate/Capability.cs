using System.Collections.Generic;
using Common.Domain;

namespace Core.Domain.AggregatesModel.DeviceTemplate
{
    public class Capability : EntityBase
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public CapabilityType CapabilityType { get; set; }
        public Schema Schema { get; set; }
        public Unit Unit { get; set; }
        public string DisplayUnit { get; set; }
        public bool IsComplex { get; set; }
        public List<SubCapability> SubCapabilities { get; set; }

        public long SemanticTypeId { get; set; }
        public SemanticType CapabilitySemanticType { get; set; }
        public long DeviceTemplateModelId { get; set; }
    }
}